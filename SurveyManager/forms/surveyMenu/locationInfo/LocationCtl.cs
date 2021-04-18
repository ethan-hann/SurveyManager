using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
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

namespace SurveyManager.forms.surveyMenu.locationInfo
{
    public partial class LocationCtl : UserControl, IInfoControl
    {
        public LocationCtl()
        {
            InitializeComponent();
        }

        private void LocationCtl_Load(object sender, EventArgs e)
        {
            cmbCounty.DataSource = RuntimeVars.Instance.Counties;

            txtStreet.Text = RuntimeVars.Instance.OpenJob.Location.Street;
            txtCity.Text = RuntimeVars.Instance.OpenJob.Location.City;
            txtZipCode.Text = RuntimeVars.Instance.OpenJob.Location.ZipCode;

            if (RuntimeVars.Instance.OpenJob.County.CountyName.Equals(""))
                cmbCounty.SelectedIndex = 0;
            else
                cmbCounty.SelectedItem = RuntimeVars.Instance.OpenJob.County;
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
            if (!RuntimeVars.Instance.OpenJob.Client.ClientAddress.IsEmpty)
            {
                txtStreet.Text = RuntimeVars.Instance.OpenJob.Client.ClientAddress.Street;
                txtCity.Text = RuntimeVars.Instance.OpenJob.Client.ClientAddress.City;
                txtZipCode.Text = RuntimeVars.Instance.OpenJob.Client.ClientAddress.ZipCode;
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
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            RuntimeVars.Instance.OpenJob.County = cmbCounty.SelectedItem as County;
        }

        public bool SaveInfo()
        {
            if ((txtStreet.Text.Length > 0 && !txtStreet.Text.Equals("N/A")) && 
                (txtCity.Text.Length > 0 && !txtCity.Text.Equals("N/A")) && 
                (txtZipCode.Text.Length > 0))
            {
                RuntimeVars.Instance.OpenJob.Location.Street = txtStreet.Text;
                RuntimeVars.Instance.OpenJob.Location.City = txtCity.Text;
                RuntimeVars.Instance.OpenJob.Location.ZipCode = txtZipCode.Text;

                return true;
            }
            else
            {
                CMessageBox.Show("The job's location cannot be empty!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return false;
            }
        }
    }
}
