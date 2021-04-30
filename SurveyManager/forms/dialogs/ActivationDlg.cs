using ComponentFactory.Krypton.Toolkit;
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
        private LicenseInfo info;

        public EventHandler LicensingComplete;

        public ActivationDlg()
        {
            InitializeComponent();
        }

        private void Activation_Load(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, 168);
            if (Settings.Default.ProductKey.Equals("Unlicensed"))
            {
                info = LicenseInfo.CreateUnlicensedInfo();
                lblActivationStatus.Text = "Status: No valid product key was found.";
            }
            else
            {
                info = LicenseEngine.GetLicenseInfo(Settings.Default.ProductKey);
                if (info.IsEmpty)
                    lblActivationStatus.Text = "Status: No valid product key was found.";
                else
                {
                    txtProductKey.Text = Settings.Default.ProductKey.Substring(0, 15) + "******-******-...";
                    lblActivationStatus.Text = "Status: Product activated. No further action needed.";
                    Size = new Size(Size.Width, 370);
                }
            }

            infoPropGrid.SelectedObject = info;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtProductKey.Text.Length <= 0)
            {
                CMessageBox.Show("Product Key cannot be empty!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                lblActivationStatus.Text = "Status: The product key was empty.";
                Size = new Size(Size.Width, 168);
                return;
            }

            LicenseInfo temp = LicenseEngine.GetLicenseInfo(txtProductKey.Text);
            if (!temp.IsEmpty)
            {
                if (temp.Type == utility.Licensing.LicenseType.Trial)
                {
                    if (DateTime.Now.Date >= temp.ExpirationDate.Date)
                    {
                        CMessageBox.Show($"Trial key is no longer valid for use. " +
                        $"It expired on: {temp.ExpirationDate.Date.ToShortDateString()}. " +
                        "You can request a new one by using the \"Purchase New Product Key\" button.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                        lblActivationStatus.Text = "Status: Invalid trial key; expired.";
                        return;
                    }
                }

                lblActivationStatus.Text = "Status: Successful!";
                Settings.Default.ProductKey = txtProductKey.Text;
                Settings.Default.Save();
                info = temp;

                infoPropGrid.SelectedObject = info;
                Size = new Size(Size.Width, 370);
            }
            else
            {
                CMessageBox.Show("Invalid product key!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                lblActivationStatus.Text = "Status: The product key you entered was invalid.";
                Size = new Size(Size.Width, 168);
                return;
            }
        }

        private void ActivationDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Enums.CloseReasons reason =
                    (info.Type == utility.Licensing.LicenseType.FullLicense || info.Type == utility.Licensing.LicenseType.Trial) ?
                    Enums.CloseReasons.Licensed : Enums.CloseReasons.Unlicensed;
            LicensingComplete?.Invoke(this, new LicensingEventArgs(info, reason));
        }
    }
}
