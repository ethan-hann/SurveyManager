using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SurveyManager.forms.surveyMenu.description
{
    public partial class DescriptionCtl : UserControl, IInfoControl
    {
        public bool IsEdited { get; set; }

        public DescriptionCtl()
        {
            InitializeComponent();
        }

        public bool SaveInfo()
        {
            if (txtDescription.Text.Length == 0)
            {
                CMessageBox.Show("The job's description cannot be empty!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return false;
            }

            JobHandler.Instance.CurrentJob.Description = txtDescription.Text;
            return true;
        }

        private void DescriptionCtl_Load(object sender, EventArgs e)
        {
            txtDescription.Text = JobHandler.Instance.CurrentJob.Description;
            IsEdited = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescCharCount.Text = "Char Count: " + txtDescription.Text.Count() + " / 6000";
        }

        private void JobModified(object sender, KeyPressEventArgs e)
        {
            JobHandler.Instance.UpdateSavePending(true);
        }
    }
}
