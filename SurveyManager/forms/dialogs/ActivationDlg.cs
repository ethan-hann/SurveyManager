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
                    lblActivationStatus.Text = "Status: Product activated. No further action needed.";
            }
                

            infoPropGrid.SelectedObject = info;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            info = LicenseEngine.GetLicenseInfo(txtProductKey.Text);
            if (info.IsEmpty)
                lblActivationStatus.Text = "Status: The product key you entered was invalid.";
            else
            {
                lblActivationStatus.Text = "Status: Successful!";
                Settings.Default.ProductKey = txtProductKey.Text;
            }

            infoPropGrid.SelectedObject = info;
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
