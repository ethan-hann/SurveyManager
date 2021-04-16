using SurveyManager.forms.surveyMenu.description;
using SurveyManager.forms.surveyMenu.jobInfo;
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
    public partial class InfoCtl : UserControl
    {
        private readonly List<UserControl> infoControls = new List<UserControl>
        {
            new EssentialInformationCtl(), new DescriptionCtl()
        };

        public InfoCtl()
        {
            InitializeComponent();
        }

        private void InfoCtl_Load(object sender, EventArgs e)
        {
            lbCategories.SelectedIndex = 0;
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = lbCategories.SelectedItem as string;
            string[] tokens = selectedItem.Split(' ');
            string firstWord = tokens[0];

            splitContainer1.Panel2.Controls.Clear();
            UserControl ctl = infoControls.Find(c => c.Name.StartsWith(firstWord));
            if (ctl != null)
            {
                ctl.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(ctl);
            }
        }
    }
}
