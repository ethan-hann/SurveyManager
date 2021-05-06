using SurveyManager.forms.dialogs;
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

            RuntimeVars.Instance.OpenJob.Description = txtDescription.Text;
            return true;
        }

        private void DescriptionCtl_Load(object sender, EventArgs e)
        {
            txtDescription.Text = RuntimeVars.Instance.OpenJob.Description;
            IsEdited = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescCharCount.Text = "Char Count: " + txtDescription.Text.Count() + " / 6000";
        }
    }
}
