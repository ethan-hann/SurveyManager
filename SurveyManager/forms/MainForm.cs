using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.databaseMenu;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.fileMenu;
using SurveyManager.forms.pages;
using SurveyManager.forms.surveyMenu;
using SurveyManager.forms.surveyMenu.basicInfo;
using SurveyManager.Properties;
using SurveyManager.utility;
using SurveyManager.utility.Licensing;
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
using System.Threading;
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

        private delegate void SafeCallChangeStatusText(string text);
        private SafeCallChangeStatusText del;

        private ActivationDlg activationDialog = new ActivationDlg();
        private bool licensed = false; //always assume we are unlicensed until we've checked the product key

        public MainForm()
        {
            InitializeComponent();

            del = new SafeCallChangeStatusText(UpdateStatusFromOtherThread);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatusDate.Text = DateTime.Now.ToString();

            //Check for recent jobs
            if (Settings.Default.RecentJobs == null)
                Settings.Default.RecentJobs = new System.Collections.Specialized.StringCollection();

            //Set up the ribbon UI
            InitializeRibbon();

            //Create our docking heirarchy
            InitializeDock();

            //Set and enable autosave timers
            InitializeAutoSave();

            //Create, if they dont exist, the temporary files and the log file path
            InitializeDirectories();

            //Upgrade settings if needed - keeps settings persistent across version updates to the program
            InitializeSettings();

            //Ask if user wants desktop shortcut created
            CheckForControlPanelIcon();

            //Check license statuses
            InitializeLicensing();

            //Subscribe to events from the JobHandler
            InitializeJobHandler();
        }

        private void InitializeDock()
        {
            DockingWorkspace = dockingManager.ManageWorkspace("MainWorkspace", dockableWorkspace);
            dockingManager.ManageControl("Control", borderPanel, DockingWorkspace);
            dockingManager.ManageFloating("Floating", this);
        }

        private void InitializeAutoSave()
        {
            clockTimer.Start();

            surveyAutosave.Interval = (int)TimeSpan.FromMinutes(Settings.Default.SurveyAutoSaveInterval).TotalMilliseconds;
            logAutoSave.Interval = (int)TimeSpan.FromMinutes(Settings.Default.LogAutoSaveInterval).TotalMilliseconds;

            surveyAutosave.Enabled = Settings.Default.SurveyAutoSaveEnabled;
            logAutoSave.Enabled = true;

            if (surveyAutosave.Enabled)
                surveyAutosave.Start();

            if (logAutoSave.Enabled)
                logAutoSave.Start();
        }

        private void InitializeDirectories()
        {
            Directory.CreateDirectory(RuntimeVars.Instance.TempFiles.TempDir);
            Directory.CreateDirectory(Settings.Default.LogFilePath);

            //Set log file
            RuntimeVars.Instance.LogFile = new LogFile(Settings.Default.LogFilePath);
            if (!Settings.Default.OverwriteLogFile)
                RuntimeVars.Instance.LogFile.FileName = Guid.NewGuid().ToString().Substring(0, 10) + DateTime.Now.Date.ToString("MM-dd-yyyy") + ".log";
        }

        private void InitializeSettings()
        {
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
        }

        private void CheckForControlPanelIcon()
        {
            //only run if deployed 
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    //the icon is included in this program
                    string iconSourcePath = Path.Combine(Application.StartupPath, "logo.ico");

                    if (!File.Exists(iconSourcePath))
                    {
                        RuntimeVars.Instance.LogFile.AddEntry("Icon file for application not found!");
                        return;
                    }

                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString().Equals("Survey Manager"))
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    RuntimeVars.Instance.LogFile.AddEntry("Could not create icon for Control Panel - Add/Remove Programs!");
                }
            }
            else
            {
                RuntimeVars.Instance.LogFile.AddEntry("Application is not a ClickOnce deployment! Can not change icon in registry.");
            }
        }

        private void InitializeLicensing()
        {
            //Ensure that we have the correct key for the licensing API
            if (Settings.Default.DeveloperName.Length <= 0 || Settings.Default.DeveloperKey.Length <= 0)
            {
                EllipterActivation ellActivation = new EllipterActivation();
                DialogResult result = ellActivation.ShowDialog();
                if (result != DialogResult.OK)
                    Application.Exit(); //if we dont, exit the application because the licensing API won't work.
            }

            //Check product key and set license status
            InitializeLicense();
        }

        private void InitializeJobHandler()
        {
            JobHandler.Instance.JobOpening += ChangeStatusText;
            JobHandler.Instance.JobOpened += ChangeStatusText;
            JobHandler.Instance.JobClosing += ChangeStatusText;
            JobHandler.Instance.JobClosed += ChangeStatusText;
            JobHandler.Instance.JobSaving += ChangeStatusText;
            JobHandler.Instance.JobSaved += ChangeStatusText;
            JobHandler.Instance.StatusUpdate += ChangeStatusText;
        }

        private void UpdateStatusFromOtherThread(string statusText)
        {
            ChangeStatusText(this, new StatusArgs(statusText));
        }

        private void surveyAutosave_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.SurveyAutoSaveEnabled)
            {
                if (JobHandler.Instance.IsJobOpen)
                {
                    if (JobHandler.Instance.CurrentJobState != JobState.Saving)
                    {
                        if (JobHandler.Instance.SaveJob())
                        {
                            ChangeStatusText(this, new StatusArgs($"Autosave completed for Job# {JobHandler.Instance.CurrentJob.JobNumber}."));
                        }
                    }
                }
            }
        }

        private void logAutoSave_Tick(object sender, EventArgs e)
        {
            RuntimeVars.Instance.LogFile.WriteToFile();
        }

        public void SetSurveyAutosaveInterval(int minutes)
        {
            surveyAutosave.Stop();
            surveyAutosave.Interval = (int)TimeSpan.FromMinutes(minutes).TotalMilliseconds;
            surveyAutosave.Start();
        }

        public void SetLogAutosaveInterval(int minutes)
        {
            logAutoSave.Stop();
            logAutoSave.Interval = (int)TimeSpan.FromMinutes(minutes).TotalMilliseconds;
            logAutoSave.Start();
        }

        private void InitializeLicense()
        {
            RuntimeVars.Instance.License = LicenseEngine.GetLicenseInfo(Settings.Default.ProductKey);
            if (RuntimeVars.Instance.License.IsEmpty)
            {
                licensed = false;
                SetLicenseStatus(this, new LicensingEventArgs(RuntimeVars.Instance.License, CloseReasons.Unlicensed));
            }
            else
            {
                //If the license type is a trial and today is the day of the trial expiration, show message and let user know.
                if (RuntimeVars.Instance.License.Type == LicenseType.Trial & DateTime.Now.Date >= RuntimeVars.Instance.License.ExpirationDate.Date)
                {
                    licensed = false;
                    CMessageBox.Show("Your trial period has ended. Please purchase a new product key or request a new trial key. " +
                    "Most features are disabled until the product is activated.", "End of Trial", MessageBoxButtons.OK, Resources.warning_64x64);
                    Settings.Default.ProductKey = "Unlicensed";
                    Settings.Default.Save();

                    RuntimeVars.Instance.LogFile.AddEntry("Trial has ended. Features are disabled.");

                    SetLicenseStatus(this, new LicensingEventArgs(LicenseInfo.CreateUnlicensedInfo(), CloseReasons.Unlicensed));
                    return;
                }

                //Otherwise, assume it to be a full key and set the license.
                licensed = true;
                RuntimeVars.Instance.LogFile.AddEntry("Product is licensed! All features are enabled.");
                SetLicenseStatus(this, new LicensingEventArgs(RuntimeVars.Instance.License, CloseReasons.Licensed));
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

            mainRibbon.SelectedTab = surveyTab;
        }

        private void CreateNewClient(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddClient.ToDescriptionString()));
                    return;
                }

                newClientBtn_Click(sender, e);
            }
        }

        private void CreateNewRealtor(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddRealtor.ToDescriptionString()));
                    return;
                }

                newRealtorBtn_Click(sender, e);
            }
        }

        private void CreateNewTitleCompany(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddTitleCompany.ToDescriptionString()));
                    return;
                }

                newTitleCompanyBtn_Click(sender, e);
            }
        }

        public void UpdateRecentDocs()
        {
            mainRibbon.RibbonAppButton.AppButtonRecentDocs.Clear();

            if (Settings.Default.RecentJobs != null && Settings.Default.RecentJobs.Count > 0)
            {
                List<KryptonRibbonRecentDoc> recentJobs = new List<KryptonRibbonRecentDoc>();
                foreach (string str in Settings.Default.RecentJobs)
                {
                    KryptonRibbonRecentDoc job = new KryptonRibbonRecentDoc();
                    string[] parts = str.Split('\t');
                    if (parts.Length == 2)
                    {
                        string jobNumber = parts[0];
                        DateTime last_updated = DateTime.Parse(parts[1]);
                        job.Text = jobNumber;
                        job.ExtraText = last_updated.ToString("M/dd/yyyy h:mm:ss tt");
                        job.Click += OpenRecentJob;
                        recentJobs.Add(job);
                    }
                    recentJobs.Sort(new CompareRecentJobs()); //sort the items in the list based on the last accessed date
                    recentJobs.Reverse();
                    recentJobs = recentJobs.Take(10).ToList(); //ensure we only show up to 10 items in the list
                }
                mainRibbon.RibbonAppButton.AppButtonRecentDocs.AddRange(recentJobs.ToArray());
            }
            else
            {
                Settings.Default.RecentJobs = new System.Collections.Specialized.StringCollection();
                Settings.Default.Save();
            }
        }

        private class CompareRecentJobs : IComparer<KryptonRibbonRecentDoc>
        {
            public int Compare(KryptonRibbonRecentDoc x, KryptonRibbonRecentDoc y)
            {
                DateTime xD = DateTime.Parse(x.ExtraText);
                DateTime yD = DateTime.Parse(y.ExtraText);
                return xD.CompareTo(yD);
            }
        }

        private void OpenRecentJob(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (sender is KryptonRibbonRecentDoc recentDoc)
                {
                    if (JobHandler.Instance.OpenJob(recentDoc.Text))
                    {
                        ChangeTitleText("[JOB# " + recentDoc.Text + "]");
                    }

                    if (JobHandler.Instance.CurrentJobState == JobState.InvalidJob || JobHandler.Instance.CurrentJobState == JobState.OpenError)
                    {
                        ChangeStatusText(this, new StatusArgs("The selected job no longer exists! It was probably deleted or never existed. Removing from recent jobs list..."));
                        if (Settings.Default.RecentJobs.Contains($"{recentDoc.Text}\t{recentDoc.ExtraText}"))
                        {
                            Settings.Default.RecentJobs.Remove($"{recentDoc.Text}\t{recentDoc.ExtraText}");
                            Settings.Default.Save();
                            UpdateRecentDocs();
                        }
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
            new AppSettings().ShowDialog();
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
                    CMessageBox.Show($"Congrats! You are running the latest version.\nVersion: {Assembly.GetExecutingAssembly().GetName().Version}", "No Updates", MessageBoxButtons.OK, Resources.info_64x64);
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
                JobHandler.Instance.SaveJob();
                JobHandler.Instance.CloseJob();
                Application.Exit();
            }
            else if (choice == ExitChoice.ExitNoSave)
            {
                Application.Exit();
            }
            else if (choice == ExitChoice.SaveOnly)
            {
                JobHandler.Instance.SaveJob();
            }
        }
        #endregion

        #region Client Menu
        private void findClientBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void newClientBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void viewClientsBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        #endregion

        #region Realtor Menu
        private void findRealtorBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void newRealtorBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void viewRealtorsBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }
        #endregion

        #region Title Company Menu
        private void findTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void newTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void viewTitleCompanyBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void btnFindRate_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                ArrayList columns = new ArrayList
                {
                    new DBMap("description", "Description"),
                    new DBMap("amount", "Amount"),
                    new DBMap("time_unit", "Time Unit")
                };

                AdvancedFilter filter = new AdvancedFilter("Rates", columns, "Find Rates");
                filter.FilterDone += ProcessRateSearch;
                filter.Show();
            }
        }

        private void btnNewRate_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                KryptonPage page = new NewPage(EntityTypes.Rate);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void btnViewAllRates_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                KryptonPage page = new ViewPage(EntityTypes.Rate, "Rates");
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        #endregion

        #region Database Menu
        private void dbConnectionBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void OnDBConnectDone(object sender, EventArgs e)
        {
            if (e is DBArgs args)
            {
                switch (args.ExceptionCode)
                {
                    case 0: //the user specified did not exist or did not have the correct permissions
                    CMessageBox.Show("The database user did not exist or does not have the appropiate permissions.\nCheck your settings and try again.", "Could not connect", MessageBoxButtons.OK, Resources.error);
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

        private void exportDataBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (csvSaveFolder.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Visible = true;
                    dumpDatabaseBGWorker.RunWorkerAsync();
                }
            }
        }

        private void dumpDatabaseBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DataTable> tables = new List<DataTable>();
            DataTable tableInfos = Database.GetTableInfo();
            del.Invoke("Getting tables from database...");
            Thread.Sleep(600);

            foreach (DataRow row in tableInfos.Rows)
            {
                tables.Add(Database.ExecuteFilter(Queries.BuildQuery(QType.SELECT, row[0].ToString())));
                del.Invoke($"Dumping table: {row[0]}");
            }

            CSVHelper.DumpTables(tables, csvSaveFolder.SelectedPath);
        }

        private void dumpDatabaseBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void dumpDatabaseBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            progressBar.Value = 0;
            ChangeStatusText(this, new StatusArgs($"Database information dumped successfully to: {csvSaveFolder.SelectedPath}"));
        }

        private void sqlQueryBtn_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }
        #endregion

        #region Event Handlers
        public void ChangeStatusText(object sender, EventArgs e)
        {
            if (e is StatusArgs args)
            {
                lblStatus.Text = args.StatusString;
                RuntimeVars.Instance.LogFile.AddEntry(args.StatusString);
                RuntimeVars.Instance.LogFile.WriteToFile();
            }
        }

        private void ProcessClientSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                int rowCount = args.Results.Rows.Count;
                KryptonPage page = new ViewPage(EntityTypes.Client, "Clients" + $" [Filtered: {(rowCount > 1 ? $"{rowCount} rows" : $"{rowCount} row")}]", args);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void ProcessRealtorSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                int rowCount = args.Results.Rows.Count;
                KryptonPage page = new ViewPage(EntityTypes.Realtor, "Realtors" + $" [Filtered: {(rowCount > 1 ? $"{rowCount} rows" : $"{rowCount} row")}]", args);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void ProcessTitleCompanySearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                int rowCount = args.Results.Rows.Count;
                KryptonPage page = new ViewPage(EntityTypes.TitleCompany, "Title Companies" + $" [Filtered: {(rowCount > 1 ? $"{rowCount} rows" : $"{rowCount} row")}]", args);
                dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
            }
        }

        private void ProcessRateSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                int rowCount = args.Results.Rows.Count;
                KryptonPage page = new ViewPage(EntityTypes.Rate, "Rates" + $" [Filtered: {(rowCount > 1 ? $"{rowCount} rows" : $"{rowCount} row")}]", args);
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
                searchResults.SurveyOpened += UpdateTitleAfterSurveyOpened;
                searchResults.Show();
            }
        }

        private void UpdateTitleAfterSurveyOpened(object sender, EventArgs e)
        {
            if (e is SurveyOpenedEventArgs args)
            {
                ChangeTitleText("[JOB# " + args.Survey.JobNumber + "]");
                JobHandler.Instance.AddSurveyToRecentJobs();
            }
        }

        public void ChangeTitleText(params string[] texts)
        {
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
                    Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", "Unlicensed Copy", texts[0]) :
                        string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                            + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"{texts[0]}{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
                else if (texts[0].Contains("\\\\"))
                {
                    if (JobHandler.Instance.IsJobOpen)
                        Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], "Unlicensed Copy", $"[JOB# {JobHandler.Instance.CurrentJob.JobNumber} OPEN BUT DISABLED]") :
                            string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                                + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"[JOB# {JobHandler.Instance.CurrentJob.JobNumber}]{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
                    else
                        Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], "Unlicensed Copy", "[JOBS DISABLED]") :
                            string.Format(StatusText.TitleText.ToDescriptionString(), texts[0], $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                                + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"[NO JOB OPEN]{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
                }
            }
            else
                Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), "<NO CONNECTION>", "Unlicensed Copy", "[JOBS DISABLED]") :
                    string.Format(StatusText.TitleText.ToDescriptionString(), "<NO CONNECTION>", $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                        + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"[NO JOB OPEN]{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
        }

        private void UpdateTitleText()
        {
            if (JobHandler.Instance.IsJobOpen)
                Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", "Unlicensed Copy", $"[JOB# {JobHandler.Instance.CurrentJob.JobNumber}]") :
                    string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                        + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"[JOB# {JobHandler.Instance.CurrentJob.JobNumber}]{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
            else
            {
                if (RuntimeVars.Instance.DatabaseConnected)
                    Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", "Unlicensed Copy", "[JOBS DISABLED]") :
                    string.Format(StatusText.TitleText.ToDescriptionString(), $"\\\\{Database.Server}\\{Database.DB}", $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                        + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"[NO JOB OPEN]{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
                else
                    Text = licensed == false ? string.Format(StatusText.TitleText.ToDescriptionString(), "<NO CONNECTION>", "Unlicensed Copy", "[JOBS DISABLED]") :
                    string.Format(StatusText.TitleText.ToDescriptionString(), "<NO CONNECTION>", $"Licensed to: {RuntimeVars.Instance.License.CustomerName}"
                        + (RuntimeVars.Instance.License.Type == LicenseType.Trial ? $" (Trial: {(RuntimeVars.Instance.License.ExpirationDate - DateTime.Now).Days + 1} days remaining)" : ""), $"[NO JOB OPEN]{(JobHandler.Instance.ReadOnly ? " - READ-ONLY" : "")}");
            }
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
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                string prefix = $"{DateTime.Now.Date.Year.ToString().Substring(2)}-";
                if (!Settings.Default.DefaultJobPrefixEnabled)
                    prefix = Settings.Default.SurveyJobPrefix + "-";

                string newJobNumber = KryptonInputBox.Show(this, "Enter the new job number:", "New Job", prefix);
                if (newJobNumber.Equals("NONE") || newJobNumber.Length <= 0)
                    return;

                if (JobHandler.Instance.CreateJob(newJobNumber))
                {
                    ChangeTitleText("[JOB# " + newJobNumber + "]");
                }
            }
        }

        private void btnOpenSurveyJob_Click(object sender, EventArgs e)
        {
            if (licensed)
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
                    new DBMap("abstract_number", "Abstract"),
                    new DBMap("survey_name", "Survey Name"),
                    new DBMap("lot", "Lot #"),
                    new DBMap("block", "Block #"),
                    new DBMap("section", "Section #"),
                    new DBMap("county_id", "County"),
                    new DBMap("acres", "Acres"),
                    new DBMap("realtor_id", "Realtor ID"),
                    new DBMap("title_company_id", "Title Company ID")
                };

                //TODO: add correct search filter for county
                AdvancedFilter filter = new AdvancedFilter("Survey", columns, "Find Surveys");
                filter.FilterDone += ProcessSurveySearch;
                filter.Show();
            }
        }

        private void btnViewAllJobs_Click(object sender, EventArgs e)
        {
            if (licensed)
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
        }

        private void btnToggleReadOnly_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                JobHandler.Instance.ReadOnly = !JobHandler.Instance.ReadOnly;

                if (JobHandler.Instance.ReadOnly)
                {
                    btnToggleReadOnly.ImageLarge = Resources.toggle_on_64x64;
                    btnToggleReadOnly.ImageSmall = Resources.toggle_on_16x16;

                    borderPanel.StateNormal.Color1 = Color.Red;
                }
                else
                {
                    btnToggleReadOnly.ImageLarge = Resources.toggle_off_64x64;
                    btnToggleReadOnly.ImageSmall = Resources.toggle_off_16x16;

                    borderPanel.StateNormal.Color1 = Color.FromArgb(255, 224, 192);
                }

                UpdateTitleText();
            }
        }

        private void btnBasicInfo_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
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
        }

        private void btnOpenViewPanel_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                KryptonPage viewPage = new KryptonPage();
                ViewPanel panel = new ViewPanel();
                panel.Dock = DockStyle.Fill;

                if (!JobHandler.Instance.IsJobOpen)
                {
                    viewPage = new KryptonPage
                    {
                        Text = "No Job Opened",
                        TextTitle = "No Job Opened",
                        UniqueName = "No Job Opened",
                        ImageSmall = Resources.view_16x16,
                        ImageLarge = Resources.view
                    };
                    viewPage.Controls.Add(panel);
                    panel.CreateEmptyJob();
                }
                else
                {
                    viewPage = new KryptonPage
                    {
                        Text = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info",
                        TextTitle = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info",
                        UniqueName = "Job #: " + JobHandler.Instance.CurrentJob.JobNumber + " Info",
                        ImageSmall = Resources.view_16x16,
                        ImageLarge = Resources.view
                    };
                    viewPage.Controls.Add(panel);
                }

                if (!dockingManager.ContainsPage(viewPage))
                {
                    dockingManager.AddDockspace("Control", DockingEdge.Right, new KryptonPage[] { viewPage });
                }
                else
                {
                    dockingManager.RemovePage(viewPage, true);
                    dockingManager.AddDockspace("Control", DockingEdge.Right, new KryptonPage[] { viewPage });
                }
            }
        }

        private void btnSaveSurvey_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_Save.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.CurrentJob.IsValidSurvey)
                {
                    JobHandler.Instance.SaveJob();
                }
                else
                {
                    StringBuilder bldr = new StringBuilder();
                    bldr.Append("You are missing the following components of the survey job. Please add them and try saving again:\n");
                    foreach (string missing in JobHandler.Instance.MissingInformation)
                    {
                        bldr.Append($"-: {missing}\n");
                    }

                    CRichMsgBox.Show("There is not enough information for this job to save to the database!", "Error", bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);
                    ChangeStatusText(this, new StatusArgs(StatusText.Survey_MissingInfo.ToDescriptionString()));
                    return;
                }
            }
        }

        private void btnReloadFromDatabase_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_Save.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.SavePending)
                {
                    DialogResult result = CMessageBox.Show("Are you sure you want to refresh the local copy of the job with values from the database. Your pending changes will be overwritten.", 
                    "Confirm", MessageBoxButtons.YesNo, Resources.warning_64x64);

                    if (result == DialogResult.Yes)
                    {
                        if (Database.DoesSurveyExist(JobHandler.Instance.CurrentJob.JobNumber))
                            RefreshJob();
                        else
                        {
                            CMessageBox.Show("The current job does not exist in the database yet! There is nothing to refresh from.", "No Job", MessageBoxButtons.OK, Resources.error_64x64);
                            return;
                        }
                    }
                }
                else
                {
                    RefreshJob();
                }
            }
        }

        private void RefreshJob()
        {
            string jobNumber = JobHandler.Instance.CurrentJob.JobNumber;
            if (JobHandler.Instance.CloseJob(false, false, false))
            {
                if (JobHandler.Instance.OpenJob(jobNumber))
                {
                    ChangeTitleText("[JOB# " + jobNumber + "]");
                }
            }
        }

        private void btnCloseCurrentJob_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_Close.ToDescriptionString()));
                    return;
                }

                CloseJob();
            }
        }

        private void CloseJob()
        {
            if (JobHandler.Instance.CloseJob())
            {
                ChangeTitleText("[NO JOB OPEN]");

                //remove pages that are considered survey pages
                dockingManager.RemovePages(dockingManager.Pages.Where(p => (p.Tag != null && ((SurveyPage)p.Tag) == SurveyPage.IsSurveyPage)).ToArray(), true);

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (!Application.OpenForms[i].Equals(this))
                        Application.OpenForms[i].Close();
                }

                ChangeStatusText(this, new StatusArgs("Ready"));
            }
        }

        private void btnAddNewFile_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AttachFile.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.ReadOnly)
                {
                    ChangeStatusText(this, new StatusArgs($"Job# {JobHandler.Instance.CurrentJob.JobNumber} opened in READ-ONLY mode. Cannot change Job's files."));
                    return;
                }

                UploadFile uploadForm = new UploadFile(JobHandler.Instance.CurrentJob.Files);
                uploadForm.FileUploadDone += AddFiles;
                uploadForm.StatusUpdate += ChangeStatusText;
                uploadForm.Show();
            }
        }

        private void AddFiles(object sender, EventArgs e)
        {
            if (e is FileUploadDoneArgs args)
            {
                JobHandler.Instance.CurrentJob.SetFiles(args.Files);
                JobHandler.Instance.UpdateSavePending(true);
            }
        }

        private void btnViewAllFiles_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_ViewFiles.ToDescriptionString()));
                    return;
                }

                FileBrowser fb = new FileBrowser(JobHandler.Instance.CurrentJob.Files);
                fb.StatusUpdate += ChangeStatusText;
                fb.Show();
            }
        }

        private void btnBillingPortal_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_BillingPortal.ToDescriptionString()));
                    return;
                }

                BillingPortal page = new BillingPortal()
                {
                    UniqueName = "Billing Portal",
                    ImageSmall = Resources.billing_portal_16x16,
                    ImageLarge = Resources.billing_portal,
                    Tag = SurveyPage.IsSurveyPage
                };

                if (!dockingManager.ContainsPage(page.UniqueName))
                {
                    dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { page });
                }

                try
                {
                    dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(page.UniqueName);
                }
                catch (Exception)
                {
                    RuntimeVars.Instance.LogFile.AddEntry("Exception when trying to select billing portal page. Perhaps it is a floating window and not docked?");
                    RuntimeVars.Instance.LogFile.WriteToFile();
                }
            }
        }

        private void btnCurrentBill_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_BillingReport.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.CurrentJob.IsValidSurvey)
                {
                    string fileName = $"BillingReport-{JobHandler.Instance.CurrentJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}";
                    PDF.CreateDocument(fileName,
                            $"BillingReport-{JobHandler.Instance.CurrentJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}", "CSM", "",
                            $"Billing Report - Job#: {JobHandler.Instance.CurrentJob.JobNumber}", Fonts.Courier, true, true, false, 12);

                    ChangeStatusText(this, new StatusArgs($"Generating billing report for Job# {JobHandler.Instance.CurrentJob.JobNumber}. Please wait..."));
                    PDF.GenerateBillingReport(JobHandler.Instance.CurrentJob);

                    string path = Path.Combine(Settings.Default.DefaultSavePath, $"{fileName}.pdf");
                    Process.Start(path);
                    ChangeStatusText(this, new StatusArgs($"Billing report for Job# {JobHandler.Instance.CurrentJob.JobNumber} created successfully!"));
                }
                else
                {
                    StringBuilder bldr = new StringBuilder();
                    bldr.Append("You are missing the following components of the survey job:\n");
                    foreach (string missing in JobHandler.Instance.MissingInformation)
                    {
                        bldr.Append($"-: {missing}\n");
                    }

                    CRichMsgBox.Show("There is not enough information for this job to generate a report!", "Error", bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);
                    ChangeStatusText(this, new StatusArgs(StatusText.BillingReport_MissingInfo.ToDescriptionString()));
                    return;
                }
            }
        }

        private void btnGenerateFullReport_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_FullReport.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.CurrentJob.IsValidSurvey)
                {
                    string fileName = $"Full Survey Report-{JobHandler.Instance.CurrentJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}";
                    PDF.CreateDocument(fileName,
                        $"Full Survey Report-{JobHandler.Instance.CurrentJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}", "CSM", "",
                        $"Full Survey Report - Job#: {JobHandler.Instance.CurrentJob.JobNumber}", Fonts.Courier, true, true, false, 12);

                    ChangeStatusText(this, new StatusArgs($"Generating full report for Job# {JobHandler.Instance.CurrentJob.JobNumber}. Please wait..."));
                    PDF.GenerateFullReport(JobHandler.Instance.CurrentJob);

                    string path = Path.Combine(Settings.Default.DefaultSavePath, $"{fileName}.pdf");
                    Process.Start(path);
                    ChangeStatusText(this, new StatusArgs($"Full report for Job# {JobHandler.Instance.CurrentJob.JobNumber} created successfully!"));
                }
                else
                {
                    StringBuilder bldr = new StringBuilder();
                    bldr.Append("You are missing the following components of the survey job:\n");
                    foreach (string missing in JobHandler.Instance.MissingInformation)
                    {
                        bldr.Append($"-: {missing}\n");
                    }

                    CRichMsgBox.Show("There is not enough information for this job to generate a report!", "Error", bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);
                    ChangeStatusText(this, new StatusArgs(StatusText.FullReport_MissingInfo.ToDescriptionString()));
                    return;
                }
            }
        }

        private void btnFileDetailReport_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_FileReport.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.CurrentJob.HasFiles)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.FileReport_NoFiles.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.CurrentJob.IsValidSurvey)
                {
                    string fileName = $"File Detail Report-{JobHandler.Instance.CurrentJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}";
                    PDF.CreateDocument(fileName,
                        $"File Detail Report-{JobHandler.Instance.CurrentJob.JobNumber}-{DateTime.Now.Date:MM-dd-yyyy}", "CSM", "",
                        $"File Detail Report - Job#: {JobHandler.Instance.CurrentJob.JobNumber}", Fonts.Courier, true, true, false, 12);

                    ChangeStatusText(this, new StatusArgs($"Generating detailed file report for Job# {JobHandler.Instance.CurrentJob.JobNumber}. Please wait..."));
                    PDF.GenerateFileReport(JobHandler.Instance.CurrentJob);

                    string path = Path.Combine(Settings.Default.DefaultSavePath, $"{fileName}.pdf");
                    Process.Start(path);
                    ChangeStatusText(this, new StatusArgs($"Detailed file report for Job# {JobHandler.Instance.CurrentJob.JobNumber} created successfully!"));
                }
                else
                {
                    StringBuilder bldr = new StringBuilder();
                    bldr.Append("You are missing the following components of the survey job:\n");
                    foreach (string missing in JobHandler.Instance.MissingInformation)
                    {
                        bldr.Append($"-: {missing}\n");
                    }

                    CRichMsgBox.Show("There is not enough information for this job to generate a report!", "Error", bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);
                    ChangeStatusText(this, new StatusArgs(StatusText.FileReport_MissingInfo.ToDescriptionString()));
                    return;
                }
            }
        }

        private void btnAssocClient_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddClient.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.ReadOnly)
                {
                    ChangeStatusText(this, new StatusArgs($"Job# {JobHandler.Instance.CurrentJob.JobNumber} opened in READ-ONLY mode. Cannot change Job's client."));
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
                JobHandler.Instance.CurrentJob.Client = args.Object as Client;
                JobHandler.Instance.UpdateSavePending(true);
            }
        }

        private void btnAssocRealtor_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddRealtor.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.ReadOnly)
                {
                    ChangeStatusText(this, new StatusArgs($"Job# {JobHandler.Instance.CurrentJob.JobNumber} opened in READ-ONLY mode. Cannot change Job's realtor."));
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
                JobHandler.Instance.CurrentJob.Realtor = args.Object as Realtor;
                JobHandler.Instance.UpdateSavePending(true);
            }
        }

        private void btnAssocTitleComp_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoJob_AddTitleCompany.ToDescriptionString()));
                    return;
                }

                if (JobHandler.Instance.ReadOnly)
                {
                    ChangeStatusText(this, new StatusArgs($"Job# {JobHandler.Instance.CurrentJob.JobNumber} opened in READ-ONLY mode. Cannot change Job's title company."));
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
                JobHandler.Instance.CurrentJob.TitleCompany = args.Object as TitleCompany;
                JobHandler.Instance.UpdateSavePending(true);
            }
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            if (licensed)
            {
                if (!RuntimeVars.Instance.DatabaseConnected)
                {
                    ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
                    return;
                }

                if (!JobHandler.Instance.IsJobOpen)
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

                NotesCtl ctl = new NotesCtl(JobHandler.Instance.CurrentJob.Notes);
                ctl.StatusUpdate += ChangeStatusText;
                ctl.Dock = DockStyle.Fill;
                notesPanel.Controls.Add(ctl);

                if (!dockingManager.ContainsPage(notesPanel))
                {
                    dockingManager.AddToWorkspace("MainWorkspace", new KryptonPage[] { notesPanel });
                }

                try
                {
                    dockingManager.FindDockingWorkspace("MainWorkspace").SelectPage(notesPanel.UniqueName);
                }
                catch (Exception)
                {
                    RuntimeVars.Instance.LogFile.AddEntry("Exception when trying to select notes page. Perhaps it is a floating window and not docked?");
                    RuntimeVars.Instance.LogFile.WriteToFile();
                }
            }
        }

        private void btnManageLicense_Click(object sender, EventArgs e)
        {
            activationDialog.LicensingComplete += SetLicenseStatus;
            activationDialog.ShowDialog();
        }

        private void SetLicenseStatus(object sender, EventArgs e)
        {
            if (e is LicensingEventArgs args)
            {
                RuntimeVars.Instance.License = args.License;
                licensed = RuntimeVars.Instance.IsLicensed;

                if (!licensed)
                {
                    if (JobHandler.Instance.IsJobOpen)
                        CloseJob();
                    ChangeStatusText(this, new StatusArgs("Running an Unlicensed Copy! Most features are disabled. Please activate!"));
                }

                UpdateTitleText();
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

        private ExitChoice ShowCloseDialog(bool hideExitOptions = false)
        {
            if (JobHandler.Instance.IsJobOpen)
            {
                if (JobHandler.Instance.SavePending)
                {
                    return CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened survey job. What would you like to do?", "Save Changes", MessageBoxButtons.OKCancel, Resources.warning_64x64, hideExitOptions);
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
            RuntimeVars.Instance.LogFile.WriteToFile();
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
                Application.Exit();

            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.FormOwnerClosing)
            {
                ExitChoice choice = ShowCloseDialog();
                if (choice == ExitChoice.SaveAndExit)
                {
                    JobHandler.Instance.SaveJob();
                    JobHandler.Instance.CloseJob(true);
                    Application.Exit();
                }
                else if (choice == ExitChoice.ExitNoSave)
                {
                    Application.Exit();
                }
                else if (choice == ExitChoice.SaveOnly)
                {
                    JobHandler.Instance.SaveJob();
                    e.Cancel = true;
                }
                else if (choice == ExitChoice.Cancel)
                {
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

        MySqlException code;
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
            if (!Database.GetErrorMessage(code).Equals("NO ERROR"))
            {
                ChangeTitleText("", "", "", "");
                ChangeStatusText(this, new StatusArgs(StatusText.NoDatabaseConnection.ToDescriptionString()));
            }
            else
            {
                ChangeTitleText($"\\\\{Database.Server}\\{Database.DB}");
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

        private void btnOpenHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://surveymanager.readthedocs.io/en/latest/");
        }
    }
}
