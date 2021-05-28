using ComponentFactory.Krypton.Navigator;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.userControls
{
    public partial class NewObject : UserControl
    {
        private readonly EntityTypes entity;
        private IDatabaseWrapper obj;

        public EventHandler StatusUpdate;

        public NewObject(EntityTypes entity, IDatabaseWrapper o = null)
        {
            InitializeComponent();

            this.entity = entity;
            obj = o;

            if (obj == null)
            {
                switch (entity)
                {
                    case EntityTypes.Client:
                    obj = new Client();
                    break;
                    case EntityTypes.Realtor:
                    obj = new Realtor();
                    break;
                    case EntityTypes.TitleCompany:
                    obj = new TitleCompany();
                    break;
                    case EntityTypes.Rate:
                    obj = new Rate();
                    break;
                }
            }

            propGrid.GetAcceptButton().Click += SaveObject;
            propGrid.GetClearButton().Click += ClearObject;
            propGrid.GetAcceptButton().Visible = true;
            propGrid.GetClearButton().Visible = true;

            propGrid.SelectedObject = obj;
        }

        private void SaveObject(object sender, EventArgs e)
        {
            RuntimeVars.Instance.SelectedPageUniqueName = ((KryptonPage)Parent).UniqueName;
            SaveObject();
        }

        #region Save Methods
        private void SaveObject()
        {
            DatabaseError e = obj.Insert();
            if (e != DatabaseError.NoError)
            {
                CRichMsgBox.Show("An error has occured while saving the object to the database. See below for more details.",
                "Error", e.ToDescriptionString(), MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }

            StatusUpdate?.Invoke(this, new StatusArgs($"{entity} {obj} created successfully."));
            CheckForAssociation();

            if (CMessageBox.Show("Create another?", "", MessageBoxButtons.YesNo, Resources.info_64x64) == DialogResult.Yes)
                Clear();
            else
            {
                if (RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.FindDockingFloating("Floating")
                    .DockingManager.ContainsPage(RuntimeVars.Instance.SelectedPageUniqueName))
                {
                    RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.FindDockingFloating("Floating")
                    .DockingManager.RemovePage(RuntimeVars.Instance.SelectedPageUniqueName, true);
                }
                else
                {
                    RuntimeVars.Instance.MainForm.DockingWorkspace.RemovePage(RuntimeVars.Instance.SelectedPageUniqueName, true);
                }
            }
        }

        private void CheckForAssociation()
        {
            if (JobHandler.Instance.ReadOnly)
                return;

            if (JobHandler.Instance.IsJobOpen)
            {
                if (entity != EntityTypes.Rate) //only associate with the open job if the object is not a Rate object.
                {
                    if (CMessageBox.Show("Associate this object with the open job?", "", MessageBoxButtons.YesNo, Resources.info_64x64) == DialogResult.Yes)
                    {
                        switch (entity)
                        {
                            case EntityTypes.Client:
                            JobHandler.Instance.CurrentJob.Client = obj as Client;
                            break;
                            case EntityTypes.Realtor:
                            JobHandler.Instance.CurrentJob.Realtor = obj as Realtor;
                            break;
                            case EntityTypes.TitleCompany:
                            JobHandler.Instance.CurrentJob.TitleCompany = obj as TitleCompany;
                            break;
                        }
                        JobHandler.Instance.UpdateSavePending(true);
                    }
                }
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
                case EntityTypes.Rate:
                obj = new Rate();
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
