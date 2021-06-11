using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend;
using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

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
            propGrid.GetAcceptButton().Text = "Refresh";
            propGrid.GetClearButton().Visible = false;
            propGrid.GetAcceptButton().Click += RefreshButton;
            propGrid.GetAcceptButton().Image = Resources.reload_16x16;

            JobHandler.Instance.JobOpened += RefreshObject;
            JobHandler.Instance.JobClosed += ClearObject;

            RefreshObject(sender, e);
        }

        public void CreateEmptyJob()
        {
            if (propGrid == null)
                return;

            try
            {
                propGrid.SelectedObject = new Survey();
                KryptonPage parent = (KryptonPage)Parent;
                if (parent == null)
                    return;

                parent.Text = "No Job Opened";
                parent.TextTitle = "No Job Opened";
                parent.UniqueName = "No Job Opened";
                propGrid.Enabled = false;
            }
            catch (NullReferenceException e)
            {
                RuntimeVars.Instance.MainForm.ChangeStatusText(this, new StatusArgs($"An exception has occured: {e.Message}. See the log file for full details."));
                RuntimeVars.Instance.LogFile.AddEntry($"An exception occured: {e.Message}. The stacktrace is: {e.StackTrace}");
            }
        }

        private void RefreshObject(object sender, EventArgs e)
        {
            if (propGrid == null)
                return;

            try
            {
                if (JobHandler.Instance.CurrentJobState == Enums.JobState.Opened)
                {
                    propGrid.SelectedObject = Database.GetSurvey(JobHandler.Instance.CurrentJob.JobNumber);
                    if (propGrid.SelectedObject == null)
                    {
                        propGrid.SelectedObject = new Survey();
                    }

                    KryptonPage parent = (KryptonPage)Parent;
                    if (parent == null)
                        return;

                    parent.Text = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
                    parent.TextTitle = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
                    parent.UniqueName = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
                    propGrid.Enabled = !JobHandler.Instance.ReadOnly;
                }
                else
                {
                    RefreshButton(sender, e);
                }
            } catch (NullReferenceException n)
            {
                RuntimeVars.Instance.MainForm.ChangeStatusText(this, new StatusArgs($"An exception has occured: {n.Message}. See the log file for full details."));
                RuntimeVars.Instance.LogFile.AddEntry($"An exception occured: {n.Message}. The stacktrace is: {n.StackTrace}");
            }
        }

        private void RefreshButton(object sender, EventArgs e)
        {
            try
            {
                if (JobHandler.Instance.IsJobOpen)
                {
                    propGrid.SelectedObject = Database.GetSurvey(JobHandler.Instance.CurrentJob.JobNumber);
                    if (propGrid.SelectedObject == null)
                    {
                        propGrid.SelectedObject = JobHandler.Instance.CurrentJob;
                    }
                    KryptonPage parent = (KryptonPage)Parent;
                    if (parent == null)
                        return;

                    parent.Text = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
                    parent.TextTitle = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
                    parent.UniqueName = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info";
                    propGrid.Enabled = !JobHandler.Instance.ReadOnly;
                }
            } catch (NullReferenceException n)
            {
                RuntimeVars.Instance.MainForm.ChangeStatusText(this, new StatusArgs($"An exception has occured: {n.Message}. See the log file for full details."));
                RuntimeVars.Instance.LogFile.AddEntry($"An exception occured: {n.Message}. The stacktrace is: {n.StackTrace}");
            }
        }

        private void ClearObject(object sender, EventArgs e)
        {
            if (propGrid == null)
                return;

            if ((JobHandler.Instance.CurrentJobState != Enums.JobState.Opening)
                || (JobHandler.Instance.CurrentJobState != Enums.JobState.Opened))
            {
                CreateEmptyJob();
            }
        }

        private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (propGrid == null || propGrid.SelectedObject == null)
                return;

            if (!e.OldValue.Equals(e.ChangedItem.Value))
                JobHandler.Instance.UpdateSavePending(true);
        }

        private void propGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            propGrid.Invalidate();
            propGrid.Update();
        }
    }
}
