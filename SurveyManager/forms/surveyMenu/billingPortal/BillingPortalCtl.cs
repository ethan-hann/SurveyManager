using ComponentFactory.Krypton.Navigator;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.pages;
using SurveyManager.forms.surveyMenu;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.userControls
{
    public partial class BillingPortalCtl : UserControl
    {
        private bool isOfficeEntry;
        private int selectedListBoxIndex;

        private Dictionary<string, List<BillingItem>> billingItems = new Dictionary<string, List<BillingItem>>();

        public EventHandler StatusUpdate;

        public BillingPortalCtl()
        {
            InitializeComponent();
        }

        private void BillingPortalCtl_Load(object sender, EventArgs e)
        {
            RefreshRates();

            LineItemsCtl lControl = new LineItemsCtl(RuntimeVars.Instance.OpenJob.BillingObject.GetLineItems());
            lControl.Dock = DockStyle.Fill;
            lControl.StatusUpdate += ChangeStatusText;

            pgAdditionalLineItems.Controls.Add(lControl);
            billingGrid.RegisterGroupBoxEvents();
            DataGridViewSetup.SetupDGV(billingGrid, EntityTypes.BillingItem);

            CreateDictionary();
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
            if (selectedListBoxIndex != -1)
            {
                List<BillingItem> items = billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]];
                OutlookGridRow row;
                rows = new List<OutlookGridRow>();
                
                foreach (BillingItem item in items)
                {
                    row = new OutlookGridRow();
                    row.CreateCells(billingGrid, new object[] {
                        item.ID,
                        item.Description,
                        item.FieldRate,
                        item.OfficeRate,
                        Utility.ToFullString(item.FieldTime),
                        Utility.ToFullString(item.OfficeTime)
                    });
                    row.Tag = item;
                    rows.Add(row);
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
                StatusUpdate?.Invoke(this, new StatusArgs($"Billing Details for {(DateTime.Parse((string)lbTimeEntries.Items[selectedListBoxIndex])).Date.ToShortDateString()} loaded."));
                billingGrid.SuspendLayout();
                billingGrid.ClearInternalRows();
                billingGrid.ResumeLayout();
                billingGrid.AssignRows(rows);
                billingGrid.ForceRefreshGroupBox();
                billingGrid.Fill();
            }

            loadProgressBar.Visible = false;
            UpdateTotalTime();
        }

        private void UpdateTotalTime()
        {
            if (selectedListBoxIndex >= 0)
            {
                TimeSpan office = TimeSpan.FromTicks(billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]].Sum(b => b.OfficeTime.Ticks));
                TimeSpan field = TimeSpan.FromTicks(billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]].Sum(b => b.FieldTime.Ticks));
                lblTotalTime.Text = "Total Time: " + Utility.ToFullString(office + field);
            }
            else
            {
                lblTotalTime.Text = "Total Time: " + Utility.ToFullString(RuntimeVars.Instance.OpenJob.BillingObject.GetTotalTime());
            }
        }

        /// <summary>
        /// Converts a list of billing items into a dictionary with the key being the date of the billing item and the value being a list
        /// of billing items for that date.
        /// </summary>
        private void CreateDictionary()
        {
            List<BillingItem> originalItems = RuntimeVars.Instance.OpenJob.BillingObject.GetBillingItems();
            List<BillingItem> itemsToAdd;
            bool[] addedItems = new bool[originalItems.Count];

            for (int i = 0; i < originalItems.Count; i++)
            {
                itemsToAdd = new List<BillingItem>();
                BillingItem item = originalItems[i];
                DateTime date = item.AssociatedDate;

                for (int j = 1; j < originalItems.Count; j++)
                {
                    BillingItem nextItem = originalItems[j];

                    if (nextItem.AssociatedDate.Equals(date) & addedItems[j] == false)
                    {
                        addedItems[j] = true;
                        itemsToAdd.Add(nextItem);
                    }
                }
                if (addedItems[i] == false)
                {
                    itemsToAdd.Add(item);
                    addedItems[i] = true;
                }
                
                if (!billingItems.ContainsKey(date.Date.ToShortDateString()))
                    billingItems.Add(date.Date.ToShortDateString(), itemsToAdd);
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

        private void btnAddNewRate_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                StatusUpdate?.Invoke(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new NewPage(EntityTypes.Rate);
            RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void btnSaveTimeEntry_Click(object sender, EventArgs e)
        {
            
        }

        private void radOfficeTime_CheckedChanged(object sender, EventArgs e)
        {
            isOfficeEntry = radOfficeTime.Checked;
        }

        private void btnRefreshRates_Click(object sender, EventArgs e)
        {
            RefreshRates();
        }

        private void RefreshRates()
        {
            cmbRates.DataSource = Database.GetRates();
            if (cmbRates.Items.Count <= 0)
            {
                cmbRates.Items.Add("No rates yet! Click the button to create a new one.");
            }
            cmbRates.SelectedIndex = 0;
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

            UpdateControls();
        }

        private void btnRemoveTime_Click(object sender, EventArgs e)
        {
            DateTime selected = DateTime.Parse((string)lbTimeEntries.SelectedItem);
            DialogResult result = CMessageBox.Show($"Are you sure you want to remove {selected.Date.ToShortDateString()} from this job? This will remove ALL time entries associated with {selected.Date.ToShortDateString()} from the job!", "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);
            if (result == DialogResult.No || result == DialogResult.Cancel)
                return;

            billingItems.Remove(selected.ToShortDateString());
            lbTimeEntries.Items.Remove(selected.ToShortDateString());

            lbTimeEntries.SelectedIndex = lbTimeEntries.Items.Count - 1;
            selectedListBoxIndex = lbTimeEntries.SelectedIndex;

            UpdateControls();
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

        private void btnAddTimeEntry_Click(object sender, EventArgs e)
        {
            BillingItem item = new BillingItem();
            item.AssociatedDate = DateTime.Parse((string)lbTimeEntries.Items[selectedListBoxIndex]);
            item.Description = rtbDescription.Text;
            item.OfficeRate = (Rate)cmbRates.SelectedItem;
            item.OfficeRateId = item.OfficeRate.ID;
            item.FieldRate = (Rate)cmbRates.SelectedItem;
            item.FieldRateId = item.FieldRate.ID;

            if (isOfficeEntry)
            {
                item.OfficeTime = TimeSpan.FromTicks(dtpTimeEntry.Value.Ticks);
                item.FieldTime = TimeSpan.Zero;
            }
            else
            {
                item.FieldTime = TimeSpan.FromTicks(dtpTimeEntry.Value.Ticks);
                item.OfficeTime = TimeSpan.Zero;
            }

            if (item.IsValidItem)
            {
                billingItems[(string)lbTimeEntries.Items[selectedListBoxIndex]].Add(item);
                LoadData();
            }
            else
            {
                CMessageBox.Show("Not enough information to add new entry. " + 
                    DatabaseError.BillingItemIncomplete.ToDescriptionString(), "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
        }

        private void UpdateControls()
        {
            radOfficeTime.Checked = true;
            if (cmbRates.Items.Count > 0)
                cmbRates.SelectedIndex = 0;

            dtpTimeEntry.Value = DateTime.MinValue;
            LoadData();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescCharCount.Text = "Char. Count: " + rtbDescription.Text.Count() + " / 255";
        }

        private void billingGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }
    }
}
