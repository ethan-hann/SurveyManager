using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.surveyMenu;
using SurveyManager.forms.surveyMenu.billingPortal;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.userControls
{
    public partial class BillingPortalCtl : UserControl
    {
        private int selectedListBoxIndex = -1;

        private Dictionary<string, List<BillingItem>> billingItems = new Dictionary<string, List<BillingItem>>();

        public EventHandler StatusUpdate;

        public BillingPortalCtl()
        {
            InitializeComponent();
        }

        private void BillingPortalCtl_Load(object sender, EventArgs e)
        {
            LineItemsCtl lControl = new LineItemsCtl(JobHandler.Instance.CurrentJob.BillingObject.GetLineItems());
            lControl.Dock = DockStyle.Fill;
            lControl.StatusUpdate += ChangeStatusText;

            pgAdditionalLineItems.Controls.Add(lControl);
            billingGrid.RegisterGroupBoxEvents();
            DataGridViewSetup.SetupDGV(billingGrid, EntityTypes.BillingItem);

            billingItems = Utility.CreateDictionary(JobHandler.Instance.CurrentJob.BillingObject.GetBillingItems());
            PopulateListBox();
            UpdateTotalTime();

            kryptonNavigator1.SelectedPage = pgTimeEntries;
        }

        private void LoadData()
        {
            StatusUpdate?.Invoke(this, new StatusArgs("Loading details for billing..."));
            loadProgressBar.Value = 0;
            loadProgressBar.Visible = true;

            if (!loadBillingDetailsWorker.IsBusy)
                loadBillingDetailsWorker.RunWorkerAsync();
        }

        List<OutlookGridRow> rows;
        private void loadBillingDetailsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (selectedListBoxIndex >= 0)
            {
                List<BillingItem> items = billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]];
                OutlookGridRow row;
                rows = new List<OutlookGridRow>();

                foreach (BillingItem item in items)
                {
                    if (item.OfficeTime == TimeSpan.Zero)
                    {
                        row = new OutlookGridRow();
                        row.CreateCells(billingGrid, new object[] {
                            item.ID,
                            item.Description,
                            item.FieldRate,
                            Utility.ToFullString(item.FieldTime)
                        });
                        row.Tag = item;
                        rows.Add(row);
                    }
                    else
                    {
                        row = new OutlookGridRow();
                        row.CreateCells(billingGrid, new object[] {
                            item.ID,
                            item.Description,
                            item.OfficeRate,
                            Utility.ToFullString(item.OfficeTime)
                        });
                        row.Tag = item;
                        rows.Add(row);
                    }
                }
            }
        }

        private void loadBillingDetailsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadProgressBar.Value = e.ProgressPercentage;
        }

        private void loadBillingDetailsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Disposing && !IsDisposed)
            {
                if (selectedListBoxIndex >= 0)
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Billing Details for {(DateTime.Parse((string)lbTimeEntries.Items[selectedListBoxIndex])).Date.ToShortDateString()} loaded."));
                    billingGrid.SuspendLayout();
                    billingGrid.ClearInternalRows();
                    billingGrid.ResumeLayout();
                    billingGrid.AssignRows(rows);
                    billingGrid.ForceRefreshGroupBox();
                    billingGrid.Fill();
                }
                else
                    StatusUpdate?.Invoke(this, new StatusArgs($"No billing items for Job# {JobHandler.Instance.CurrentJob.JobNumber} yet!"));
            }

            loadProgressBar.Visible = false;
            UpdateTotalTime();
        }

        private void UpdateTotalTime()
        {
            if (selectedListBoxIndex >= 0)
            {
                TimeSpan office = TimeSpan.FromTicks(billingItems.Values.Sum(b => b.Sum(i => i.OfficeTime.Ticks)));
                TimeSpan field = TimeSpan.FromTicks(billingItems.Values.Sum(b => b.Sum(i => i.FieldTime.Ticks)));
                gridHeaderGroup.ValuesPrimary.Heading = "Total Time: " + Utility.ToFullString(office + field);
            }
            else
            {
                gridHeaderGroup.ValuesPrimary.Heading = "Total Time: No time for this day yet!";
            }
        }

        private void PopulateListBox()
        {
            foreach (string key in billingItems.Keys)
            {
                lbTimeEntries.Items.Add(DateTime.Parse(key).Date.ToShortDateString());
            }

            if (lbTimeEntries.Items.Count > 0)
            {
                lbTimeEntries.SelectedIndex = 0;
                selectedListBoxIndex = 0;
            }
            else
            {
                selectedListBoxIndex = -1;
            }

            LoadData();
        }

        private void ChangeStatusText(object sender, EventArgs e)
        {
            if (e is StatusArgs args)
            {
                RuntimeVars.Instance.MainForm.ChangeStatusText(this, args);
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (lbTimeEntries.Items.Contains(now.Date.ToShortDateString()))
            {
                lbTimeEntries.SelectedItem = now.Date.ToShortDateString();
                selectedListBoxIndex = lbTimeEntries.SelectedIndex;
            }
            else
            {
                billingItems.Add(now.Date.ToShortDateString(), new List<BillingItem>());
                lbTimeEntries.Items.Add(now.Date.ToShortDateString());

                lbTimeEntries.SelectedItem = now.Date.ToShortDateString();
                selectedListBoxIndex = lbTimeEntries.SelectedIndex;
            }

            LoadData();
            JobHandler.Instance.UpdateSavePending(true);
        }

        private void btnRemoveTime_Click(object sender, EventArgs e)
        {
            DateTime selected = DateTime.Parse((string)lbTimeEntries.SelectedItem);
            DialogResult result = CMessageBox.Show($"Are you sure you want to remove {selected.Date.ToShortDateString()} from this job? " +
                $"This will remove ALL time entries associated with {selected.Date.ToShortDateString()} from this job and cannot be reversed!",
                "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);

            if (result == DialogResult.No || result == DialogResult.Cancel)
                return;

            billingItems.Remove(selected.ToShortDateString());
            lbTimeEntries.Items.Remove(selected.ToShortDateString());

            lbTimeEntries.SelectedIndex = lbTimeEntries.Items.Count - 1;
            selectedListBoxIndex = lbTimeEntries.SelectedIndex;

            LoadData();
            JobHandler.Instance.UpdateSavePending(true);
        }

        private void lbTimeEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTimeEntries.SelectedIndex >= 0)
            {
                DateTime key = DateTime.Parse((string)lbTimeEntries.Items[lbTimeEntries.SelectedIndex]);
                if (key != null)
                {
                    selectedListBoxIndex = lbTimeEntries.SelectedIndex;
                    LoadData();
                }
            }
        }


        /// <summary>
        /// Occurs when the user deletes a row from the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billingGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]].Contains((BillingItem)e.Row.Tag))
            {
                billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]].Remove((BillingItem)e.Row.Tag);
            }
            JobHandler.Instance.UpdateSavePending(true);
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            NewEntryDlg dialog = new NewEntryDlg(DateTime.Parse((string)lbTimeEntries.Items[selectedListBoxIndex]));
            dialog.TimeEntryAdded += ProcessItem;
            dialog.ShowDialog();
        }

        private void ProcessItem(object sender, EventArgs e)
        {
            if (e is ObjectCreatedEventArgs args)
            {
                BillingItem item = args.DataValue as BillingItem;
                bool isUpdating = (bool)args.Tag;

                if (item == null)
                    return;
                UpdateGrid(item, isUpdating);
            }
        }

        private void UpdateGrid(BillingItem item, bool updating)
        {
            if (updating)
            {
                int itemIndex = billingItems[item.AssociatedDate.Date.ToShortDateString()].IndexOf(item);
                billingItems[item.AssociatedDate.Date.ToShortDateString()][itemIndex] = item;
            }
            else
            {
                billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]].Add(item);
            }
            LoadData();
            JobHandler.Instance.UpdateSavePending(true);
        }

        private void btnEditTime_Click(object sender, EventArgs e)
        {
            if (billingGrid.SelectedRows.Count == 1)
            {
                BillingItem item = billingGrid.SelectedRows[0].Tag as BillingItem;
                NewEntryDlg dialog = new NewEntryDlg(item.AssociatedDate, item, true);
                dialog.TimeEntryAdded += ProcessItem;
                dialog.ShowDialog();
            }
        }

        private void billingGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BillingItem item = billingGrid.Rows[e.RowIndex].Tag as BillingItem;
                NewEntryDlg dialog = new NewEntryDlg(item.AssociatedDate, item, true);
                dialog.TimeEntryAdded += ProcessItem;
                dialog.ShowDialog();
            }
        }

        private void btnSaveAndUpdate_Click(object sender, EventArgs e)
        {
            SaveItems();
        }

        protected override void Dispose(bool disposing)
        {
            //When this user control is disposed (closed), update the currently open job with the new billing line items.
            SaveItems();


            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SaveItems()
        {
            if (!JobHandler.Instance.IsJobOpen)
            {
                StatusUpdate?.Invoke(this, new StatusArgs("Invalid operation: <Save Billing Portal> => Job is not opened!"));
                return;
            }

            List<BillingItem> items = new List<BillingItem>();
            billingItems.Values.ToList().ForEach(p => p.ForEach(q => items.Add(q)));
            JobHandler.Instance.CurrentJob.BillingObject.AddBillingRange(items, true);

            JobHandler.Instance.UpdateSavePending(true);

            StatusUpdate?.Invoke(this, new StatusArgs("Billing for Job# " + JobHandler.Instance.CurrentJob.JobNumber + " updated internally."));
        }
    }
}
