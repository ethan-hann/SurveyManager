using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend;
using SurveyManager.forms.pages;
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

        public EventHandler StatusUpdate;

        public BillingPortalCtl()
        {
            InitializeComponent();
        }

        private void BillingPortalCtl_Load(object sender, EventArgs e)
        {
            RefreshRates();


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
    }
}
