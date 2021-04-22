using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms;
using SurveyManager.forms.databaseMenu;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.fileMenu;
using SurveyManager.forms.pages;
using SurveyManager.forms.surveyMenu;
using SurveyManager.forms.userControls;
using SurveyManager.Properties;
using SurveyManager.utility;
using SurveyManager.utility.Logging;
using SurveyManager.utility.PdfGeneration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager
{
    public partial class MainForm : KryptonForm
    {
        /// <summary>
        /// A reference to this forms <see cref="KryptonDockingWorkspace"/>
        /// </summary>
        public KryptonDockingWorkspace DockingWorkspace { get; private set; } = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.RecentJobs == null)
                Settings.Default.RecentJobs = new System.Collections.Specialized.StringCollection();

            InitializeRibbon();

            mainRibbon.SelectedTab = surveyTab;

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

            if (Settings.Default.LogFilePath.Equals("Undefined"))
            {
                Settings.Default.LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SurveyManager", "logs");
                Settings.Default.Save();
            }

            if (Settings.Default.DefaultSavePath.Equals("Undefined"))
            {
                Settings.Default.DefaultSavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SurveyManager");
                Settings.Default.Save();
            }

            Directory.CreateDirectory(RuntimeVars.Instance.TempFiles.TempDir);
            Directory.CreateDirectory(Settings.Default.LogFilePath);

            RuntimeVars.Instance.LogFile = new LogFile(Settings.Default.LogFilePath);
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

            UpdateRecentDocs();

            settingsBtn.Click += settingsBtn_Click;
            aboutBtn.Click += aboutBtn_Click;
            checkUpdatesBtn.Click += checkForUpdatesBtn_Click;
            exitBtn.Click += exitBtn_Click;

            //Context Menu Actions
            //Survey Associate Client -> search for client
            ((KryptonContextMenuItem)((KryptonContextMenuItems)surveyClientContextMenu.Items[0]).Items[0]).Click += btnAssocClient_Click;
            //Survey Associate Client -> create new client
            ((KryptonContextMenuItem)((KryptonContextMenuItems)surveyClientContextMenu.Items[0]).Items[1]).Click += CreateNewClient;

            //Survey Associate Realtor -> search for realtor
            ((KryptonContextMenuItem)((KryptonContextMenuItems)surveyRealtorContextMenu.Items[0]).Items[0]).Click += btnAssocRealtor_Click;
            //Survey Associate Realtor -> create new realtor
            ((KryptonContextMenuItem)((KryptonContextMenuItems)surveyRealtorContextMenu.Items[0]).Items[1]).Click += CreateNewRealtor;

            //Survey Associate TitleCompany -> search for title company
            ((KryptonContextMenuItem)((KryptonContextMenuItems)surveyTitleCompanyContextMenu.Items[0]).Items[0]).Click += btnAssocTitleComp_Click;
            //Survey Associate TitleCompany -> create new title company
            ((KryptonContextMenuItem)((KryptonContextMenuItems)surveyTitleCompanyContextMenu.Items[0]).Items[1]).Click += CreateNewTitleCompany;
        }

        private void CreateNewClient(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddClient.ToDescriptionString()));
                return;
            }

            newClientBtn_Click(sender, e);
        }

        private void CreateNewRealtor(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddRealtor.ToDescriptionString()));
                return;
            }

            newRealtorBtn_Click(sender, e);
        }

        private void CreateNewTitleCompany(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddTitleCompany.ToDescriptionString()));
                return;
            }

            newTitleCompanyBtn_Click(sender, e);
        }

        private void UpdateRecentDocs()
        {
            mainRibbon.RibbonAppButton.AppButtonRecentDocs.Clear();

            if (Settings.Default.RecentJobs != null && Settings.Default.RecentJobs.Count > 0)
            {
                List<KryptonRibbonRecentDoc> recentJobs = new List<KryptonRibbonRecentDoc>();
                foreach (string str in Settings.Default.RecentJobs)
                {
                    KryptonRibbonRecentDoc job = new KryptonRibbonRecentDoc();
                    job.Text = str;
                    job.Click += OpenRecentJob;
                    recentJobs.Add(job);
                }
                mainRibbon.RibbonAppButton.AppButtonRecentDocs.AddRange(recentJobs.ToArray());
            }
            else
            {
                Settings.Default.RecentJobs = new System.Collections.Specialized.StringCollection();
                Settings.Default.Save();
            }
        }

        private void OpenRecentJob(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (sender is KryptonRibbonRecentDoc recentDoc)
            {
                RuntimeVars.Instance.OpenJob = Database.GetSurvey(recentDoc.Text);
                if (RuntimeVars.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs("Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " opened!"));
                    ChangeTitleText("[JOB# " + recentDoc.Text + "]");
                }
                else
                {
                    ChangeStatusText(this, new StatusArgs("The selected job no longer exists! It was probably deleted; removing from recent jobs list."));
                    if (Settings.Default.RecentJobs.Contains(recentDoc.Text))
                    {
                        Settings.Default.RecentJobs.Remove(recentDoc.Text);
                        Settings.Default.Save();
                        UpdateRecentDocs();
                    }
                }
            }
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
            ExitChoice choice = ShowCloseDialog();
            if (choice == ExitChoice.SaveAndExit)
            {
                SaveSurvey();
                CloseJob();
                Application.Exit();
            }
            else if (choice == ExitChoice.ExitNoSave)
            {
                Application.Exit();
            }
            else if (choice == ExitChoice.SaveOnly)
            {
                SaveSurvey();
            }
        }
        #endregion

        #region Client Menu
        private void findClientBtn_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

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
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new NewPage(EntityTypes.Client);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewClientsBtn_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new ViewPage(EntityTypes.Client, "Clients");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        #endregion

        #region Realtor Menu
        private void findRealtorBtn_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

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
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new NewPage(EntityTypes.Realtor);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewRealtorsBtn_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new ViewPage(Enums.EntityTypes.Realtor, "Realtors");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }
        #endregion

        #region Title Company Menu
        private void findTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

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
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new NewPage(Enums.EntityTypes.TitleCompany);
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void viewTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

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
                        Text = "Survey Manager - " + $"Database: <Not Connected>";
                        break;
                    case -1: //all good, begin loading database data
                    {
                        if (RuntimeVars.Instance.DatabaseConnected)
                            ChangeTitleText($"\\\\{Database.Server}\\{Database.DB}");
                            ChangeStatusText(this, new StatusArgs("Ready"));
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
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            SQLQuery sqForm = new SQLQuery();
            sqForm.StatusUpdate += ChangeStatusText;
            sqForm.Show();
        }
        #endregion

        #region Event Handlers
        public void ChangeStatusText(object sender, EventArgs e)
        {
            if (e is StatusArgs args)
            {
                lblStatus.Text = args.StatusString;
                RuntimeVars.Instance.LogFile.AddEntry(args.StatusString);
            }
        }

        private void ProcessClientSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                KryptonPage page = new ViewPage(Enums.EntityTypes.Client, "Clients" + $" [Filtered: {args.Results.Rows.Count} rows]", args);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void ProcessRealtorSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                KryptonPage page = new ViewPage(Enums.EntityTypes.Realtor, "Realtors" + $" [Filtered: {args.Results.Rows.Count} rows]", args);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void ProcessTitleCompanySearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                KryptonPage page = new ViewPage(Enums.EntityTypes.TitleCompany, "Title Companies" + $" [Filtered: {args.Results.Rows.Count} rows]", args);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void ProcessSurveySearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                SurveySearchResults searchResults = new SurveySearchResults(args.Results);
                searchResults.StatusUpdate += ChangeStatusText;
                searchResults.SurveyOpened += AddSurveyToRecentJobs;
                searchResults.Show();
            }
        }

        private void AddSurveyToRecentJobs(object sender, EventArgs e)
        {
            if (e is SurveyOpenedEventArgs args)
            {
                if (!Settings.Default.RecentJobs.Contains(args.Survey.JobNumber))
                {
                    Settings.Default.RecentJobs.Add(args.Survey.JobNumber);
                    Settings.Default.Save();

                    UpdateRecentDocs();
                }

                ChangeTitleText("[JOB# " + args.Survey.JobNumber + "]");
            }
        }

        private void ChangeTitleText(params string[] texts)
        {
            //TODO: Add license check
            if (texts.Length == 3)
            {
                Text = string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], texts[1], texts[2]);
            }
            else if (texts.Length == 2)
            {
                Text = string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], texts[1], string.Empty);
            }
            else if (texts.Length == 1)
            {
                if (texts[0].Contains("JOB"))
                    Text = string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", "Unlicensed Copy", texts[0]);
                else if (texts[0].Contains("\\\\"))
                {
                    if (RuntimeVars.Instance.IsJobOpen)
                        Text = string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], "Unlicensed Copy", $"[JOB# {RuntimeVars.Instance.OpenJob.JobNumber}]");
                    else
                        Text = string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], "Unlicensed Copy", "[NO JOB OPENED]");
                }
            }
            else
                Text = string.Format(StatusText.TitleText.ToDescriptionString(), "<NONE>", "Unlicensed Copy", "[NO JOB OPENED]");
        }
        #endregion

        #region Getters and Setters
        public KryptonPalette GetPalette()
        {
            return office2013_edited;
        }


        #endregion

        #region Survey Tab
        private void btnNewSurveyJob_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            string newJobNumber = KryptonInputBox.Show(this, "Enter the new job number:", "New Job", $"{DateTime.Now.Date.Year.ToString().Substring(2)}-");
            if (newJobNumber.Equals("NONE") || newJobNumber.Length <= 0)
                return;

            if (!Database.DoesSurveyExist(newJobNumber))
            {
                RuntimeVars.Instance.OpenJob = new Survey()
                {
                    JobNumber = newJobNumber,
                    SavePending = true
                };

                ChangeTitleText("[JOB# " + RuntimeVars.Instance.OpenJob.JobNumber + " OPENED]");
                ChangeStatusText(this, new StatusArgs("Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " created successfully!"));
            }
            else
            {
                CMessageBox.Show("Job# " + newJobNumber + " already exists. Try opening it instead.", "Job Already Exists", MessageBoxButtons.OK, Resources.error_64x64);
                return;
            }
        }

        private void btnOpenSurveyJob_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

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
                new DBMap("realtor_id", "Realtor ID"),
                new DBMap("title_company_id", "Title Company ID")
            };

            AdvancedFilter filter = new AdvancedFilter("Survey", columns, "Find Surveys");
            filter.FilterDone += ProcessSurveySearch;
            filter.Show();
        }

        private void btnViewAllJobs_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            KryptonPage page = new ViewPage(EntityTypes.Survey, "Surveys");
            dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
            dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
        }

        private void btnBasicInfo_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_BasicInfo.ToDescriptionString()));
                return;
            }

            KryptonPage basicInfoPage = new KryptonPage
            {
                Text = "Job Information",
                TextTitle = "Job Information",
                UniqueName = "Job Information",
                ImageSmall = Resources.instrument_16x16,
                ImageMedium = Resources.instrument_24x24,
                ImageLarge = Resources.instrument,
                Tag = SurveyPage.IsSurveyPage
            };
            InfoCtl ctl = new InfoCtl()
            {
                Dock = DockStyle.Fill
            };
            ctl.StatusUpdate += ChangeStatusText;

            basicInfoPage.Controls.Add(ctl);

            if (!dockingManager.ContainsPage(basicInfoPage))
            {
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { basicInfoPage });
            }
            else
            {
                dockingManager.RemovePage(basicInfoPage, true);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { basicInfoPage });
            }
        }

        private void btnOpenViewPanel_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_View.ToDescriptionString()));
                return;
            }

            KryptonPage viewPanel = new KryptonPage
            {
                Text = "Job #: " + RuntimeVars.Instance.OpenJob.JobNumber + " Info",
                TextTitle = "Job #: " + RuntimeVars.Instance.OpenJob.JobNumber + " Info",
                UniqueName = "Job #: " + RuntimeVars.Instance.OpenJob.JobNumber + " Info",
                ImageSmall = Resources.view_16x16,
                ImageLarge = Resources.view,
                Tag = SurveyPage.IsSurveyPage
            };
            viewPanel.Controls.Add(new ViewPanel()
            {
                Dock = DockStyle.Fill
            });

            if (!dockingManager.ContainsPage(viewPanel))
            {
                dockingManager.AddDockspace("Control", DockingEdge.Right, new KryptonPage[] { viewPanel });
            }
            else
            {
                dockingManager.RemovePage(viewPanel, true);
                dockingManager.AddDockspace("Control", DockingEdge.Right, new KryptonPage[] { viewPanel });
            }
        }

        private void btnSaveSurvey_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            SaveSurvey();
        }

        private bool SaveSurvey()
        {
            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_Save.ToDescriptionString()));
                return false;
            }

            if (!RuntimeVars.Instance.OpenJob.IsValidSurvey)
            {
                CMessageBox.Show("The survey job does not have all of the required information needed for saving. Please add more information and try again.", "Not enough information", MessageBoxButtons.OK, Resources.error_64x64);
                return false;
            }

            ChangeStatusText(this, new StatusArgs("Saving Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " to the database..."));
            progressBar.Visible = true;
            saveDataBackgroundWorker.RunWorkerAsync();
            return true;
        }

        private bool isClosingJob = false;
        private void btnCloseCurrentJob_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_Close.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.OpenJob.SavePending)
            {
                CloseJob();
                return;
            }

            DialogResult result = CMessageBox.Show("Save changes?", "Confirm", MessageBoxButtons.YesNoCancel, Resources.save_64x64);
            switch (result)
            {
                case DialogResult.Yes:
                {
                    if (!RuntimeVars.Instance.OpenJob.IsValidSurvey)
                    {
                        CMessageBox.Show("The survey job does not have all of the required information needed for saving. Please add more information and try again.", "Not enough information", MessageBoxButtons.OK, Resources.error_64x64);
                        break;
                    }
                    ChangeStatusText(this, new StatusArgs("Saving Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " to the database..."));
                    progressBar.Visible = true;
                    saveDataBackgroundWorker.RunWorkerAsync();
                    isClosingJob = true;
                    break;
                }
                case DialogResult.No:
                    CloseJob();
                    break;
                case DialogResult.Cancel:
                    ChangeStatusText(this, new StatusArgs("Closing of job " + RuntimeVars.Instance.OpenJob.JobNumber + " canceled."));
                    break;
            }
        }

        DatabaseError surveyError;
        private void saveDataBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (RuntimeVars.Instance.OpenJob.ID == 0)
                surveyError = RuntimeVars.Instance.OpenJob.Insert();
            else
                surveyError = RuntimeVars.Instance.OpenJob.Update();

            if (surveyError == DatabaseError.NoError)
            {
                RuntimeVars.Instance.OpenJob.SavePending = false;
            }
        }

        private void saveDataBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void saveDataBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (surveyError != DatabaseError.NoError)
            {
                RuntimeVars.Instance.OpenJob.SavePending = false;
                CMessageBox.Show("Something went wrong while trying to save the job. Check the information and try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                ChangeStatusText(this, new StatusArgs("Saving of Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " failed!"));
                progressBar.Visible = false;
                return;
            }

            progressBar.Visible = false;
            ChangeStatusText(this, new StatusArgs("Job# " + RuntimeVars.Instance.OpenJob.JobNumber + " saved successfully!"));
            AddSurveyToRecentJobs(this, new SurveyOpenedEventArgs(RuntimeVars.Instance.OpenJob));

            if (isClosingJob)
                CloseJob();

            RuntimeVars.Instance.LogFile.WriteToFile();
        }

        private void CloseJob()
        {
            ChangeTitleText("[NO JOB OPENED]");
            
            RuntimeVars.Instance.OpenJob = null;

            //remove pages that are considered survey pages
            dockingManager.RemovePages(dockingManager.Pages.Where(p => ((SurveyPage)p.Tag) == SurveyPage.IsSurveyPage).ToArray(), true);

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (!Application.OpenForms[i].Equals(this))
                    Application.OpenForms[i].Close();
            }

            ChangeStatusText(this, new StatusArgs("Ready"));
            isClosingJob = false;
        }

        private void btnAddNewFile_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AttachFile.ToDescriptionString()));
                return;
            }

            UploadFile uploadForm = new UploadFile(RuntimeVars.Instance.OpenJob.Files);
            uploadForm.FileUploadDone += AddFiles;
            uploadForm.StatusUpdate += ChangeStatusText;
            uploadForm.Show();
        }

        private void AddFiles(object sender, EventArgs e)
        {
            if (e is FileUploadDoneArgs args)
            {
                RuntimeVars.Instance.OpenJob.SetFiles(args.Files);
                RuntimeVars.Instance.OpenJob.SavePending = true;
            }
        }

        private void btnViewAllFiles_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_ViewFiles.ToDescriptionString()));
                return;
            }

            FileBrowser fb = new FileBrowser(RuntimeVars.Instance.OpenJob.Files);
            fb.StatusUpdate += ChangeStatusText;
            fb.Show();
        }

        private void btnBillingRates_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_EditRates.ToDescriptionString()));
                return;
            }

            RatesDialog rDialog = new RatesDialog();
            rDialog.StatusUpdate += ChangeStatusText;
            rDialog.Show();
        }

        private void btnFieldTime_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddTime.ToDescriptionString()));
                return;
            }

            TimeEntry te = new TimeEntry(TimeType.Field);
            te.Show();
        }

        private void btnOfficeTime_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddTime.ToDescriptionString()));
                return;
            }

            TimeEntry te = new TimeEntry(TimeType.Office);
            te.Show();
        }

        private void btnBillingLineItems_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddBillingItems.ToDescriptionString()));
                return;
            }

            KryptonPage lineItemPanel = new KryptonPage
            {
                Text = "Billing Items",
                TextTitle = "Billing Items",
                UniqueName = "Billing Items",
                ImageSmall = Resources.billing_line_items_16x16,
                ImageLarge = Resources.billing_line_items,
                Tag = SurveyPage.IsSurveyPage
            };
            LineItemsCtl ctl = new LineItemsCtl(RuntimeVars.Instance.OpenJob.BillingLineItems);
            ctl.StatusUpdate += ChangeStatusText;
            ctl.Dock = DockStyle.Fill;
            lineItemPanel.Controls.Add(ctl);

            if (!dockingManager.ContainsPage(lineItemPanel))
            {
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { lineItemPanel });
            }
            else
            {
                dockingManager.RemovePage(lineItemPanel, true);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { lineItemPanel });
            }
        }

        private void btnCurrentBill_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_OpenBill.ToDescriptionString()));
                return;
            }

            string fileName = $"BillingReport-{RuntimeVars.Instance.OpenJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}";
            PDF.CreateDocument(fileName,
                    $"BillingReport-{RuntimeVars.Instance.OpenJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}", "CSM", "", 
                    $"Billing Report - Job: {RuntimeVars.Instance.OpenJob.JobNumber} - Date: {DateTime.Now}", Fonts.TimesNewRoman, true, true, false, 12);
            PDF.GenerateBillingReport(RuntimeVars.Instance.OpenJob);

            string path = Path.Combine(Settings.Default.DefaultSavePath, $"{fileName}.pdf");
            Process.Start(path);
        }

        private void btnAssocClient_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddClient.ToDescriptionString()));
                return;
            }

            ArrayList columns = new ArrayList
            {
                new DBMap("name", "Name"),
                new DBMap("phone_number", "Phone #"),
                new DBMap("email_address", "Email"),
                new DBMap("fax_number", "Fax #")
            };

            AdvancedFilter filter = new AdvancedFilter("Client", columns, "Find Clients");
            filter.FilterDone += SelectClient;
            filter.Show();
        }

        private void SelectClient(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                SearchResults resultsForm = new SearchResults(args.Results, EntityTypes.Client);
                resultsForm.StatusUpdate += ChangeStatusText;
                resultsForm.ObjectSelected += AssociateClient;
                resultsForm.Show();
            }
        }

        private void AssociateClient(object sender, EventArgs e)
        {
            if (e is DBObjectArgs args)
            {
                RuntimeVars.Instance.OpenJob.Client = args.Object as Client;
                RuntimeVars.Instance.OpenJob.SavePending = true;
            }
        }

        private void btnAssocRealtor_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddRealtor.ToDescriptionString()));
                return;
            }

            ArrayList columns = new ArrayList
            {
                new DBMap("name", "Name"),
                new DBMap("phone_number", "Phone #"),
                new DBMap("email_address", "Email"),
                new DBMap("fax_number", "Fax #")
            };

            AdvancedFilter filter = new AdvancedFilter("Realtor", columns, "Find Realtors");
            filter.FilterDone += SelectRealtor;
            filter.Show();
        }

        private void SelectRealtor(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                SearchResults resultsForm = new SearchResults(args.Results, EntityTypes.Realtor);
                resultsForm.StatusUpdate += ChangeStatusText;
                resultsForm.ObjectSelected += AssociateRealtor;
                resultsForm.Show();
            }
        }

        private void AssociateRealtor(object sender, EventArgs e)
        {
            if (e is DBObjectArgs args)
            {
                RuntimeVars.Instance.OpenJob.Realtor = args.Object as Realtor;
                RuntimeVars.Instance.OpenJob.SavePending = true;
            }
        }

        private void btnAssocTitleComp_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddTitleCompany.ToDescriptionString()));
                return;
            }

            ArrayList columns = new ArrayList
            {
                new DBMap("name", "Name"),
                new DBMap("associate_name", "Associate's Name"),
                new DBMap("associate_email", "Associate's Email"),
                new DBMap("office_number", "Office #")
            };

            AdvancedFilter filter = new AdvancedFilter("TitleCompany", columns, "Find Title Companies");
            filter.FilterDone += SelectTitleCompany;
            filter.Show();
        }

        private void SelectTitleCompany(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                SearchResults resultsForm = new SearchResults(args.Results, EntityTypes.TitleCompany);
                resultsForm.StatusUpdate += ChangeStatusText;
                resultsForm.ObjectSelected += AssociateTitleCompany;
                resultsForm.Show();
            }
        }

        private void AssociateTitleCompany(object sender, EventArgs e)
        {
            if (e is DBObjectArgs args)
            {
                RuntimeVars.Instance.OpenJob.TitleCompany = args.Object as TitleCompany;
                RuntimeVars.Instance.OpenJob.SavePending = true;
            }
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            if (!RuntimeVars.Instance.DatabaseConnected)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                return;
            }

            if (!RuntimeVars.Instance.IsJobOpen)
            {
                ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddNotes.ToDescriptionString()));
                return;
            }

            KryptonPage notesPanel = new KryptonPage
            {
                Text = "Notes",
                TextTitle = "Notes",
                UniqueName = "Notes",
                ImageSmall = Resources.notes_16x16,
                ImageLarge = Resources.notes,
                Tag = SurveyPage.IsSurveyPage
            };

            NotesCtl ctl = new NotesCtl(RuntimeVars.Instance.OpenJob.Notes);
            ctl.StatusUpdate += ChangeStatusText;
            ctl.Dock = DockStyle.Fill;
            notesPanel.Controls.Add(ctl);

            if (!dockingManager.ContainsPage(notesPanel))
            {
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { notesPanel });
            }
            else
            {
                dockingManager.RemovePage(notesPanel, true);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { notesPanel });
            }
        }
        #endregion

        private void dockingManager_DockableWorkspaceCellAdding(object sender, DockableWorkspaceCellEventArgs e)
        {
            KryptonWorkspaceCell currentCell = e.CellControl;

            currentCell.Bar.ItemAlignment = RelativePositionAlign.Center;
            currentCell.Bar.TabStyle = TabStyle.OneNote;
            currentCell.Bar.TabBorderStyle = TabBorderStyle.OneNote;
            currentCell.NavigatorMode = NavigatorMode.BarTabGroup;
            currentCell.Group.GroupBackStyle = PaletteBackStyle.ControlClient;
            currentCell.Group.GroupBorderStyle = PaletteBorderStyle.ControlClient;
        }

        private ExitChoice ShowCloseDialog()
        {
            if (RuntimeVars.Instance.IsJobOpen)
            {
                if (RuntimeVars.Instance.OpenJob.SavePending)
                {
                    return CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened survey job. What would you like to do?", "Save Changes", MessageBoxButtons.OKCancel, Resources.warning_64x64);
                }
                else
                {
                    return ExitChoice.ExitNoSave;
                }
            }
            else
            {
                return ExitChoice.ExitNoSave;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
                Application.Exit();

            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.FormOwnerClosing)
            {
                ExitChoice choice = ShowCloseDialog();
                if (choice == ExitChoice.SaveAndExit)
                {
                    SaveSurvey();
                    CloseJob();
                    Application.Exit();
                }
                else if (choice == ExitChoice.ExitNoSave)
                {
                    Application.Exit();
                }
                else if (choice == ExitChoice.SaveOnly)
                {
                    SaveSurvey();
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            checkConnectionBGWorker.RunWorkerAsync();
            ChangeStatusText(this, new StatusArgs("Checking existing database connection. Please wait..."));
        }

        int code;
        private void checkConnectionBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Initialize the database and connection string
            Database.Initialize();

            //Check database connection
            code = Database.CheckConnection();
        }

        private void checkConnectionBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void checkConnectionBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (code != -1)
            {
                ChangeTitleText("", "", "", "");
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
            }
            else
            {
                ChangeTitleText($"\\\\{Database.Server}\\{Database.DB}", "Unlicensed Copy", "[NO JOB OPENED]");
                ChangeStatusText(this, new StatusArgs("Ready"));
            }
                
            progressBar.Visible = false;

            //Set main form
            RuntimeVars.Instance.MainForm = this;

            if (RuntimeVars.Instance.DatabaseConnected)
            {
                RuntimeVars.Instance.Counties = Database.GetCounties();
            }
        }
    }
}
