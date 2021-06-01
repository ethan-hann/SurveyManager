using ComponentFactory.Krypton.Navigator;
using SurveyManager.forms.userControls;
using SurveyManager.utility;
using System;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.pages
{
    public class BillingPortal : KryptonPage
    {
        public BillingPortal(string titleText = "Billing Portal")
        {
            Text = titleText;
            TextTitle = Text;

            BillingPortalCtl ctl = new BillingPortalCtl()
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
