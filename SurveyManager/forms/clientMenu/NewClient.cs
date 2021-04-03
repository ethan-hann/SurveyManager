using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
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

namespace SurveyManager.forms.clientMenu
{
    public partial class NewClient : KryptonForm
    {
        private readonly Client client;

        public NewClient()
        {
            InitializeComponent();

            client = new Client();
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
            Console.WriteLine("Clicked Save!");
        }

        private void ClearFields(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked Clear!");
        }
    }
}
