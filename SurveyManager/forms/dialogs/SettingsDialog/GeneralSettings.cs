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

namespace SurveyManager.forms.dialogs.SettingsDialog
{
    public partial class GeneralSettings : UserControl, ISettingsControl
    {
        public string UniqueName { get => "general"; }

        public bool Unchanged { get; set; }

        public event ISettingsControl.ChangeStatusText HelpTextChanged;

        public GeneralSettings()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            chkEnableSurveyAutoSave.Checked = Settings.Default.SurveyAutoSaveEnabled;
            flpInterval.Visible = chkEnableSurveyAutoSave.Checked;

            if (chkEnableSurveyAutoSave.Checked)
                nudAutoSaveInterval.Value = Settings.Default.SurveyAutoSaveInterval;

            radLastTwoDigits.Checked = Settings.Default.DefaultJobPrefixEnabled;
            if (!Settings.Default.DefaultJobPrefixEnabled)
                radCustomText.Checked = true;

            string prefix = Settings.Default.SurveyJobPrefix;
            if (!radLastTwoDigits.Checked && !prefix.Equals("Undefined"))
            {
                txtCustomPrefix.Text = prefix;
            }

            Unchanged = false;
        }

        public void SaveSettings()
        {
            Settings.Default.SurveyAutoSaveInterval = (int)nudAutoSaveInterval.Value;
            Settings.Default.SurveyAutoSaveEnabled = chkEnableSurveyAutoSave.Checked;
            Settings.Default.DefaultJobPrefixEnabled = radLastTwoDigits.Checked;

            if (!radLastTwoDigits.Checked)
                Settings.Default.SurveyJobPrefix = txtCustomPrefix.Text;

            Settings.Default.Save();

            //Set the new autosave interval
            RuntimeVars.Instance.MainForm.SetSurveyAutosaveInterval(Settings.Default.SurveyAutoSaveInterval);
        }

        public void ToDefaults()
        {
            chkEnableSurveyAutoSave.Checked = true;
            nudAutoSaveInterval.Value = 15;
            radLastTwoDigits.Checked = true;
            txtCustomPrefix.Text = "";
        }

        private void chkEnableSurveyAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            flpInterval.Visible = chkEnableSurveyAutoSave.Checked;
        }

        private void radLastTwoDigits_CheckedChanged(object sender, EventArgs e)
        {
            if (radLastTwoDigits.Checked)
                flpCustomText.Visible = false;
            else
                flpCustomText.Visible = true;

            UpdatePrefixPreview();
        }

        private void txtCustomPrefix_TextChanged(object sender, EventArgs e)
        {
            lblCharCount.Text = "Char. Count: " + txtCustomPrefix.Text.Count() + " / 128";
            UpdatePrefixPreview();
        }

        private void UpdatePrefixPreview()
        {
            lblPrefixPreview.Values.ExtraText = radLastTwoDigits.Checked ? $"{DateTime.Now.Year.ToString().Substring(2)}-1500" : $"{txtCustomPrefix.Text}-1500";
        }

        private void chkEnableSurveyAutoSave_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Autosaves the currently open survey job when the specified amount of time has passed."));
        }

        private void flpInterval_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Defines the time between autosaves for the currently open survey job. Range: 1 => 180 minutes (3 hours)."));
        }

        private void radLastTwoDigits_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Indicates that the last two digits of the current year will be used as the default job number prefix."));
        }

        private void radCustomText_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Indicates that specified custom text will be used as the default job number prefix."));
        }

        private void flpExampleText_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Shows an example of what a job number may look like based on the selected prefix."));
        }

        private void ResetHelpText(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs(""));
        }

        protected virtual void OnHelpTextChanged(StatusArgs args)
        {
            HelpTextChanged?.Invoke(args);
        }
    }
}
