using ComponentFactory.Krypton.Navigator;
using SurveyManager.forms.userControls;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
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
            ImageSmall = Resources.view_16x16;
            ImageLarge = Resources.view;

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
