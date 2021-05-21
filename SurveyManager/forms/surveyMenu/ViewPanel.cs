using ComponentFactory.Krypton.Navigator;
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

namespace SurveyManager.forms.surveyMenu
{
    public partial class ViewPanel : UserControl
    {
        public ViewPanel()
        {
            InitializeComponent();
        }

        private void ViewPanel_Load(object sender, EventArgs e)
        {
            propGrid.SelectedObject = JobHandler.Instance.CurrentJob;

            propGrid.GetAcceptButton().Text = "Refresh";
            propGrid.GetClearButton().Visible = false;
            propGrid.GetAcceptButton().Click += RefreshObject;
            propGrid.GetAcceptButton().Image = Resources.reload_16x16;

            JobHandler.Instance.JobOpened += RefreshObject;
            JobHandler.Instance.JobClosed += ClearObject;
        }

        private void RefreshObject(object sender, EventArgs e)
        {
            propGrid.SelectedObject = JobHandler.Instance.CurrentJob;
            (Parent as KryptonPage).Text = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
            (Parent as KryptonPage).TextTitle = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
            (Parent as KryptonPage).UniqueName = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
            propGrid.Enabled = true;
        }

        private void ClearObject(object sender, EventArgs e)
        {
            if ((JobHandler.Instance.CurrentJobState != Enums.JobState.Opening) 
                || (JobHandler.Instance.CurrentJobState != Enums.JobState.Opened))
            {
                propGrid.SelectedObject = new Survey();
                (Parent as KryptonPage).Text = "No Job Opened";
                (Parent as KryptonPage).TextTitle = "No Job Opened";
                (Parent as KryptonPage).UniqueName = "No Job Opened";
                propGrid.Enabled = false;
            }
        }

        private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!e.OldValue.Equals(e.ChangedItem.Value))
                JobHandler.Instance.UpdateSavePending(true);
        }
    }
}
