using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.userControls;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.pages
{
    public class NewPage : KryptonPage
    {
        private EntityTypes entity;
        private DatabaseWrapper obj;

        public NewPage(EntityTypes entity, DatabaseWrapper o = null)
        {
            this.entity = entity;
            obj = o;

            SetUpPage();
        }

        private void SetUpPage()
        {
            switch (entity)
            {
                case EntityTypes.Survey:
                {
                    Controls.Add(new NewSurveyCtl()
                    {
                        Dock = System.Windows.Forms.DockStyle.Fill
                    });
                    Text = "New Survey";
                    TextTitle = Text;
                    break;
                }
                case EntityTypes.Client:
                case EntityTypes.Realtor:
                case EntityTypes.TitleCompany:
                {
                    Controls.Add(new NewObject(entity, obj)
                    {
                        Dock = System.Windows.Forms.DockStyle.Fill
                    });
                    Text = "New " + entity;
                    TextTitle = Text;
                    break;
                }
            }
        }
    }
}
