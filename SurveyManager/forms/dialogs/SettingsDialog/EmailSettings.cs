using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Windows.Forms;
using System.Linq;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.dialogs.SettingsDialog
{
    public partial class EmailSettings : UserControl, ISettingsControl
    {
        public event ISettingsControl.ChangeStatusText HelpTextChanged;
        public string UniqueName { get => "email"; }

        public bool Unchanged { get; set; } = true;

        public EmailSettings()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Load the current settings, or defaults if no settings exist yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailSettings_Load(object sender, EventArgs e)
        {
            txtFromAddress.Text = Settings.Default.MailFromAddress;
            txtSMTPServer.Text = Settings.Default.MailServerHost;
            txtSMTPPort.Text = Settings.Default.MailServerPort.ToString();
            txtSMTPUsername.Text = Settings.Default.MailServerUser;
            txtSMTPPassword.Text = Settings.Default.MailServerPassword;

            Unchanged = false;
        }

        /// <summary>
        /// Save the settings to <see cref="Settings.Default"/>.
        /// </summary>
        public void SaveSettings()
        {
            if (Validator.Email(txtSMTPUsername.Text).Count == 0 && Validator.Email(txtFromAddress.Text).Count == 0)
            {
                if (int.TryParse(txtSMTPPort.Text, out int port))
                {
                    Settings.Default.MailFromAddress = txtFromAddress.Text;
                    Settings.Default.MailServerHost = txtSMTPServer.Text;
                    Settings.Default.MailServerPort = port;
                    Settings.Default.MailServerUser = txtSMTPUsername.Text;
                    Settings.Default.MailServerPassword = txtSMTPPassword.Text;

                    Settings.Default.Save();
                }
                else
                {
                    CMessageBox.Show("Invalid port number entered.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                }
            }
            else if (txtSMTPUsername.Text.Length > 0 || txtFromAddress.Text.Length > 0)
            {
                CMessageBox.Show("The email address entered was invalid.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
        }

        /// <summary>
        /// Set the defaults for this settings screen.
        /// </summary>
        public void ToDefaults()
        {
            txtSMTPUsername.Text = "";
            txtSMTPPassword.Text = "";
            txtSMTPServer.Text = "";
            txtSMTPPort.Text = "";
            txtFromAddress.Text = "";
        }

        protected virtual void OnHelpTextChanged(StatusArgs args)
        {
            HelpTextChanged?.Invoke(args);
        }

        private void flowLayoutPanel10_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the username used to sign on to the SMTP server."));
        }

        private void flowLayoutPanel10_MouseLeave(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        private void flowLayoutPanel11_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the password used to sign on to the SMTP server."));
        }

        private void flowLayoutPanel11_MouseLeave(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        private void flowLayoutPanel13_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the address of the SMTP server; usually this is smtp.<domain>.com"));
        }

        private void flowLayoutPanel13_MouseLeave(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        private void flowLayoutPanel12_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the TLS port to use when connecting to the SMTP server."));
        }

        private void flowLayoutPanel12_MouseLeave(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        private void flowLayoutPanel14_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the email address to display in the <From> field on emails."));
        }

        private void flowLayoutPanel14_MouseLeave(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }
    }
}
