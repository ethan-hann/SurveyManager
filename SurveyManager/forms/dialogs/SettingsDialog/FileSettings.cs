using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.dialogs.SettingsDialog
{
    public partial class FileSettings : UserControl, ISettingsControl
    {
        public string UniqueName { get => "files"; }

        public bool Unchanged { get; set; }

        public event ISettingsControl.ChangeStatusText HelpTextChanged;

        public FileSettings()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void FileSettings_Load(object sender, EventArgs e)
        {
            //Log file options
            radOverwriteLog.Checked = Settings.Default.OverwriteLogFile;
            if (!radOverwriteLog.Checked)
                radCreateNewLogFile.Checked = true;

            lblPath.Text = Settings.Default.LogFilePath;
            openLogFolder.SelectedPath = lblPath.Text;
            nudAutoSaveInterval.Value = Settings.Default.LogAutoSaveInterval;

            //Other file options
            lblReportPath.Text = Settings.Default.DefaultSavePath;
            openReportPath.SelectedPath = lblReportPath.Text;

            Unchanged = false;
        }

        public void SaveSettings()
        {
            //Log file options
            Settings.Default.OverwriteLogFile = radOverwriteLog.Checked;
            Settings.Default.LogFilePath = lblPath.Text;
            Settings.Default.LogAutoSaveInterval = (int)nudAutoSaveInterval.Value;

            //Other file options
            Settings.Default.DefaultSavePath = lblReportPath.Text;

            Settings.Default.Save();

            CMessageBox.Show("An application restart is needed for some logging settings to take full effect. Please save your work and restart the application.", "Restart Required", MessageBoxButtons.OK, Resources.warning_64x64);
        }

        public void ToDefaults()
        {
            //Log file defaults
            lblPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SurveyManager", "logs");
            radOverwriteLog.Checked = true;
            radCreateNewLogFile.Checked = false;

            //file options defaults
            lblReportPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SurveyManager");
        }

        private void btnChangeLogPath_Click(object sender, EventArgs e)
        {
            if (openLogFolder.ShowDialog() == DialogResult.OK)
            {
                lblPath.Text = openLogFolder.SelectedPath;
            }
        }

        private void btnOpenLogPath_Click(object sender, EventArgs e)
        {
            if (File.Exists(RuntimeVars.Instance.LogFile.FullPath))
            {
                Process.Start(RuntimeVars.Instance.LogFile.FullPath);
            }
            else
            {
                CMessageBox.Show("Log file could not be opened! Has it been deleted or moved?", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
        }

        private void btnChangeReportPath_Click(object sender, EventArgs e)
        {
            if (openReportPath.ShowDialog() == DialogResult.OK)
            {
                lblReportPath.Text = openReportPath.SelectedPath;
            }
        }

        private void radCreateNewLogFile_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Create a new log file every time the application is launched."));
        }

        private void radOverwriteLog_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Overwrite the existing log file everytime the application is launched."));
        }

        private void flowLayoutPanel3_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Defines the time between autosaves for the log file. Range: 5 => 120 minutes (2 hours)."));
        }

        private void btnChangeReportPath_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Change the default location where PDF reports are saved to."));
        }

        private void ResetHelpText(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        private void btnChangeLogPath_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Change the default location for log files."));
        }

        private void btnOpenLogPath_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Open the current log file in the system's default text editor."));
        }

        protected virtual void OnHelpTextChanged(StatusArgs args)
        {
            HelpTextChanged?.Invoke(args);
        }
    }
}
