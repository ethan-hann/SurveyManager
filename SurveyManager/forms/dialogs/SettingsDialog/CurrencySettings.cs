using SurveyManager.Properties;
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
    public partial class CurrencySettings : UserControl, ISettingsControl
    {
        public string UniqueName { get => "currency"; }

        public bool Unchanged { get; set; }

        public event ISettingsControl.ChangeStatusText HelpTextChanged;

        public CurrencySettings()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void CurrencySettings_Load(object sender, EventArgs e)
        {
            txtFieldRate.Text = Settings.Default.DefaultFieldRate.ToString();
            txtOfficeRate.Text = Settings.Default.DefaultOfficeRate.ToString();
            txtTaxRate.Text = Settings.Default.DefaultTaxRate.ToString();

            Unchanged = false;
        }

        public void SaveSettings()
        {
            if (decimal.TryParse(txtFieldRate.Text, out decimal fieldRate))
            {
                if (decimal.TryParse(txtOfficeRate.Text, out decimal officeRate))
                {
                    if (double.TryParse(txtTaxRate.Text, out double taxRate))
                    {
                        Settings.Default.DefaultFieldRate = fieldRate;
                        Settings.Default.DefaultOfficeRate = officeRate;
                        Settings.Default.DefaultTaxRate = taxRate;

                        Settings.Default.Save();
                    }
                }
            }
        }

        public void ToDefaults()
        {
            txtFieldRate.Text = "0.00";
            txtOfficeRate.Text = "0.00";
            txtTaxRate.Text = "0.0825";
        }

        private void txtTaxRate_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtTaxRate.Text, out double taxRate))
            {
                lblPercentage.Text = $"{taxRate * 100.00} %";
            }
        }

        private void flowLayoutPanel2_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the default field rate per hour for new jobs."));
        }

        private void flowLayoutPanel3_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the default office rate per hour for new jobs."));
        }

        private void flowLayoutPanel4_MouseEnter(object sender, EventArgs e)
        {
            OnHelpTextChanged(new StatusArgs("Specify the default tax rate that should be applied for new jobs."));
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
