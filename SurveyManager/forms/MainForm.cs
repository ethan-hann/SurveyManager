﻿using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms;
using SurveyManager.forms.clientMenu;
using SurveyManager.forms.databaseMenu;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager
{
    public partial class MainForm : KryptonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatusDate.Text = DateTime.Now.ToString();

            clockTimer.Start();

            //Upgrade settings if needed - keeps settings persistent across version updates to the program
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            //Initialize the database and connection string
            Database.Initialize();

            //Check database connection
            int code = Database.CheckConnection();
            if (code != -1)
                Text = "Survey Manager - Database: <NONE>";
            else
                Text = "Survey Manager - " + $"Database: \\\\{Database.Server}\\{Database.DB}";

            //Set main form
            RuntimeVars.Instance.MainForm = this;
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblStatusDate.Text = DateTime.Now.ToString();
        }

        #region File Menu
        private void settingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {

        }

        private void checkForUpdatesBtn_Click(object sender, EventArgs e)
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    CRichMsgBox.Show("The new version of the application cannot be downloaded at this time.", "Error", $"Please check your network connection, or try again later. Error: {dde.Message}", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    CRichMsgBox.Show("Cannot check for a new version of the application.\nThe ClickOnce deployment is corrupt.", "Error", $"Please redeploy the application and try again. Error: {ide.Message}", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    CRichMsgBox.Show("This application cannot be updated.\nIt is likely not a ClickOnce application.", "Error", $"Error: {ioe.Message}", MessageBoxButtons.OK, Resources.error_64x64);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    bool doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = CMessageBox.Show($"An update is available.\nWould you like to update the application now?\nSize of Update: {Utility.FormatSize(info.UpdateSizeBytes)}", "Update Available", MessageBoxButtons.OKCancel, Resources.info_64x64);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        CMessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            Resources.warning);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            CMessageBox.Show("The application has been upgraded, and will now restart.", "Update Pending", MessageBoxButtons.OK, Resources.warning_64x64);
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            CRichMsgBox.Show("Cannot install the latest version of the application.", "Error", $"Please check your network connection, or try again later. Error: {dde}", MessageBoxButtons.OK, Resources.error_64x64);
                            return;
                        }
                    }
                }
                else
                {
                    CMessageBox.Show($"Congrats! You are running the current version.\nVersion: {Assembly.GetExecutingAssembly().GetName().Version}", "No Updates", MessageBoxButtons.OK, Resources.info_64x64);
                }
            }
            else
            {
                CRichMsgBox.Show("Cannot check for a new version of the application.\nThe ClickOnce deployment is corrupt.", "Error", $"Please redeploy the application and try again.", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Survey Menu
        #endregion

        #region Client Menu
        private void findClientBtn_Click(object sender, EventArgs e)
        {
            ArrayList columns = new ArrayList
            {
                new DBMap("name", "Name"),
                new DBMap("phone_number", "Phone #"),
                new DBMap("email_address", "Email"),
                new DBMap("fax_number", "Fax #")
            };

            AdvancedFilter filter = new AdvancedFilter("Client", columns, "Find Clients");
            filter.FilterDone += ProcessClientSearch;
            filter.Show();
        }

        private void newClientBtn_Click(object sender, EventArgs e)
        {
            NewClient ncForm = new NewClient();
            ncForm.MdiParent = this;
            ncForm.StatusUpdate += ChangeStatusText;
            ncForm.Show();
        }
        #endregion

        #region Realtor Menu
        #endregion

        #region Title Company Menu
        #endregion

        #region Database Menu
        private void dbConnectionBtn_Click(object sender, EventArgs e)
        {
            if (RuntimeVars.Instance.NumberOfDBConnectionFormsOpen == 0)
            {
                DBConnection dbForm = new DBConnection();
                dbForm.MdiParent = this;
                RuntimeVars.Instance.NumberOfDBConnectionFormsOpen++;
                dbForm.DatabaseConnectFinished += OnDBConnectDone;
                dbForm.Show();
            }
            else
            {
                CMessageBox.Show("Only 1 connection window can be opened at a time!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
            }
            
        }

        private void OnDBConnectDone(object sender, EventArgs e)
        {
            if (e is DBArgs args)
            {
                switch (args.ExceptionCode)
                {
                    case 0: //the user specified did not exist or did not have the correct permissions
                        CMessageBox.Show("The database user did not exist.\nCheck your settings and try again.", "Could not connect", MessageBoxButtons.OK, Resources.error);
                    break;
                    case 1042: //could not reach the hostname
                        CMessageBox.Show("The specified host could not be reached.\nCheck your settings and try again.", "Could not connect", MessageBoxButtons.OK, Resources.error);
                    break;
                    case -1: //all good, begin loading database data
                    {
                        if (RuntimeVars.Instance.DatabaseConnected)
                            Text = "Survey Manager - " + $"Database: \\\\{Database.Server}\\{Database.DB}";
                        break;
                    }
                    default: //unknown error; display error code for debugging
                        CMessageBox.Show($"An error occured with DB connection. Error code: {args.ExceptionCode}\nCheck your settings and try again.", "Could not connect", MessageBoxButtons.OK, Resources.error);
                    break;
                }
            }
        }
        #endregion

        #region Event Handlers
        private void ChangeStatusText(object sender, EventArgs e)
        {
            if (e is StatusArgs args)
                lblStatus.Text = args.StatusString;
        }

        private void ProcessClientSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                List<Client> clients = new List<Client>();
                foreach (DataRow row in args.Results.Rows)
                {
                    clients.Add(ProcessDataTable.GetClient(row));
                }

                ViewObjects results = new ViewObjects(args.Results, clients.ToArray(), "Name", "name", "Client Results");
                results.MdiParent = this;
                results.Show();
            }
        }
        #endregion

        #region Getters and Setters
        public KryptonPalette GetPalette()
        {
            return office2013_edited;
        }
        #endregion

        private void editClientBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
