using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
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

namespace SurveyManager.forms.surveyMenu
{
    public partial class SurveySearchResults : KryptonForm
    {
        private DataTable surveys;

        public EventHandler StatusUpdate;
        public EventHandler SurveyOpened;

        public SurveySearchResults(DataTable surveys)
        {
            InitializeComponent();

            this.surveys = surveys;
        }

        private void SurveySearchResults_Load(object sender, EventArgs e)
        {
            propGrid.GetAcceptButton().Text = "Open Job";
            propGrid.GetClearButton().Visible = false;
            propGrid.GetAcceptButton().Click += OpenJob;

            lbJobs.DisplayMember = "JobNumber";

            Icon = Icon.FromHandle(Resources.surveying_16x16.GetHicon());

            PopulateListBox();
        }

        private void PopulateListBox()
        {
            foreach (DataRow row in surveys.Rows)
            {
                lbJobs.Items.Add(ProcessDataTable.GetSurvey(row));
            }

            if (lbJobs.Items.Count > 0)
            {
                lbJobs.SelectedIndex = 0;
                propGrid.SelectedObject = lbJobs.Items[0];
            }
        }

        private void OpenJob(object sender, EventArgs e)
        {
            if (JobHandler.Instance.OpenJob(propGrid.SelectedObject as Survey))
            {
                SurveyOpened?.Invoke(this, new SurveyOpenedEventArgs(JobHandler.Instance.CurrentJob));
                Close();
            }
        }

        private void lbJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbJobs.SelectedIndex >= 0)
                propGrid.SelectedObject = lbJobs.Items[lbJobs.SelectedIndex];
        }
    }
}
