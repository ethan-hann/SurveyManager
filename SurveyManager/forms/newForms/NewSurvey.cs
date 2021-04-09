using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.surveyMenu;
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

            fileCtl.StatusUpdate += RuntimeVars.Instance.MainForm.ChangeStatusText;
            fileCtl.FileUploadDone += SetFiles;
        }

        private void NewSurvey_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.surveying_16x16.GetHicon());

            surveyPropGrid.GetAcceptButton().ToolTipText = "Save the survey to the database.";
            surveyPropGrid.GetClearButton().ToolTipText = "Clear all values and start over.";

            surveyPropGrid.GetAcceptButton().Click += SaveClient;
            surveyPropGrid.GetClearButton().Click += ClearFields;
            

            surveyPropGrid.SelectedObject = survey;
            clientPropGrid.SelectedObject = survey.Client;
            realtorPropGrid.SelectedObject = survey.Realtor;
            tcPropGrid.SelectedObject = survey.TitleCompany;

            if (survey.HasFiles)
                fileCtl.AddFiles(survey.Files);
        }

        private void SetFiles(object sender, EventArgs e)
        {
            if (!editMode)
                survey.ClearFiles();
            survey.AddFiles(fileCtl.GetFiles());
        }

        private void SaveClient(object sender, EventArgs e)
        {
            survey = (Survey)surveyPropGrid.SelectedObject;
            if (survey.Location.IsEmpty)
                survey.Location = survey.Client.ClientAddress;

            DatabaseError surveyError;

            if (!editMode)
                surveyError = survey.Insert();
            else
                surveyError = survey.Update();

            switch (surveyError)
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
            DialogResult result = CMessageBox.Show("Are you sure? This will clear all fields including associated objects!", "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);

            if (result == DialogResult.Yes)
            {
                survey = new Survey();
                surveyPropGrid.SelectedObject = survey;
                clientPropGrid.SelectedObject = survey.Client;
                realtorPropGrid.SelectedObject = survey.Realtor;
                tcPropGrid.SelectedObject = survey.TitleCompany;
            }
        }

        #region Drag and Drop events
        private void propGrid_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(DragDropInfo)) is DragDropInfo c)
            {
                string s = c.Wrapper.GetType().ToString();
                if (s.Contains("Client"))
                    clientPropGrid.SelectedObject = c.Wrapper;
                else if (s.Contains("Realtor"))
                    realtorPropGrid.SelectedObject = c.Wrapper;
                else if (s.Contains("TitleCompany"))
                    tcPropGrid.SelectedObject = c.Wrapper;
            }
        }

        private void propGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DragDropInfo)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion

        private void clientPropGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            survey.Client = (Client)clientPropGrid.SelectedObject;
            surveyPropGrid.Update();
        }

        private void realtorPropGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            survey.Realtor = (Realtor)realtorPropGrid.SelectedObject;
            surveyPropGrid.Update();
        }

        private void tcPropGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            survey.TitleCompany = (TitleCompany)tcPropGrid.SelectedObject;
            surveyPropGrid.Update();
        }
    }
}
