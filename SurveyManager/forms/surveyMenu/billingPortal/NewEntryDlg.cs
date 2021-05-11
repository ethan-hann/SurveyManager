using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.pages;
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

namespace SurveyManager.forms.surveyMenu.billingPortal
{
    public partial class NewEntryDlg : KryptonForm
    {
        private bool isOfficeEntry;
        private bool isEditing;

        private DateTime associatedDate;
        private readonly BillingItem oldItem;

        public EventHandler TimeEntryAdded;

        public NewEntryDlg(DateTime associatedDate, BillingItem oldItem = null, bool isEditing = false)
        {
            InitializeComponent();

            this.associatedDate = associatedDate;
            this.oldItem = oldItem;
            this.isEditing = isEditing;

            if (this.oldItem != null)
                isEditing = true;

            if (isEditing)
            {
                Text = $"Editing Time Entry: {this.oldItem.ID} - {this.oldItem.AssociatedDate.Date.ToShortDateString()}";
            }
        }

        private void NewEntryDlg_Load(object sender, EventArgs e)
        {
            RefreshRates();

            if (isEditing)
            {
                SetControls(oldItem);
            }
            else
            {
                ResetControls();
            }

            btnSaveEntry.Click += SaveEntry;
            btnReset.Click += Reset;
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

        private void SaveEntry(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (UpdateTimeEntry())
                {
                    Close();
                }
            }
            else
            {
                if (AddTimeEntry())
                {
                    Close();
                }
            }
        }

