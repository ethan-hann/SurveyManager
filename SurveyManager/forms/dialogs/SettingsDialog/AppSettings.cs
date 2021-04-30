using ComponentFactory.Krypton.Toolkit;
using SurveyManager.forms.dialogs.SettingsDialog;
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

namespace SurveyManager.forms.dialogs
{
    public partial class AppSettings : KryptonForm
    {
        //Create a list of setting controls with all of the UserControls considered setting screens
        private readonly List<ISettingsControl> settingControls = new List<ISettingsControl>
        {
            new CurrencySettings(), new GeneralSettings(), new EmailSettings(), new FileSettings()
        };

        /// <summary>
        /// Create an instance of the settings form that contains settings related to the application.
        /// </summary>
        public AppSettings()
        {
            InitializeComponent();

            //Add the event handler for each Settings screen to change the help text on this main form.
            foreach (ISettingsControl ctl in settingControls)
            {
                ctl.HelpTextChanged += ChangeStatusText;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.settings_24x24.GetHicon());
            settingsTreeView.SelectedNode = settingsTreeView.Nodes[0];
        }

        private void ChangeStatusText(StatusArgs args)
        {
            lblHelp.Text = args.StatusString;
        }

        /// <summary>
        /// Fill the right side of the form with the correct UserControl based on the selected item in the tree view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            controlContainer.Controls.Clear();
            ISettingsControl ctl = settingControls.Find(c => e.Node.Name.Contains(c.UniqueName));
            if (ctl != null)
                controlContainer.Controls.Add((UserControl)ctl);
        }

        /// <summary>
        /// All of the User controls that are considered setting screens implement the ISettingsControl interface.
        /// <para>Iterates through all of them that have been opened and calls the SaveSettings() method.</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (ISettingsControl c in settingControls)
            {
                if (!c.Unchanged)
                    c.SaveSettings();
            }

            RuntimeVars.Instance.MainForm.ChangeStatusText(this, new StatusArgs("Settings have been updated."));
        }

        /// <summary>
        /// All of the User controls that are considered setting screens implement the ISettingsControl interface.
        /// <para>Iterates through all of them that have been opened and calls the ToDefaults() method.</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToDefaults_Click(object sender, EventArgs e)
        {
            DialogResult result = CMessageBox.Show("Are you sure you want to reset settings? Changes do not save unless you click the \"Save\" button.", "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);
            if (result == DialogResult.Yes)
            {
                foreach (ISettingsControl c in settingControls)
                {
                    c.ToDefaults();
                }
            }
        }
    }
}
