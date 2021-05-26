using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.userControls;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
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
            switch (entity)
            {
                case EntityTypes.Client:
                {
                    ImageSmall = Resources.client_16x16;
                    ImageLarge = Resources.client;
                    break;
                }
                case EntityTypes.Realtor:
                {
                    ImageSmall = Resources.realtor_16x16;
                    ImageLarge = Resources.realtor;
                    break;
                }
                case EntityTypes.TitleCompany:
                {
                    ImageSmall = Resources.title_company_16x16;
                    ImageLarge = Resources.title_company;
                    break;
                }
                case EntityTypes.Rate:
                {
                    ImageSmall = Resources.billing_rates_16x16;
                    ImageLarge = Resources.billing_rates;
                    break;
                }
            }

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
