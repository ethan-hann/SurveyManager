using ComponentFactory.Krypton.Toolkit;
using SurveyManager.Properties;
using System;
using System.Windows.Forms;

namespace SurveyManager.forms.dialogs
{
    public partial class EllipterActivation : KryptonForm
    {
        public EventHandler SettingsSaved;

        public EllipterActivation()
        {
            InitializeComponent();

            btnActivate.Click += BtnActivate_Click;
        }

        private void BtnActivate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtKey.Text.Length > 0)
            {
                Settings.Default.DeveloperName = txtName.Text;
                Settings.Default.DeveloperKey = txtKey.Text;
                Settings.Default.Save();

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                CMessageBox.Show("Fields cannot be empty!", "Invalid Input", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
        }
    }
}
