using ComponentFactory.Krypton.Toolkit;
using SSPKeyGen;
using Standard.Licensing;
using SurveyManager.Properties;
using SurveyManager.utility;
using SurveyManager.utility.Licensing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.dialogs
{
    public partial class ActivationDlg : KryptonForm
    {
        public EventHandler LicensingComplete;

        Licensee licensee;
        License license;
        string licensePath = string.Empty;

        bool viewingOrUpdating = false;
        License currentLicense;

        public ActivationDlg()
        {
            InitializeComponent();
            Guid test = HardwareInfo.GenerateUID("SurveyManagerApplication");
            licensee = new Licensee("", "", HardwareInfo.GenerateUID("SurveyManagerApplication"), "");
        }

        public void ShowActivation(License currentLicense)
        {
            if (currentLicense == null)
            {
                rtbGUID.Text = licensee.LicenseGUID.ToString().ToUpper();
                viewingOrUpdating = false;
            }
            else
            {
                rtbGUID.Text = currentLicense.Id.ToString().ToUpper();
                this.currentLicense = currentLicense;
                viewingOrUpdating = true;
            }

            rtbGUID.SelectAll();
            rtbGUID.SelectionAlignment = HorizontalAlignment.Center;
            rtbGUID.DeselectAll();

            ShowDialog();
        }

        private void Activation_Load(object sender, EventArgs e)
        {
            if (viewingOrUpdating)
            {
                radHasLicenseFile.Checked = true;
                license = currentLicense;

                if (license != null)
                {
                    string failures = LicenseEngine.Validate(license);
                    if (!failures.Equals(string.Empty))
                    {
                        SetLicenseLabel(true);
                        CRichMsgBox.Show("Activation Failed. See below for details.", "Failed to Activate", failures, MessageBoxButtons.RetryCancel, Resources.error_64x64);
                    }
                    else
                    {
                        SetLicenseInfo();
                    }
                }
            }
        }

        private void radHasLicenseFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radHasLicenseFile.Checked)
            {
                grpLicenseInfo.Visible = true;
                grpLicenseGUID.Visible = false;
                btnPurchase.Visible = false;
            }
            else
            {
                grpLicenseInfo.Visible = false;
                grpLicenseGUID.Visible = true;
                btnPurchase.Visible = true;
            }
        }

        private void btnBrowseForLicense_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    license = License.Load(File.ReadAllText(dlgOpenFile.FileName));
                }
                catch (Exception)
                {
                    SetLicenseLabel(true);
                    btnFinish.Visible = false;
                    btnPurchase.Visible = false;
                }

                if (license != null)
                {
                    string failures = LicenseEngine.Validate(license);
                    if (!failures.Equals(string.Empty))
                    {
                        SetLicenseLabel(true);
                        CRichMsgBox.Show("Activation Failed. See below for details.", "Failed to Activate", failures, MessageBoxButtons.RetryCancel, Resources.error_64x64);
                    }
                    else
                    {
                        SetLicenseInfo();

                        licensePath = dlgOpenFile.FileName;
                    }
                }
            }
        }

        private void SetLicenseInfo()
        {
            licensee.FullName = license.Customer.Name;
            licensee.Email = license.Customer.Email;
            licensee.CompanyName = license.Customer.Company;
            licensee.PhoneNumber = license.Customer.Get("PhoneNumber");
            licensee.LicenseExpiration = license.Expiration;
            licensee.LicenseUsage = license.Quantity;
            licensee.LicenseType = license.Type == Standard.Licensing.LicenseType.Standard ?
                                    utility.Licensing.LicenseType.FullLicense : utility.Licensing.LicenseType.Trial;
            licensee.LicenseGUID = license.Id;
            pgLicense.SelectedObject = licensee;

            SetLicenseLabel(false);

            if (!viewingOrUpdating)
            {
                radNeedLicenseFile.Enabled = false;
                btnFinish.Visible = true;
                btnBrowseForLicense.Visible = false;
                btnPurchase.Visible = false;
            }
            else
            {
                btnFinish.Visible = true;
                btnBrowseForLicense.Visible = true;
                btnPurchase.Visible = false;
            }
        }

        private void SetLicenseLabel(bool isInvalid)
        {
            if (isInvalid)
            {
                lblLicenseInvalid.Text = "License Invalid! Please select a valid license file.";
                lblLicenseInvalid.StateCommon.ShortText.Color1 = Color.Red;
                lblLicenseInvalid.Visible = true;
            }
            else
            {
                lblLicenseInvalid.Text = "License Valid! You may now safely close this window.";
                lblLicenseInvalid.StateCommon.ShortText.Color1 = Color.Green;
                lblLicenseInvalid.Visible = true;
            }
        }

        private void lnkCopyGUID_LinkClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rtbGUID.Text))
            {
                Clipboard.SetText(rtbGUID.Text);
                lnkCopyGUID.Text = "Copied!";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (viewingOrUpdating)
            {
                string failures = LicenseEngine.Validate(license);
                if (!failures.Equals(string.Empty))
                {
                    SetLicenseLabel(true);
                    CRichMsgBox.Show("Activation Failed. See below for details.", "Failed to Activate", failures, MessageBoxButtons.RetryCancel, Resources.error_64x64);
                    LicensingComplete?.Invoke(this, new LicensingEventArgs(Enums.CloseReasons.Unlicensed));
                    Close();
                }
                else
                {
                    LicensingComplete?.Invoke(this, new LicensingEventArgs(Enums.CloseReasons.Updating));
                    Close();
                }
            }
            else
            {
                if (LicenseEngine.LoadLicense(licensePath))
                {
                    LicensingComplete?.Invoke(this, new LicensingEventArgs(Enums.CloseReasons.Licensed));
                    Close();
                }
                else
                {
                    CMessageBox.Show("Error when trying to load license file.\nPerhaps it moved?", "Could not find license", MessageBoxButtons.OK, Resources.error_64x64);
                }
            }
        }

        private void Activation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.Alt)
            {
                if (e.KeyChar == (char)Keys.F4)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
