using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.userControls;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.pages
{
    public class ViewPage : KryptonPage
    {
        public ViewPage(EntityTypes entity, string titleText, FilterDoneEventArgs args = null)
        {
            Text = titleText;
            TextTitle = Text;

            ViewObjectsCtl ctl = new ViewObjectsCtl(entity, args)
            {
                Dock = System.Windows.Forms.DockStyle.Fill
            };

            ctl.StatusUpdate += UpdateMainFormStatus;

            Controls.Add(ctl);
        }

        private void UpdateMainFormStatus(object sender, EventArgs e)
        {
            if (e is StatusArgs args)
            {
                RuntimeVars.Instance.MainForm.ChangeStatusText(sender, args);
            }
        }
    }
}
