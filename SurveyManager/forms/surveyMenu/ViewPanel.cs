using ComponentFactory.Krypton.Navigator;
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

namespace SurveyManager.forms.surveyMenu
{
    public partial class ViewPanel : UserControl
    {
        public ViewPanel()
        {
            InitializeComponent();
        }

        private void ViewPanel_Load(object sender, EventArgs e)
        {
            propGrid.SelectedObject = RuntimeVars.Instance.OpenJob;

            propGrid.GetAcceptButton().Text = "Refresh";
            propGrid.GetClearButton().Visible = false;
            propGrid.GetAcceptButton().Click += RefreshObject;
            propGrid.GetAcceptButton().Image = Resources.reload_16x16;
        }

        private void RefreshObject(object sender, EventArgs e)
        {
            propGrid.SelectedObject = RuntimeVars.Instance.OpenJob;
            (Parent as KryptonPage).Text = "Job #: " + RuntimeVars.Instance.OpenJob.JobNumber + " Info";
            (Parent as KryptonPage).TextTitle = "Job #: " + RuntimeVars.Instance.OpenJob.JobNumber + " Info";
            (Parent as KryptonPage).UniqueName = "Job #: " + RuntimeVars.Instance.OpenJob.JobNumber + " Info";
        }
    }
}
