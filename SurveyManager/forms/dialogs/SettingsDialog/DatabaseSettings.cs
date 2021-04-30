using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyManager.forms.dialogs.SettingsDialog
{
    public partial class DatabaseSettings : UserControl, ISettingsControl
    {
        public string UniqueName { get => "database"; }

        public bool Unchanged { get; set; }

        public event ISettingsControl.ChangeStatusText HelpTextChanged;

        public DatabaseSettings()
        {
            InitializeComponent();
        }


        private void DatabaseSettings_Load(object sender, EventArgs e)
        {

        }

        public void SaveSettings()
        {
            
        }

        public void ToDefaults()
        {
            
        }
    }
}