        private void Reset(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void radOfficeTime_CheckedChanged(object sender, EventArgs e)
        {
            isOfficeEntry = radOfficeTime.Checked;
        }

        private void btnRefreshRates_Click(object sender, EventArgs e)
        {
            RefreshRates();
        }


        private void btnAddTimeEntry_Click(object sender, EventArgs e)
        {
            if (AddTimeEntry())
            {
                Close();
            }
        }

        private void btnAddNewRate_Click(object sender, EventArgs e)
        {
            if (RuntimeVars.Instance.DatabaseConnected)
            {
                KryptonPage page = new NewPage(EntityTypes.Rate);
                RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.AddFloatingWindow("Floating", new KryptonPage[] { page });
                RuntimeVars.Instance.SelectedPageUniqueName = page.UniqueName;
            }
        }

        private bool AddTimeEntry()
        {
            BillingItem item = new BillingItem();
            item.AssociatedDate = associatedDate;
            item.Description = rtbDescription.Text;
            item.OfficeRate = (Rate)cmbRates.SelectedItem;
            item.OfficeRateId = item.OfficeRate.ID;
            item.FieldRate = (Rate)cmbRates.SelectedItem;
            item.FieldRateId = item.FieldRate.ID;

            if (isOfficeEntry)
            {
                item.OfficeTime = new TimeSpan(dtpTimeEntry.Value.Hour, dtpTimeEntry.Value.Minute, dtpTimeEntry.Value.Second);
                item.FieldTime = TimeSpan.Zero;
            }
            else
            {
                item.FieldTime = new TimeSpan(dtpTimeEntry.Value.Hour, dtpTimeEntry.Value.Minute, dtpTimeEntry.Value.Second);
                item.OfficeTime = TimeSpan.Zero;
            }

            if (item.IsValidItem)
            {
                TimeEntryAdded?.Invoke(this, new ObjectCreatedEventArgs(item, false));
                return true;
            }
            else
            {
                CMessageBox.Show("Not enough information to add new entry. " +
                    DatabaseError.BillingItemIncomplete.ToDescriptionString(), "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return false;
            }
        }

        private bool UpdateTimeEntry()
        {
            oldItem.AssociatedDate = associatedDate;
            oldItem.Description = rtbDescription.Text;
            oldItem.OfficeRate = (Rate)cmbRates.SelectedItem;
            oldItem.OfficeRateId = oldItem.OfficeRate.ID;
            oldItem.FieldRate = (Rate)cmbRates.SelectedItem;
            oldItem.FieldRateId = oldItem.FieldRate.ID;

            if (isOfficeEntry)
            {
                oldItem.OfficeTime = (associatedDate + dtpTimeEntry.Value.TimeOfDay).TimeOfDay;
                oldItem.FieldTime = TimeSpan.Zero;
            }
            else
            {
                oldItem.FieldTime = (associatedDate + dtpTimeEntry.Value.TimeOfDay).TimeOfDay;
                oldItem.OfficeTime = TimeSpan.Zero;
            }

            if (oldItem.IsValidItem)
            {
                TimeEntryAdded?.Invoke(this, new ObjectCreatedEventArgs(oldItem, true));
                return true;
            }
            else
            {
                CMessageBox.Show("Not enough information to update entry. " +
                    DatabaseError.BillingItemIncomplete.ToDescriptionString(), "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return false;
            }
        }

        /// <summary>
        /// Reset the values of the controls to their default (base) values.
        /// </summary>
        private void ResetControls()
        {
            radOfficeTime.Checked = true;
            if (cmbRates.Items.Count > 0)
                cmbRates.SelectedIndex = 0;

            rtbDescription.Text = "";

            dtpTimeEntry.Value = associatedDate;
        }

        /// <summary>
        /// Set's the values of the controls to that of the specified billing item.
        /// </summary>
        /// <param name="item">The item to set the controls to.</param>
        private void SetControls(BillingItem item)
        {
            ResetControls();

            radOfficeTime.Checked = item.OfficeTime != TimeSpan.Zero;
            radFieldTime.Checked = !radOfficeTime.Checked;

            if (radOfficeTime.Checked)
            {
                foreach (object o in cmbRates.Items)
                {
                    if ((o as Rate).ID == item.OfficeRate.ID)
                        cmbRates.SelectedItem = o;
                }
            }
            else
            {
                foreach (object o in cmbRates.Items)
                {
                    if ((o as Rate).ID == item.FieldRate.ID)
                        cmbRates.SelectedItem = o;
                }
            }

            rtbDescription.Text = item.Description;

            if (radOfficeTime.Checked)
            {
                DateTime d = dtpTimeEntry.Value;
                TimeSpan t = item.OfficeTime;
                dtpTimeEntry.Value = d.Date + t;
            }
            else
            {
                DateTime d = dtpTimeEntry.Value;
                TimeSpan t = item.FieldTime;
                dtpTimeEntry.Value = d.Date + t;
            }

            lblFormatBold.Text = $"{dtpTimeEntry.Value.Hour} hour(s) : {dtpTimeEntry.Value.Minute} minute(s) : {dtpTimeEntry.Value.Second} second(s)";
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescCharCount.Text = "Char. Count: " + rtbDescription.Text.Count() + " / 255";
        }

        private void radOfficeTime_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Indicates that this is an office time entry.";
        }

        private void ResetHelpText(object sender, EventArgs e)
        {
            lblHelpText.Text = "";
        }

        private void radFieldTime_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Indicates that this is a field time entry.";
        }

        private void dtpTimeEntry_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Specifiy the time for this entry. The format is specified below the time.";
        }

        private void cmbRates_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Select the rate that should be applied to this time entry.";
        }

        private void btnRefreshRates_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Reload all of the rates from the database; useful if a rate was added or changed while this dialog was open.";
        }

        private void btnAddNewRate_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Open the new rate page to add a new rate to the database.";
        }

        private void rtbDescription_MouseEnter(object sender, EventArgs e)
        {
            lblHelpText.Text = "Enter a short description (max. 255 characters) describing this time entry. This description can be left empty if not needed.";
        }

        private void dtpTimeEntry_ValueChanged(object sender, EventArgs e)
        {
            lblFormatBold.Text = $"{dtpTimeEntry.Value.Hour} hour(s) : {dtpTimeEntry.Value.Minute} minute(s) : {dtpTimeEntry.Value.Second} second(s)";
        }
    }
}
