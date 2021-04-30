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
    public partial class FileSettings : UserControl, ISettingsControl
    {
        public string UniqueName { get => "files"; }

        public bool Unchanged { get; set; }

        public event ISettingsControl.ChangeStatusText HelpTextChanged;

        public FileSettings()
        {
            InitializeComponent();
        }

        private void FileSettings_Load(object sender, EventArgs e)
        {
            Unchanged = false;
        }

        public void SaveSettings()
        {
            
        }

        public void ToDefaults()
        {
            
        }
    }
}
