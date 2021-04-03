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

namespace SurveyManager.forms.clientMenu
{
    public partial class NewClient : KryptonForm
    {
        private Client client = new Client();

        public EventHandler StatusUpdate;

        public NewClient()
        {
            InitializeComponent();
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

            if (client.ClientAddress.IsEmpty)
            {
                CMessageBox.Show("Client's address cannot be empty!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }

            if (client.Name.Equals(string.Empty) || client.PhoneNumber.Equals(string.Empty))
            {
                CMessageBox.Show("Client's name and phone number cannot be empty!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }

            if (Database.InsertAddress(client.ClientAddress))
            {
                int addressID = Database.GetLastRowIDInserted("Address");
                client.AddressID = addressID;

                if (Database.InsertClient(client))
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Client {client.Name} created successfully."));
                    Close();
                }
                else
                {
                    CMessageBox.Show("Could not create the client in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                }
            }
            else
            {
                CMessageBox.Show("Could not create the client's address in the database.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
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
