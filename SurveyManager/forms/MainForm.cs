using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms;
using SurveyManager.forms.databaseMenu;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.pages;
using SurveyManager.forms.surveyMenu;
using SurveyManager.forms.userControls;
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
        /// <summary>
        /// A static reference to this forms <see cref="KryptonDockingWorkspace"/>
        /// </summary>
        public static KryptonDockingWorkspace DockingWorkspace { get; private set; } = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeRibbon();

            DockingWorkspace = dockingManager.ManageWorkspace("MainWorkspace", dockableWorkspace);
            dockingManager.ManageControl("Control", kryptonPanel1, DockingWorkspace);
            dockingManager.ManageFloating("Floating", this);

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

            if (RuntimeVars.Instance.DatabaseConnected)
            {
                RuntimeVars.Instance.Counties = Database.GetCounties();
            }
        }

        private void InitializeRibbon()
        {
            KryptonContextMenuItem settingsBtn = new KryptonContextMenuItem
            {
                Text = "Settings...",
                Image = Resources.settings_24x24
            };

            KryptonContextMenuItem aboutBtn = new KryptonContextMenuItem
            {
                Text = "About...",
                Image = Resources.instrument_24x24
            };

            KryptonContextMenuItem checkUpdatesBtn = new KryptonContextMenuItem
            {
                Text = "Check for Updates...",
                Image = Resources.updated_24x24,
                ShortcutKeys = Keys.Alt | Keys.U,
                ShowShortcutKeys = true
            };

            KryptonContextMenuItem exitBtn = new KryptonContextMenuItem
            {
                Text = "Exit",
                ShortcutKeys = Keys.Alt | Keys.F4,
                ShowShortcutKeys = true
            };

            mainRibbon.RibbonAppButton.AppButtonMenuItems.Add(settingsBtn);
            mainRibbon.RibbonAppButton.AppButtonMenuItems.Add(aboutBtn);
            mainRibbon.RibbonAppButton.AppButtonMenuItems.Add(checkUpdatesBtn);
            mainRibbon.RibbonAppButton.AppButtonMenuItems.Add(exitBtn);

            settingsBtn.Click += settingsBtn_Click;
            aboutBtn.Click += aboutBtn_Click;
            checkUpdatesBtn.Click += checkForUpdatesBtn_Click;
            exitBtn.Click += exitBtn_Click;
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
            new AboutBox().ShowDialog();
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
        private void findSurveyBtn_Click(object sender, EventArgs e)
        {
            ArrayList columns = new ArrayList
            {
                new DBMap("job_number", "Job #"),
                new DBMap("client_id", "Client ID"),
                new DBMap("description", "Description"),
                new DBMap("subdivision", "Subdivision"),
                new DBMap("lot", "Lot #"),
                new DBMap("block", "Block #"),
                new DBMap("section", "Section #"),
                new DBMap("county_id", "County"),
                new DBMap("acres", "Acres"),
                new DBMap("realtor_id", "Realtor"),
                new DBMap("title_company_id", "Title Company")
            };

            AdvancedFilter filter = new AdvancedFilter("Survey", columns, "Find Surveys");
            filter.FilterDone += ProcessSurveySearch;
            filter.Show();
        }

        private void newSurveyBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new NewPage(Enums.EntityTypes.Survey);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewSurveysBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new ViewPage(Enums.EntityTypes.Survey, "Surveys");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }
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
            KryptonPage page = new NewPage(Enums.EntityTypes.Client);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewClientsBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new ViewPage(Enums.EntityTypes.Client, "Clients");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        #endregion

        #region Realtor Menu
        private void findRealtorBtn_Click(object sender, EventArgs e)
        {
            ArrayList columns = new ArrayList
            {
                new DBMap("name", "Name"),
                new DBMap("phone_number", "Phone #"),
                new DBMap("email_address", "Email"),
                new DBMap("fax_number", "Fax #")
            };

            AdvancedFilter filter = new AdvancedFilter("Realtor", columns, "Find Realtors");
            filter.FilterDone += ProcessRealtorSearch;
            filter.Show();
        }

        private void newRealtorBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new NewPage(Enums.EntityTypes.Realtor);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewRealtorsBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new ViewPage(Enums.EntityTypes.Realtor, "Realtors");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }
        #endregion

        #region Title Company Menu
        private void findTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            ArrayList columns = new ArrayList
            {
                new DBMap("name", "Name"),
                new DBMap("associate_name", "Associate's Name"),
                new DBMap("associate_email", "Associate's Email"),
                new DBMap("office_number", "Office #")
            };

            AdvancedFilter filter = new AdvancedFilter("TitleCompany", columns, "Find Title Companies");
            filter.FilterDone += ProcessTitleCompanySearch;
            filter.Show();
        }

        private void newTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new NewPage(Enums.EntityTypes.TitleCompany);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            KryptonPage page = new ViewPage(Enums.EntityTypes.TitleCompany, "Title Companies");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }
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

        private void sqlQueryBtn_Click(object sender, EventArgs e)
        {
            SQLQuery sqForm = new SQLQuery();
            sqForm.MdiParent = this;
            sqForm.StatusUpdate += ChangeStatusText;
            sqForm.Show();
        }
        #endregion

        #region Event Handlers
        public void ChangeStatusText(object sender, EventArgs e)
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

                //ViewObjectsCtl results = new ViewObjects(args.Results, clients.ToArray(), "Name", "name", "Client Results");
                //results.MdiParent = this;
                //results.Show();
            }
        }

        private void ProcessRealtorSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                List<Realtor> realtors = new List<Realtor>();
                foreach (DataRow row in args.Results.Rows)
                {
                    realtors.Add(ProcessDataTable.GetRealtor(row));
                }

                //ViewObjectsCtl results = new ViewObjects(args.Results, realtors.ToArray(), "Name", "name", "Realtor Results");
                //results.MdiParent = this;
                //results.Show();
            }
        }

        private void ProcessTitleCompanySearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                List<TitleCompany> companies = new List<TitleCompany>();
                foreach (DataRow row in args.Results.Rows)
                {
                    companies.Add(ProcessDataTable.GetTitleCompany(row));
                }

                //ViewObjectsCtl results = new ViewObjects(args.Results, companies.ToArray(), "Name", "name", "Title Company Results");
                //results.MdiParent = this;
                //results.Show();
            }
        }

        private void ProcessSurveySearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                List<Survey> surveys = new List<Survey>();
                foreach (DataRow row in args.Results.Rows)
                {
                    surveys.Add(ProcessDataTable.GetSurvey(row));
                }

                //ViewObjectsCtl results = new ViewObjects(args.Results, surveys.ToArray(), "JobNumber", "job_number", "Survey Results");
                //results.MdiParent = this;
                //results.Show();
            }
        }
        #endregion

        #region Getters and Setters
        public KryptonPalette GetPalette()
        {
            return office2013_edited;
        }


        #endregion
    }
}
