using ComponentFactory.Krypton.Toolkit;
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

namespace SurveyManager.forms.surveyMenu.subdivisionInfo
{
    public partial class SubdivisionCtl : UserControl, IInfoControl
    {
        public SubdivisionCtl()
        {
            InitializeComponent();
        }

        public bool SaveInfo()
        {
            RuntimeVars.Instance.OpenJob.Subdivision = txtName.Text.Length == 0 ? "N/A" : txtName.Text;
            RuntimeVars.Instance.OpenJob.SectionNumber = txtSection.Text.Length == 0 ? "N/A" : txtSection.Text;
            RuntimeVars.Instance.OpenJob.BlockNumber = txtBlock.Text.Length == 0 ? "N/A" : txtBlock.Text;
            RuntimeVars.Instance.OpenJob.LotNumber = txtLot.Text.Length == 0 ? "N/A" : txtLot.Text;

            return true;
        }

        private void SubdivisionCtl_Load(object sender, EventArgs e)
        {
            txtName.Text = RuntimeVars.Instance.OpenJob.Subdivision;
            txtSection.Text = RuntimeVars.Instance.OpenJob.SectionNumber;
            txtBlock.Text = RuntimeVars.Instance.OpenJob.BlockNumber;
            txtLot.Text = RuntimeVars.Instance.OpenJob.LotNumber;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.White;
        }
    }
}
