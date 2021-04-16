using ComponentFactory.Krypton.Toolkit;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyManager.forms.surveyMenu.jobInfo
{
    public partial class EssentialInformationCtl : UserControl
    {
        public EssentialInformationCtl()
        {
            InitializeComponent();
        }

        private void JobInfoCtl_Load(object sender, EventArgs e)
        {
            txtJobNumber.Text = RuntimeVars.Instance.OpenJob.JobNumber;
            txtAbstract.Text = RuntimeVars.Instance.OpenJob.AbstractNumber;
            txtSurvey.Text = RuntimeVars.Instance.OpenJob.SurveyName;
            txtNumOfAcres.Text = RuntimeVars.Instance.OpenJob.Acres.ToString();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.White;
        }

        private void txtNumOfAcres_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNumOfAcres.Text, out double acres))
            {
                RuntimeVars.Instance.OpenJob.Acres = acres;
            }
        }

        private void txtNumOfAcres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get decimal separator according your computer settings
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (e.KeyChar == decimalSeparator) // If the decimal separator key is pressed
            {
                // When the whore number is selected and contains decimal separator
                // allow to enter decimal separator
                if ((txtNumOfAcres.SelectionLength > 0) && txtNumOfAcres.Text.Contains(decimalSeparator))
                {
                    txtNumOfAcres.Text = "0";
                    e.Handled = false;
                    txtNumOfAcres.SelectionStart = txtNumOfAcres.TextLength;
                }
                else if (txtNumOfAcres.Text.Length == 0)
                {
                    // If decimal separator key is pressed in the very beginning
                    // then a zero is inserted before it
                    txtNumOfAcres.Text = "0" + decimalSeparator;
                    e.Handled = true;
                    txtNumOfAcres.SelectionStart = txtNumOfAcres.TextLength;
                }
                // If text box contains decimal separator, then
                else if (txtNumOfAcres.Text.Contains(decimalSeparator))
                    e.Handled = true;     // cancel the key press
            }
            // If the input is different from control key and digit key
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }
    }
}
