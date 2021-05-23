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
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.dialogs.SettingsDialog
{
    public partial class EmailSettings : UserControl, ISettingsControl
    {
        public event ISettingsControl.ChangeStatusText HelpTextChanged;
        public string UniqueName { get => "email"; }

        public bool Unchanged { get; set; } = true;

        private IncomingMailProtocol incomingProtocol = IncomingMailProtocol.IMAP;

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
            //Outgoing Mail Settings
            txtFromAddress.Text = Settings.Default.MailFromAddress;
            txtSMTPServer.Text = Settings.Default.MailServerHost;
            txtSMTPPort.Text = Settings.Default.MailServerPort.ToString();
            chkRequiresSSL.Checked = Settings.Default.OutgoingMailRequiresSSL;
            chkRequiresTLS.Checked = Settings.Default.OutgoingMailRequiresTLS;
            chkRequiresAuth.Checked = Settings.Default.OutgoingMailRequiresAuthentication;

            //Incoming Mail Settings
            txtIncomingMailServer.Text = Settings.Default.IncomingMailServer;
            txtIncomingPort.Text = Settings.Default.IncomingMailPort.ToString();
            incomingProtocol = (IncomingMailProtocol)Enum.Parse(typeof(IncomingMailProtocol), Settings.Default.IncomingProtocol);
            switch (incomingProtocol)
            {
                case IncomingMailProtocol.IMAP:
                    radIMAP.Checked = true;
                    break;
                case IncomingMailProtocol.POP3:
                    radPOP.Checked = true;
                    break;
            }
            chkIncomingRequiresSSL.Checked = Settings.Default.IncomingMailRequiresSSL;

            //Login Settings
            txtSMTPUsername.Text = Settings.Default.MailServerUser;
            txtSMTPPassword.Text = Settings.Default.MailServerPassword;

            Unchanged = false;
        }

        /// <summary>
        /// Save the settings to <see cref="Settings.Default"/>.
        /// </summary>
        public void SaveSettings()
        {
            //Outgoing Mail Save
            if (Validator.ValidateEmail(txtSMTPUsername.Text) && Validator.ValidateEmail(txtFromAddress.Text))
            {
                if (int.TryParse(txtSMTPPort.Text, out int port))
                {
                    Settings.Default.MailFromAddress = txtFromAddress.Text;
                    Settings.Default.MailServerHost = txtSMTPServer.Text;
                    Settings.Default.MailServerPort = port;

                    Settings.Default.Save();
                }
                else
                {
                    CMessageBox.Show("Invalid SMTP port number entered.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                }
            }
            else if (txtSMTPUsername.Text.Length > 0 || txtFromAddress.Text.Length > 0)
            {
                CMessageBox.Show("The email address entered was invalid.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
            Settings.Default.OutgoingMailRequiresSSL = chkRequiresSSL.Checked;
            Settings.Default.OutgoingMailRequiresTLS = chkRequiresTLS.Checked;
            Settings.Default.OutgoingMailRequiresAuthentication = chkRequiresAuth.Checked;

            //Incoming Mail Save
            if (int.TryParse(txtIncomingPort.Text, out int incomingPort))
            {
                Settings.Default.IncomingMailServer = txtIncomingMailServer.Text;
                Settings.Default.IncomingMailPort = incomingPort;
                Settings.Default.IncomingMailRequiresSSL = chkIncomingRequiresSSL.Checked;
                Settings.Default.IncomingProtocol = incomingProtocol.ToString();
            }
            else
            {
                CMessageBox.Show($"Invalid {incomingProtocol} port number entered.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }

            //Login Credentials Save
            Settings.Default.MailServerUser = txtSMTPUsername.Text;
            Settings.Default.MailServerPassword = txtSMTPPassword.Text;
        }

        /// <summary>
        /// Set the defaults for this settings screen.
        /// </summary>
        public void ToDefaults()
        {
            //Outgoing Defaults
            txtSMTPServer.Text = "";
            txtSMTPPort.Text = "";
            txtFromAddress.Text = "";
            chkRequiresSSL.Checked = false;
            chkRequiresTLS.Checked = false;
            chkRequiresAuth.Checked = false;

            //Incoming Defaults
            radIMAP.Checked = true;
            radPOP.Checked = false;
            txtIncomingMailServer.Text = "";
            txtIncomingPort.Text = "";
            chkIncomingRequiresSSL.Checked = false;

            //Login Defaults
            txtSMTPUsername.Text = "";
            txtSMTPPassword.Text = "";
        }

        private void radIMAP_CheckedChanged(object sender, EventArgs e)
        {
            incomingProtocol = radIMAP.Checked ? IncomingMailProtocol.IMAP : IncomingMailProtocol.POP3;
        }

        protected virtual void OnHelpTextChanged(StatusArgs args)
        {
            HelpTextChanged?.Invoke(args);
        }

        private void ResetHelpText(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        private void flowLayoutPanel10_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the username used to sign on to the mail server."));
        }

        private void flowLayoutPanel11_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the password used to sign on to the mail server."));
        }

        private void flowLayoutPanel13_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the address of the SMTP server; usually this is smtp.<domain>.com"));
        }

        private void flowLayoutPanel12_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the port to use when connecting to the SMTP server."));
        }

        private void flowLayoutPanel14_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the email address to display in the <From> field on emails."));
        }

        private void chkRequiresSSL_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify if the outgoing mail server requires SSL encryption."));
        }

        private void chkRequiresTLS_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify if the outgoing mail server requires TLS encryption."));
        }

        private void chkRequiresAuth_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify if the outgoing mail server requires authentication."));
        }

        private void radIMAP_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Indicates that the incoming mail server uses the IMAP protocol."));
        }

        private void radPOP_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Indicates that the incoming mail server uses the POP3 protocol."));
        }

        private void flowLayoutPanel6_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the incoming mail server address."));
        }

        private void flowLayoutPanel7_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the incoming mail server port number."));
        }

        private void chkIncomingRequiresSSL_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify if the incoming mail server requires SSL encryption."));
        }
    }
}
