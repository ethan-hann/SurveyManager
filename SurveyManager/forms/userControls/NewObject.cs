using ComponentFactory.Krypton.Navigator;
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

namespace SurveyManager.forms.userControls
{
    public partial class NewObject : UserControl
    {
        private readonly EntityTypes entity;
        private DatabaseWrapper obj;

        public EventHandler StatusUpdate;

        public NewObject(EntityTypes entity, DatabaseWrapper o = null)
        {
            InitializeComponent();

            this.entity = entity;
            obj = o;

            if (obj == null)
            {
                switch (entity)
                {
                    case EntityTypes.Survey:
                        obj = new Survey();
                        break;
                    case EntityTypes.Client:
                        obj = new Client();
                        break;
                    case EntityTypes.Realtor:
                        obj = new Realtor();
                        break;
                    case EntityTypes.TitleCompany:
                        obj = new TitleCompany();
                        break;
                }
            }

            propGrid.GetAcceptButton().Click += SaveObject;
            propGrid.GetClearButton().Click += ClearObject;
            propGrid.GetAcceptButton().Visible = true;
            propGrid.GetClearButton().Visible = true;

            if (entity == EntityTypes.Survey)
            {
                propGrid.GetUploadFilesButton().Click += UploadFiles;
                propGrid.GetUploadFilesButton().Visible = true;
            }

            propGrid.SelectedObject = obj;
        }

        private void UploadFiles(object sender, EventArgs e)
        {
            if (entity != EntityTypes.Survey)
                return;

            UploadFile uploadDialog = new UploadFile((obj as Survey).Files);
            uploadDialog.StatusUpdate += RuntimeVars.Instance.MainForm.ChangeStatusText;
            uploadDialog.FileUploadDone += SetFiles;

            uploadDialog.Show();
        }

        private void SetFiles(object sender, EventArgs e)
        {
            if (e is FileUploadDoneArgs args)
            {
                (obj as Survey).ClearFiles();
                (obj as Survey).AddFiles(args.Files);
                propGrid.SelectedObject = obj;
            }
        }

        private void SaveObject(object sender, EventArgs e)
        {
            RuntimeVars.Instance.SelectedPageUniqueName = ((KryptonPage)Parent).UniqueName;

            switch (entity)
            {
                case EntityTypes.Survey:
                    SaveSurvey();
                    break;
                case EntityTypes.Client:
                    SaveClient();
                    break;
                case EntityTypes.Realtor:
                    SaveRealtor();
                    break;
                case EntityTypes.TitleCompany:
                    SaveTitleCompany();
                    break;
            }
        }

        #region Save Methods
        private void SaveTitleCompany()
        {
            TitleCompany t = obj as TitleCompany;
            DatabaseError tcError = t.Insert();
            switch (tcError)
            {
                case DatabaseError.RealtorIncomplete:
                    CMessageBox.Show("Company's name, associate's name, and associate's email cannot be empty or \"N/A\"!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.RealtorInsert:
                    CMessageBox.Show("Could not create the title company in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.RealtorUpdate:
                    CMessageBox.Show("Could not update the company's information in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.NoError:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Title Company {t.Name} created successfully."));
                    if (CMessageBox.Show("Create another?", "", MessageBoxButtons.YesNo, Resources.info_64x64) == DialogResult.Yes)
                    {
                        Clear();
                    }
                    else
                    {
                        RuntimeVars.Instance.MainForm.DockingWorkspace.RemovePage(RuntimeVars.Instance.SelectedPageUniqueName, true);
                    }
                    break;
                }
                default:
                    CMessageBox.Show("An unknown error has occured. Please try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
            }
        }

        private void SaveRealtor()
        {
            Realtor r = obj as Realtor;
            DatabaseError realtorError = r.Insert();
            switch (realtorError)
            {
                case DatabaseError.RealtorIncomplete:
                    CMessageBox.Show("Realtor's name, phone number, and company name cannot be empty or \"N/A\"!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.RealtorInsert:
                    CMessageBox.Show("Could not create the realtor in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.RealtorUpdate:
                    CMessageBox.Show("Could not update the realtor's information in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.NoError:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Realtor {r.Name} created successfully."));
                    if (CMessageBox.Show("Create another?", "", MessageBoxButtons.YesNo, Resources.info_64x64) == DialogResult.Yes)
                    {
                        Clear();
                    }
                    else
                    {
                        RuntimeVars.Instance.MainForm.DockingWorkspace.RemovePage(RuntimeVars.Instance.SelectedPageUniqueName, true);
                    }
                    break;
                }
                default:
                    CMessageBox.Show("An unknown error has occured. Please try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
            }
        }

        private void SaveClient()
        {
            Client c = obj as Client;
            DatabaseError clientError = c.Insert();
            switch (clientError)
            {
                case DatabaseError.AddressIncomplete:
                    CMessageBox.Show("Client's address cannot be empty!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.ClientIncomplete:
                    CMessageBox.Show("Client's name and phone number cannot be empty or \"N/A\"!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.AddressInsert:
                    CMessageBox.Show("Could not create the client's address in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.ClientInsert:
                    CMessageBox.Show("Could not create the client in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.ClientUpdate:
                    CMessageBox.Show("Could not update the client's information in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                case DatabaseError.NoError:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Client {c.Name} created successfully."));
                    if (CMessageBox.Show("Create another?", "", MessageBoxButtons.YesNo, Resources.info_64x64) == DialogResult.Yes)
                    {
                        Clear();
                    }
                    else
                    {
                        RuntimeVars.Instance.MainForm.DockingWorkspace.RemovePage(RuntimeVars.Instance.SelectedPageUniqueName, true);
                    }
                    break;
                }
                default:
                    CMessageBox.Show("An unknown error has occured. Please try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
            }
        }

        private void SaveSurvey()
        {
            Survey s = obj as Survey;
            if (s.Location.IsEmpty)
                s.Location = s.Client.ClientAddress;

            DatabaseError surveyError = s.Insert();
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
                    StatusUpdate?.Invoke(this, new StatusArgs($"Survey {s.JobNumber} created successfully."));
                    if (CMessageBox.Show("Create another?", "", MessageBoxButtons.YesNo, Resources.info_64x64) == DialogResult.Yes)
                    {
                        Clear();
                    }
                    else
                    {
                        RuntimeVars.Instance.MainForm.DockingWorkspace.RemovePage(RuntimeVars.Instance.SelectedPageUniqueName, true);
                    }
                    break;
                }
                default:
                    CMessageBox.Show("An unknown error has occured. Please try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
            }
        }
        #endregion

        private void Clear()
        {
            switch (entity)
            {
                case EntityTypes.Survey:
                    obj = new Survey();
                    break;
                case EntityTypes.Client:
                    obj = new Client();
                    break;
                case EntityTypes.Realtor:
                    obj = new Realtor();
                    break;
                case EntityTypes.TitleCompany:
                    obj = new TitleCompany();
                    break;
            }
            propGrid.SelectedObject = obj;
        }

        private void ClearObject(object sender, EventArgs e)
        {
            DialogResult result = CMessageBox.Show("Clear all fields?", "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);
            if (result == DialogResult.Yes)
            {
                Clear();
            }
        }
    }
}
