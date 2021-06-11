using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu.basicInfo
{
    public partial class LocationCtl : UserControl, IInfoControl
    {
        public bool IsEdited { get; set; } = false;

        public LocationCtl()
        {
            InitializeComponent();
        }

        private void LocationCtl_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (County c in RuntimeVars.Instance.Counties)
                {
                    cmbCounty.Items.Add(c);
                }

                txtStreet.Text = JobHandler.Instance.CurrentJob.Location.Street;
                txtCity.Text = JobHandler.Instance.CurrentJob.Location.City;
                txtZipCode.Text = JobHandler.Instance.CurrentJob.Location.ZipCode;

                if (JobHandler.Instance.CurrentJob.CountyID == 0)
                    cmbCounty.SelectedIndex = 0;
                else
                {
                    cmbCounty.SelectedIndex = cmbCounty.Items.Cast<County>().ToList().FindIndex(e => e.ID == JobHandler.Instance.CurrentJob.CountyID);
                }

                txtStreet.ReadOnly = JobHandler.Instance.ReadOnly;
                txtCity.ReadOnly = JobHandler.Instance.ReadOnly;
                txtZipCode.ReadOnly = JobHandler.Instance.ReadOnly;
                cmbCounty.Enabled = JobHandler.Instance.ReadOnly ? false : true;
                btnSameAsClient.Enabled = JobHandler.Instance.ReadOnly ? false : true;

                IsEdited = true;
            }
            catch (Exception)
            {
                RuntimeVars.Instance.LogFile.AddEntry("Something went wrong while loading the location control on the basic information page. It seems there is not an open survey job?");
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            else
            {
                KryptonComboBox cmb = sender as KryptonComboBox;
                if (cmb != null)
                    cmb.StateCommon.ComboBox.Back.Color1 = Color.FromArgb(255, 255, 128);
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.White;
            else
            {
                KryptonComboBox cmb = sender as KryptonComboBox;
                if (cmb != null)
                    cmb.StateCommon.ComboBox.Back.Color1 = Color.White;
            }
        }

        private void btnSameAsClient_Click(object sender, EventArgs e)
        {
            if (!JobHandler.Instance.CurrentJob.Client.ClientAddress.IsEmpty)
            {
                txtStreet.Text = JobHandler.Instance.CurrentJob.Client.ClientAddress.Street;
                txtCity.Text = JobHandler.Instance.CurrentJob.Client.ClientAddress.City;
                txtZipCode.Text = JobHandler.Instance.CurrentJob.Client.ClientAddress.ZipCode;
            }
            else
            {
                CMessageBox.Show("Either no Client has been selected for this job or the Client's address is empty.", "No Information", MessageBoxButtons.OK, Resources.error_64x64);
            }
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            if (e.KeyChar == '-')
                e.Handled = false;

            JobHandler.Instance.UpdateSavePending(true);
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobHandler.Instance.CurrentJob.CountyID = ((County)cmbCounty.Items[cmbCounty.SelectedIndex]).ID;
            JobHandler.Instance.CurrentJob.County = RuntimeVars.Instance.Counties.Find(e => e.ID == JobHandler.Instance.CurrentJob.CountyID);
        }

        public List<ValidatorError> SaveInfo()
        {
            try
            {
                List<ValidatorError> errors = Validator.Address(new Address(txtStreet.Text, txtCity.Text, txtZipCode.Text));
                errors.AddRange(Validator.County(cmbCounty.SelectedItem as County));

                JobHandler.Instance.CurrentJob.Location.Street = txtStreet.Text;
                JobHandler.Instance.CurrentJob.Location.City = txtCity.Text;
                JobHandler.Instance.CurrentJob.Location.ZipCode = txtZipCode.Text;
                JobHandler.Instance.CurrentJob.County = cmbCounty.SelectedItem as County;

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

        private void cmbCounty_DropDownClosed(object sender, EventArgs e)
        {
            JobHandler.Instance.UpdateSavePending(true);
        }
    }
}
