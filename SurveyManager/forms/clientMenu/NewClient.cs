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

namespace SurveyManager.forms.clientMenu
{
    public partial class NewClient : KryptonForm
    {
        private Client client = new Client();
        private bool editMode = false;

        public EventHandler StatusUpdate;

        public NewClient(Client c = null)
        {
            InitializeComponent();

            if (c != null)
            {
                editMode = true;
                client = c;
            }
        }

        private void NewClient_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.client_16x16.GetHicon());

            clientPropGrid.GetAcceptButton().ToolTipText = "Save the client to the database.";
            clientPropGrid.GetClearButton().ToolTipText = "Clear all values and start over.";

            clientPropGrid.GetAcceptButton().Click += SaveClient;
            clientPropGrid.GetClearButton().Click += ClearFields;
            

            clientPropGrid.SelectedObject = client;
        }

        private void SaveClient(object sender, EventArgs e)
        {
            client = (Client)clientPropGrid.SelectedObject;
            DatabaseError clientError;

            if (!editMode)
                clientError = client.Insert();
            else
                clientError = client.Update();

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
                case DatabaseError.NoError:
                {
                    if (editMode)
                        StatusUpdate?.Invoke(this, new StatusArgs($"Client {client.Name} updated successfully."));
                    else
                        StatusUpdate?.Invoke(this, new StatusArgs($"Client {client.Name} created successfully."));
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
                client = new Client();
                clientPropGrid.SelectedObject = client;
            }
            else
                return;
        }
    }
}
