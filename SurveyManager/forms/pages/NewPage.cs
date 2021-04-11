using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.userControls;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.pages
{
    public class NewPage : KryptonPage
    {
        public NewPage(EntityTypes entity, DatabaseWrapper o = null)
        {
            if (entity == EntityTypes.TitleCompany)
                Text = "New Title Company";
            else
                Text = "New " + entity;
            TextTitle = Text;

            NewObject ctl = new NewObject(entity, o)
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
