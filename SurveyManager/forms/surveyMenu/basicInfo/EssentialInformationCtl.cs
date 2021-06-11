using ComponentFactory.Krypton.Toolkit;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu.basicInfo
{
    public partial class EssentialInformationCtl : UserControl, IInfoControl
    {
        public bool IsEdited { get; set; } = false;

        public EssentialInformationCtl()
        {
            InitializeComponent();
        }

        private void EssentialInformationCtl_Load(object sender, EventArgs e)
        {
            txtJobNumber.Text = JobHandler.Instance.CurrentJob.JobNumber;
            txtAbstract.Text = JobHandler.Instance.CurrentJob.AbstractNumber;
            txtSurvey.Text = JobHandler.Instance.CurrentJob.SurveyName;
            txtNumOfAcres.Text = JobHandler.Instance.CurrentJob.Acres.ToString();

            txtJobNumber.ReadOnly = JobHandler.Instance.ReadOnly;
            txtAbstract.ReadOnly = JobHandler.Instance.ReadOnly;
            txtSurvey.ReadOnly = JobHandler.Instance.ReadOnly;
            txtNumOfAcres.ReadOnly = JobHandler.Instance.ReadOnly;

            txtDescription.Text = JobHandler.Instance.CurrentJob.Description;
            txtDescription.ReadOnly = JobHandler.Instance.ReadOnly;


            IsEdited = true;
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
                JobHandler.Instance.CurrentJob.Acres = acres;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblDescCharCount.Text = "Char Count: " + txtDescription.Text.Count() + " / 6000";
        }

        private void txtNumOfAcres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get decimal separator according your computer settings
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (e.KeyChar == decimalSeparator) // If the decimal separator key is pressed
            {
                // When the whole number is selected and contains decimal separator
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

            JobHandler.Instance.UpdateSavePending(true);
        }

        public List<ValidatorError> SaveInfo()
        {
            try
            {
                double.TryParse(txtNumOfAcres.Text, out double acres);

                List<ValidatorError> errors = Validator.Information(txtJobNumber.Text, txtAbstract.Text, txtSurvey.Text, acres);
                errors.AddRange(Validator.Description(txtDescription.Text));

                JobHandler.Instance.CurrentJob.JobNumber = txtJobNumber.Text;
                JobHandler.Instance.CurrentJob.AbstractNumber = txtAbstract.Text;
                JobHandler.Instance.CurrentJob.SurveyName = txtSurvey.Text;
                JobHandler.Instance.CurrentJob.Acres = acres;
                JobHandler.Instance.CurrentJob.Description = txtDescription.Text;

                return errors;

            } catch (NullReferenceException e)
            {
                RuntimeVars.Instance.LogFile.AddEntry($"An exception has occured: {e.Message}. The stacktrace is: {e.StackTrace}");
                return new List<ValidatorError>() { ValidatorError.Exception };
            }
        }

        private void JobModified(object sender, KeyPressEventArgs e)
        {
            JobHandler.Instance.UpdateSavePending(true);
        }
    }
}
