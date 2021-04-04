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
    public partial class NewRealtor : KryptonForm
    {
        private Realtor realtor = new Realtor();
        private bool editMode = false;

        public EventHandler StatusUpdate;

        public NewRealtor(Realtor r = null)
        {
            InitializeComponent();

            if (r != null)
            {
                editMode = true;
                realtor = r;
            }
        }

        private void NewClient_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.realtor_16x16.GetHicon());

            clientPropGrid.GetAcceptButton().ToolTipText = "Save the realtor to the database.";
            clientPropGrid.GetClearButton().ToolTipText = "Clear all values and start over.";

            clientPropGrid.GetAcceptButton().Click += Save;
            clientPropGrid.GetClearButton().Click += ClearFields;
            

            clientPropGrid.SelectedObject = realtor;
        }

        private void Save(object sender, EventArgs e)
        {
            realtor = (Realtor)clientPropGrid.SelectedObject;
            DatabaseError clientError;

            if (!editMode)
                clientError = realtor.Insert();
            else
                clientError = realtor.Update();

            switch (clientError)
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
                    if (editMode)
                        StatusUpdate?.Invoke(this, new StatusArgs($"Realtor {realtor.Name} updated successfully."));
                    else
                        StatusUpdate?.Invoke(this, new StatusArgs($"Realtor {realtor.Name} created successfully."));
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
                realtor = new Realtor();
                clientPropGrid.SelectedObject = realtor;
            }
            else
                return;
        }
    }
}
