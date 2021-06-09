using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu.basicInfo
{
    public partial class InfoCtl : UserControl
    {
        private readonly List<UserControl> infoControls = new List<UserControl>
        {
            new EssentialInformationCtl(), new SubdivisionCtl(), new LocationCtl()
        };

        public EventHandler StatusUpdate;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (JobHandler.Instance.ReadOnly)
                return;

            if (Save())
            {
                StatusUpdate?.Invoke(this, new StatusArgs("Job information successfully updated."));
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs("There was an issue updating the job's information. Please try again."));
            }
        }

        private bool Save()
        {
            foreach (IInfoControl ctl in infoControls)
            {
                if (ctl.IsEdited)
                {
                    List<ValidatorError> errors = ctl.SaveInfo();
                    if (errors.Count != 0)
                    {
                        StringBuilder bldr = new StringBuilder();
                        foreach (ValidatorError e in errors)
                            bldr.Append(e.ToDescriptionString() + "\n");

                        CRichMsgBox.Show("Invalid or incomplete information detected. Please correct the issues below and try saving again:",
                            "Incomplete Information", bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);
                        return false;
                    }
                }
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
