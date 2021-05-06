using SurveyManager.forms.surveyMenu.description;
using SurveyManager.forms.surveyMenu.jobInfo;
using SurveyManager.forms.surveyMenu.locationInfo;
using SurveyManager.forms.surveyMenu.subdivisionInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.surveyMenu
{
    public partial class InfoCtl : UserControl
    {
        private readonly List<UserControl> infoControls = new List<UserControl>
        {
            new EssentialInformationCtl(), new DescriptionCtl(), new SubdivisionCtl(), new LocationCtl()
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
                    if (!ctl.SaveInfo())
                    {
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
                if (Save())
                {
                    StatusUpdate?.Invoke(this, new StatusArgs("Job information successfully updated internally."));
                }
                else
                {
                    StatusUpdate?.Invoke(this, new StatusArgs("There was an issue updating the job's internal information. Please try again."));
                }

                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
