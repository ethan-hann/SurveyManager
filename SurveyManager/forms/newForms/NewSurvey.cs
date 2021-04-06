using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
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
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.newForms
{
    public partial class NewSurvey : KryptonForm
    {
        private Survey survey = new Survey();
        private bool editMode = false;

        public EventHandler StatusUpdate;

        public NewSurvey(Survey s = null)
        {
            InitializeComponent();

            if (s != null)
            {
                editMode = true;
                survey = s;
            }
        }

        private void NewSurvey_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.surveying_16x16.GetHicon());

            clientPropGrid.GetAcceptButton().ToolTipText = "Save the survey to the database.";
            clientPropGrid.GetClearButton().ToolTipText = "Clear all values and start over.";

            clientPropGrid.GetAcceptButton().Click += SaveClient;
            clientPropGrid.GetClearButton().Click += ClearFields;
            

            clientPropGrid.SelectedObject = survey;
        }

        private void SaveClient(object sender, EventArgs e)
        {
            survey = (Survey)clientPropGrid.SelectedObject;
            DatabaseError clientError;

            if (!editMode)
                clientError = survey.Insert();
            else
                clientError = survey.Update();

            switch (clientError)
            {
                case DatabaseError.SurveyIncomplete:
                    CMessageBox.Show("A survey must have a Client, County, Job Number, Description, and Abstract Number associated with it!\nPlease check your input and try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.SurveyInsert:
                    CMessageBox.Show("Could not create the survey in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.SurveyUpdate:
                    CMessageBox.Show("Could not update the survey's information in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.NoError:
                {
                    if (editMode)
                        StatusUpdate?.Invoke(this, new StatusArgs($"Survey {survey.JobNumber} updated successfully."));
                    else
                        StatusUpdate?.Invoke(this, new StatusArgs($"Survey {survey.JobNumber} created successfully."));
                    Close();
                    break;
                }
                default:
                    CMessageBox.Show("An unknown error has occured. Please try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
            }
        }

        private void ClearFields(object sender, EventArgs e)
        {
            DialogResult result = CMessageBox.Show("Are you sure? This will clear all fields.", "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);

            if (result == DialogResult.Yes)
            {
                survey = new Survey();
                clientPropGrid.SelectedObject = survey;
            }
            else
                return;
        }
    }
}
