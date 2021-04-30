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

            Unchanged = false;
        }

        public void SaveSettings()
        {
            Settings.Default.SurveyAutoSaveInterval = (int)nudAutoSaveInterval.Value;
            Settings.Default.SurveyAutoSaveEnabled = chkEnableSurveyAutoSave.Checked;
            Settings.Default.Save();

            //Set the new autosave interval
            RuntimeVars.Instance.MainForm.SetSurveyAutosaveInterval(Settings.Default.SurveyAutoSaveInterval);
        }

        public void ToDefaults()
        {
            chkEnableSurveyAutoSave.Checked = true;
            nudAutoSaveInterval.Value = 15;
        }

        private void chkEnableSurveyAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            flpInterval.Visible = chkEnableSurveyAutoSave.Checked;
        }

        private void chkEnableSurveyAutoSave_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Autosaves the currently open survey job when the specified amount of time has passed."));
        }

        private void flpInterval_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Defines the time between autosaves for the currently open survey job. Range: 1 => 180 minutes (3 hours)."));
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
