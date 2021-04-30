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
        public string UniqueName { get => "database"; }

        public bool Unchanged { get; set; }

        public event ISettingsControl.ChangeStatusText HelpTextChanged;

        public GeneralSettings()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }


        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            
            Unchanged = false;
        }

        public void SaveSettings()
        {
            
        }

        public void ToDefaults()
        {
            
        }

        protected virtual void OnHelpTextChanged(StatusArgs args)
        {
            HelpTextChanged?.Invoke(args);
        }
    }
}
