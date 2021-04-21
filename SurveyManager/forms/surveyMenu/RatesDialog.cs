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
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.surveyMenu
{
    public partial class RatesDialog : KryptonForm
    {
        public EventHandler StatusUpdate;

        public RatesDialog()
        {
            InitializeComponent();
        }

        private void RatesDialog_Load(object sender, EventArgs e)
        {
            Text = "Rates for Job# " + RuntimeVars.Instance.OpenJob.JobNumber;
            txtOfficeRate.Text = RuntimeVars.Instance.OpenJob.OfficeRate.ToString("C2");
            txtFieldRate.Text = RuntimeVars.Instance.OpenJob.FieldRate.ToString("C2");

            btnUpdateRates.Click += UpdateRates;
        }

        private void UpdateRates(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtOfficeRate.Text, out decimal officeRate))
            {
                if (decimal.TryParse(txtFieldRate.Text, out decimal fieldRate))
                {
                    if (RuntimeVars.Instance.OpenJob.OfficeRate != officeRate || RuntimeVars.Instance.OpenJob.FieldRate != fieldRate)
                    {
                        RuntimeVars.Instance.OpenJob.SavePending = true;
                        RuntimeVars.Instance.OpenJob.OfficeRate = officeRate;
                        RuntimeVars.Instance.OpenJob.FieldRate = fieldRate;
                        StatusUpdate?.Invoke(this, new StatusArgs("Rates updated for Job# " + RuntimeVars.Instance.OpenJob.JobNumber + ". Office Rate=" + officeRate.ToString("C2") + " per hour; Field Rate=" + fieldRate.ToString("C2")));
                    }
                    else
                    {
                        StatusUpdate?.Invoke(this, new StatusArgs("No rates were changed therefore there is nothing to save."));
                    }
                    Close();
                }
                else
                {
                    StatusUpdate?.Invoke(this, new StatusArgs("Could not update the field rate for Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " with the rate " + fieldRate));
                }
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs("Could not update the office rate for Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " with the rate " + officeRate));
            }
        }

        private void txtOfficeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get decimal separator according your computer settings
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (e.KeyChar == decimalSeparator) // If the decimal separator key is pressed
            {
                // When the whole number is selected and contains decimal separator
                // allow to enter decimal separator
                if ((txtOfficeRate.SelectionLength > 0) && txtOfficeRate.Text.Contains(decimalSeparator))
                {
                    txtOfficeRate.Text = "0";
                    e.Handled = false;
                    txtOfficeRate.SelectionStart = txtOfficeRate.TextLength;
                }
                else if (txtOfficeRate.Text.Length == 0)
                {
                    // If decimal separator key is pressed in the very beginning
                    // then a zero is inserted before it
                    txtOfficeRate.Text = "0" + decimalSeparator;
                    e.Handled = true;
                    txtOfficeRate.SelectionStart = txtOfficeRate.TextLength;
                }
                // If text box contains decimal separator, then
                else if (txtOfficeRate.Text.Contains(decimalSeparator))
                    e.Handled = true;     // cancel the key press
            }
            // If the input is different from control key and digit key
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press
            }
        }

        private void txtFieldRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get decimal separator according your computer settings
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (e.KeyChar == decimalSeparator) // If the decimal separator key is pressed
            {
                // When the whole number is selected and contains decimal separator
                // allow to enter decimal separator
                if ((txtFieldRate.SelectionLength > 0) && txtFieldRate.Text.Contains(decimalSeparator))
                {
                    txtFieldRate.Text = "0";
                    e.Handled = false;
                    txtFieldRate.SelectionStart = txtFieldRate.TextLength;
                }
                else if (txtFieldRate.Text.Length == 0)
                {
                    // If decimal separator key is pressed in the very beginning
                    // then a zero is inserted before it
                    txtFieldRate.Text = "0" + decimalSeparator;
                    e.Handled = true;
                    txtFieldRate.SelectionStart = txtFieldRate.TextLength;
                }
                // If text box contains decimal separator, then
                else if (txtFieldRate.Text.Contains(decimalSeparator))
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
