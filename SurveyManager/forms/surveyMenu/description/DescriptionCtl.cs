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
    public partial class DescriptionCtl : UserControl
    {
        public DescriptionCtl()
        {
            InitializeComponent();
        }

        private void DescriptionCtl_Load(object sender, EventArgs e)
        {
            txtDescription.Text = RuntimeVars.Instance.OpenJob.Description;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescCharCount.Text = "Char Count: " + txtDescription.Text.Count() + " / 6000";
        }

        
    }
}
