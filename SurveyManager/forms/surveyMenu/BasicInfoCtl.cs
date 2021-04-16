using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
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

namespace SurveyManager.forms.surveyMenu
{
    public partial class BasicInfoCtl : UserControl
    {
        public BasicInfoCtl()
        {
            InitializeComponent();
        }

        private void BasicInfoCtl_Load(object sender, EventArgs e)
        {
           
            //Set combo box
            cmbCounty.DataSource = RuntimeVars.Instance.Counties;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            else
            {
                KryptonRichTextBox rtb = sender as KryptonRichTextBox;
                if (rtb != null)
                    rtb.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
                else
                {
                    KryptonComboBox cmb = sender as KryptonComboBox;
                    if (cmb != null)
                        cmb.StateCommon.ComboBox.Back.Color1 = Color.FromArgb(255, 255, 128);
                }
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.White;
            else
            {
                KryptonRichTextBox rtb = sender as KryptonRichTextBox;
                if (rtb != null)
                    rtb.StateCommon.Back.Color1 = Color.White;
                else
                {
                    KryptonComboBox cmb = sender as KryptonComboBox;
                    if (cmb != null)
                        cmb.StateCommon.ComboBox.Back.Color1 = Color.White;
                }
            }
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            RuntimeVars.Instance.OpenJob.County = cmbCounty.SelectedItem as County;
        }
    }
}
