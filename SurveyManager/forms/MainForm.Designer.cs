
namespace SurveyManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.kManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.office2013_edited = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.mainRibbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.surveyTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.jobsRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnNewSurveyJob = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnOpenSurveyJob = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnViewAllJobs = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupTriple15 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnToggleReadOnly = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroup3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple11 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnBasicInfo = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnOpenViewPanel = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupTriple12 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnReloadFromDatabase = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnCloseCurrentJob = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.filesRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple8 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnAddNewFile = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnViewAllFiles = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.billingRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple9 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnBillingPortal = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.assetsRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple10 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnAssocClient = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.surveyClientContextMenu = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.btnAssocRealtor = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.surveyRealtorContextMenu = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems5 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem8 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItems3 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem3 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem4 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.btnAssocTitleComp = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.surveyTitleCompanyContextMenu = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems4 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem5 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem6 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonRibbonGroupSeparator1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupTriple13 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnAddNote = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.reportingGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple14 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnGenerateBillingReport = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnGenerateFullReport = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnFileDetailReport = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.surMangRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple7 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnOpenHelp = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnManageLicense = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnSendFeedback = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.objectsTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.clientRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton5 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton6 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.realtorRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton7 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton8 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton9 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.tcRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton10 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton11 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton12 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.bRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple16 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnFindRate = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnNewRate = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnViewAllRates = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.databaseTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple5 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnDBConnection = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroup2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple6 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.exportDataBtn = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.importDataBtn = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnSqlQuery = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.dockingManager = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
            this.borderPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dockableWorkspace = new ComponentFactory.Krypton.Docking.KryptonDockableWorkspace();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuHeading1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
            this.checkConnectionBGWorker = new System.ComponentModel.BackgroundWorker();
            this.surveyAutosave = new System.Windows.Forms.Timer(this.components);
            this.logAutoSave = new System.Windows.Forms.Timer(this.components);
            this.dumpDatabaseBGWorker = new System.ComponentModel.BackgroundWorker();
            this.csvSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.kryptonContextMenuItem7 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderPanel)).BeginInit();
            this.borderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockableWorkspace)).BeginInit();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblStatus,
            this.lblStatusDate});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 726);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.mainStatusStrip.Size = new System.Drawing.Size(1536, 23);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 17);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1456, 18);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusDate
            // 
            this.lblStatusDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblStatusDate.Name = "lblStatusDate";
            this.lblStatusDate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblStatusDate.Size = new System.Drawing.Size(65, 18);
            this.lblStatusDate.Text = "<Date>";
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 500;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // kManager
            // 
            this.kManager.GlobalPalette = this.office2013_edited;
            this.kManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // office2013_edited
            // 
            this.office2013_edited.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013White;
            this.office2013_edited.FormStyles.FormCustom1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.office2013_edited.FormStyles.FormCustom1.StateCommon.Border.Rounding = 5;
            this.office2013_edited.FormStyles.FormCustom1.StateCommon.Border.Width = 5;
            this.office2013_edited.ToolMenuStatus.MenuStrip.MenuStripFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.office2013_edited.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.office2013_edited.ToolMenuStatus.MenuStrip.MenuStripText = System.Drawing.Color.Black;
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = System.Drawing.Color.SteelBlue;
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = System.Drawing.Color.SteelBlue;
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripText = System.Drawing.Color.LightYellow;
            // 
            // mainRibbon
            // 
            this.mainRibbon.InDesignHelperMode = true;
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.QATLocation = ComponentFactory.Krypton.Ribbon.QATLocation.Hidden;
            this.mainRibbon.RibbonAppButton.AppButtonImage = global::SurveyManager.Properties.Resources.instrument_16x16;
            this.mainRibbon.RibbonAppButton.AppButtonText = "Menu";
            this.mainRibbon.RibbonStrings.RecentDocuments = "Recent Jobs";
            this.mainRibbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.surveyTab,
            this.objectsTab,
            this.databaseTab});
            this.mainRibbon.SelectedTab = this.surveyTab;
            this.mainRibbon.Size = new System.Drawing.Size(1536, 115);
            this.mainRibbon.TabIndex = 4;
            // 
            // surveyTab
            // 
            this.surveyTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.jobsRibbonGroup,
            this.kryptonRibbonGroup3,
            this.filesRibbonGroup,
            this.billingRibbonGroup,
            this.assetsRibbonGroup,
            this.reportingGroup,
            this.surMangRibbonGroup});
            this.surveyTab.Text = "Survey";
            // 
            // jobsRibbonGroup
            // 
            this.jobsRibbonGroup.DialogBoxLauncher = false;
            this.jobsRibbonGroup.Image = global::SurveyManager.Properties.Resources.instrument_24x24;
            this.jobsRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1,
            this.kryptonRibbonGroupTriple15});
            this.jobsRibbonGroup.TextLine1 = "Jobs";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnNewSurveyJob,
            this.btnOpenSurveyJob,
            this.btnViewAllJobs});
            // 
            // btnNewSurveyJob
            // 
            this.btnNewSurveyJob.ImageLarge = global::SurveyManager.Properties.Resources.add;
            this.btnNewSurveyJob.ImageSmall = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnNewSurveyJob.TextLine1 = "New";
            this.btnNewSurveyJob.ToolTipBody = "Create a new survey job.";
            this.btnNewSurveyJob.ToolTipTitle = "Jobs";
            this.btnNewSurveyJob.Click += new System.EventHandler(this.btnNewSurveyJob_Click);
            // 
            // btnOpenSurveyJob
            // 
            this.btnOpenSurveyJob.ImageLarge = global::SurveyManager.Properties.Resources.open;
            this.btnOpenSurveyJob.ImageSmall = global::SurveyManager.Properties.Resources.open_16x16;
            this.btnOpenSurveyJob.TextLine1 = "Open";
            this.btnOpenSurveyJob.ToolTipBody = "Open an existing survey job for editing.";
            this.btnOpenSurveyJob.ToolTipTitle = "Jobs";
            this.btnOpenSurveyJob.Click += new System.EventHandler(this.btnOpenSurveyJob_Click);
            // 
            // btnViewAllJobs
            // 
            this.btnViewAllJobs.ImageLarge = global::SurveyManager.Properties.Resources.surveying;
            this.btnViewAllJobs.ImageSmall = global::SurveyManager.Properties.Resources.surveying_16x16;
            this.btnViewAllJobs.TextLine1 = "View";
            this.btnViewAllJobs.TextLine2 = "All Jobs";
            this.btnViewAllJobs.ToolTipBody = "View all survey jobs.";
            this.btnViewAllJobs.ToolTipTitle = "Jobs";
            this.btnViewAllJobs.Click += new System.EventHandler(this.btnViewAllJobs_Click);
            // 
            // kryptonRibbonGroupTriple15
            // 
            this.kryptonRibbonGroupTriple15.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnToggleReadOnly});
            // 
            // btnToggleReadOnly
            // 
            this.btnToggleReadOnly.ImageLarge = global::SurveyManager.Properties.Resources.toggle_off_64x64;
            this.btnToggleReadOnly.ImageSmall = global::SurveyManager.Properties.Resources.toggle_off_16x16;
            this.btnToggleReadOnly.TextLine1 = "Read-Only";
            this.btnToggleReadOnly.TextLine2 = "Mode";
            this.btnToggleReadOnly.ToolTipBody = "When toggled, all jobs that are opened after toggling will be in Read-Only mode.\r" +
    "\nThis means they cannot be edited; only viewed.";
            this.btnToggleReadOnly.ToolTipTitle = "Jobs";
            this.btnToggleReadOnly.Click += new System.EventHandler(this.btnToggleReadOnly_Click);
            // 
            // kryptonRibbonGroup3
            // 
            this.kryptonRibbonGroup3.DialogBoxLauncher = false;
            this.kryptonRibbonGroup3.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple11,
            this.kryptonRibbonGroupSeparator3,
            this.kryptonRibbonGroupTriple12});
            this.kryptonRibbonGroup3.TextLine1 = "Current Job";
            // 
            // kryptonRibbonGroupTriple11
            // 
            this.kryptonRibbonGroupTriple11.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnBasicInfo,
            this.btnOpenViewPanel,
            this.kryptonRibbonGroupButton1});
            // 
            // btnBasicInfo
            // 
            this.btnBasicInfo.ImageLarge = global::SurveyManager.Properties.Resources.instrument;
            this.btnBasicInfo.ImageSmall = global::SurveyManager.Properties.Resources.instrument_16x16;
            this.btnBasicInfo.TextLine1 = "Basic";
            this.btnBasicInfo.TextLine2 = "Information";
            this.btnBasicInfo.ToolTipBody = "Add\\Update the basic information this survey job needs to be valid.\r\nThis include" +
    "s a description, abstract number, and the number of acres of the job.";
            this.btnBasicInfo.ToolTipTitle = "Job";
            this.btnBasicInfo.Click += new System.EventHandler(this.btnBasicInfo_Click);
            // 
            // btnOpenViewPanel
            // 
            this.btnOpenViewPanel.ImageLarge = global::SurveyManager.Properties.Resources.view;
            this.btnOpenViewPanel.ImageSmall = global::SurveyManager.Properties.Resources.view_16x16;
            this.btnOpenViewPanel.TextLine1 = "Open";
            this.btnOpenViewPanel.TextLine2 = "View Panel";
            this.btnOpenViewPanel.ToolTipBody = "Opens the view panel. This panel allows you to quickly see the information about " +
    "the job at a quick glance.";
            this.btnOpenViewPanel.ToolTipTitle = "Job";
            this.btnOpenViewPanel.Click += new System.EventHandler(this.btnOpenViewPanel_Click);
            // 
            // kryptonRibbonGroupButton1
            // 
            this.kryptonRibbonGroupButton1.ImageLarge = global::SurveyManager.Properties.Resources.save;
            this.kryptonRibbonGroupButton1.ImageSmall = global::SurveyManager.Properties.Resources.save_16x16;
            this.kryptonRibbonGroupButton1.TextLine1 = "Save";
            this.kryptonRibbonGroupButton1.ToolTipBody = "Save any changes made to the currently open survey job.";
            this.kryptonRibbonGroupButton1.ToolTipTitle = "Current Job";
            this.kryptonRibbonGroupButton1.Click += new System.EventHandler(this.btnSaveSurvey_Click);
            // 
            // kryptonRibbonGroupTriple12
            // 
            this.kryptonRibbonGroupTriple12.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnReloadFromDatabase,
            this.btnCloseCurrentJob});
            // 
            // btnReloadFromDatabase
            // 
            this.btnReloadFromDatabase.ImageLarge = global::SurveyManager.Properties.Resources.reload;
            this.btnReloadFromDatabase.ImageSmall = global::SurveyManager.Properties.Resources.reload_16x16;
            this.btnReloadFromDatabase.TextLine1 = "Reload";
            this.btnReloadFromDatabase.TextLine2 = "from Database";
            this.btnReloadFromDatabase.ToolTipBody = resources.GetString("btnReloadFromDatabase.ToolTipBody");
            this.btnReloadFromDatabase.ToolTipTitle = "Current Job";
            this.btnReloadFromDatabase.Click += new System.EventHandler(this.btnReloadFromDatabase_Click);
            // 
            // btnCloseCurrentJob
            // 
            this.btnCloseCurrentJob.ImageLarge = global::SurveyManager.Properties.Resources.close;
            this.btnCloseCurrentJob.ImageSmall = global::SurveyManager.Properties.Resources.close_16x16;
            this.btnCloseCurrentJob.TextLine1 = "Close";
            this.btnCloseCurrentJob.ToolTipBody = "Closes the current job; will prompt to save changes.";
            this.btnCloseCurrentJob.ToolTipTitle = "Current Job";
            this.btnCloseCurrentJob.Click += new System.EventHandler(this.btnCloseCurrentJob_Click);
            // 
            // filesRibbonGroup
            // 
            this.filesRibbonGroup.DialogBoxLauncher = false;
            this.filesRibbonGroup.Image = global::SurveyManager.Properties.Resources.file_32x32;
            this.filesRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple8});
            this.filesRibbonGroup.TextLine1 = "Files";
            // 
            // kryptonRibbonGroupTriple8
            // 
            this.kryptonRibbonGroupTriple8.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnAddNewFile,
            this.btnViewAllFiles});
            // 
            // btnAddNewFile
            // 
            this.btnAddNewFile.ImageLarge = global::SurveyManager.Properties.Resources.attachment;
            this.btnAddNewFile.ImageSmall = global::SurveyManager.Properties.Resources.attachment_16x16;
            this.btnAddNewFile.TextLine1 = "Edit";
            this.btnAddNewFile.ToolTipBody = "Add/Update/Remove files that are associated with this survey job.";
            this.btnAddNewFile.ToolTipTitle = "Files";
            this.btnAddNewFile.Click += new System.EventHandler(this.btnAddNewFile_Click);
            // 
            // btnViewAllFiles
            // 
            this.btnViewAllFiles.ImageLarge = global::SurveyManager.Properties.Resources.folder;
            this.btnViewAllFiles.ImageSmall = global::SurveyManager.Properties.Resources.folder_16x16;
            this.btnViewAllFiles.TextLine1 = "View All";
            this.btnViewAllFiles.ToolTipBody = "View all of the associated files for this job.\r\nAllows opening and downloading of" +
    " files.";
            this.btnViewAllFiles.ToolTipTitle = "Files";
            this.btnViewAllFiles.Click += new System.EventHandler(this.btnViewAllFiles_Click);
            // 
            // billingRibbonGroup
            // 
            this.billingRibbonGroup.DialogBoxLauncher = false;
            this.billingRibbonGroup.Image = global::SurveyManager.Properties.Resources.billing_rates_16x16;
            this.billingRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple9});
            this.billingRibbonGroup.TextLine1 = "Billing";
            // 
            // kryptonRibbonGroupTriple9
            // 
            this.kryptonRibbonGroupTriple9.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnBillingPortal});
            // 
            // btnBillingPortal
            // 
            this.btnBillingPortal.ImageLarge = global::SurveyManager.Properties.Resources.billing_portal;
            this.btnBillingPortal.ImageSmall = global::SurveyManager.Properties.Resources.billing_portal_16x16;
            this.btnBillingPortal.TextLine1 = "Billing";
            this.btnBillingPortal.TextLine2 = "Portal";
            this.btnBillingPortal.ToolTipBody = "Open the main billing portal to manage time entries, rates, and additional line i" +
    "tems for this job.";
            this.btnBillingPortal.ToolTipTitle = "Billing";
            this.btnBillingPortal.Click += new System.EventHandler(this.btnBillingPortal_Click);
            // 
            // assetsRibbonGroup
            // 
            this.assetsRibbonGroup.DialogBoxLauncher = false;
            this.assetsRibbonGroup.Image = global::SurveyManager.Properties.Resources.client_16x16;
            this.assetsRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple10,
            this.kryptonRibbonGroupSeparator1,
            this.kryptonRibbonGroupTriple13});
            this.assetsRibbonGroup.TextLine1 = "Associated";
            this.assetsRibbonGroup.TextLine2 = "Objects";
            // 
            // kryptonRibbonGroupTriple10
            // 
            this.kryptonRibbonGroupTriple10.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnAssocClient,
            this.btnAssocRealtor,
            this.btnAssocTitleComp});
            // 
            // btnAssocClient
            // 
            this.btnAssocClient.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Split;
            this.btnAssocClient.ImageLarge = global::SurveyManager.Properties.Resources.client;
            this.btnAssocClient.ImageSmall = global::SurveyManager.Properties.Resources.client_16x16;
            this.btnAssocClient.KryptonContextMenu = this.surveyClientContextMenu;
            this.btnAssocClient.TextLine1 = "Client";
            this.btnAssocClient.ToolTipBody = "Add/Update the associated client for this survey job.";
            this.btnAssocClient.ToolTipTitle = "Associations";
            this.btnAssocClient.Click += new System.EventHandler(this.btnAssocClient_Click);
            // 
            // surveyClientContextMenu
            // 
            this.surveyClientContextMenu.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems1});
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1,
            this.kryptonContextMenuItem2});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Image = global::SurveyManager.Properties.Resources.search_16x16;
            this.kryptonContextMenuItem1.Text = "Search...";
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonContextMenuItem2.Text = "New...";
            // 
            // btnAssocRealtor
            // 
            this.btnAssocRealtor.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Split;
            this.btnAssocRealtor.ImageLarge = global::SurveyManager.Properties.Resources.realtor;
            this.btnAssocRealtor.ImageSmall = global::SurveyManager.Properties.Resources.realtor_16x16;
            this.btnAssocRealtor.KryptonContextMenu = this.surveyRealtorContextMenu;
            this.btnAssocRealtor.TextLine1 = "Realtor";
            this.btnAssocRealtor.ToolTipBody = "Add/Update the associated realtor for this survey job.\r\n";
            this.btnAssocRealtor.ToolTipTitle = "Associations";
            this.btnAssocRealtor.Click += new System.EventHandler(this.btnAssocRealtor_Click);
            // 
            // surveyRealtorContextMenu
            // 
            this.surveyRealtorContextMenu.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems5,
            this.kryptonContextMenuItems3});
            // 
            // kryptonContextMenuItems5
            // 
            this.kryptonContextMenuItems5.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem8});
            // 
            // kryptonContextMenuItem8
            // 
            this.kryptonContextMenuItem8.Image = global::SurveyManager.Properties.Resources.select_16x16;
            this.kryptonContextMenuItem8.Text = "Select from list...";
            // 
            // kryptonContextMenuItems3
            // 
            this.kryptonContextMenuItems3.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem3,
            this.kryptonContextMenuItem4});
            // 
            // kryptonContextMenuItem3
            // 
            this.kryptonContextMenuItem3.Image = global::SurveyManager.Properties.Resources.search_16x16;
            this.kryptonContextMenuItem3.Text = "Search...";
            // 
            // kryptonContextMenuItem4
            // 
            this.kryptonContextMenuItem4.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonContextMenuItem4.Text = "New...";
            // 
            // btnAssocTitleComp
            // 
            this.btnAssocTitleComp.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Split;
            this.btnAssocTitleComp.ImageLarge = global::SurveyManager.Properties.Resources.title_company;
            this.btnAssocTitleComp.ImageSmall = global::SurveyManager.Properties.Resources.title_company_16x16;
            this.btnAssocTitleComp.KryptonContextMenu = this.surveyTitleCompanyContextMenu;
            this.btnAssocTitleComp.TextLine1 = "Title";
            this.btnAssocTitleComp.TextLine2 = "Company";
            this.btnAssocTitleComp.ToolTipBody = "Add/Update the associated title company for this survey job.\r\n";
            this.btnAssocTitleComp.ToolTipTitle = "Associations";
            this.btnAssocTitleComp.Click += new System.EventHandler(this.btnAssocTitleComp_Click);
            // 
            // surveyTitleCompanyContextMenu
            // 
            this.surveyTitleCompanyContextMenu.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems4});
            // 
            // kryptonContextMenuItems4
            // 
            this.kryptonContextMenuItems4.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem5,
            this.kryptonContextMenuItem6});
            // 
            // kryptonContextMenuItem5
            // 
            this.kryptonContextMenuItem5.Image = global::SurveyManager.Properties.Resources.search_16x16;
            this.kryptonContextMenuItem5.Text = "Search...";
            // 
            // kryptonContextMenuItem6
            // 
            this.kryptonContextMenuItem6.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonContextMenuItem6.Text = "New...";
            // 
            // kryptonRibbonGroupTriple13
            // 
            this.kryptonRibbonGroupTriple13.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnAddNote});
            // 
            // btnAddNote
            // 
            this.btnAddNote.ImageLarge = global::SurveyManager.Properties.Resources.notes;
            this.btnAddNote.ImageSmall = global::SurveyManager.Properties.Resources.notes_16x16;
            this.btnAddNote.TextLine1 = "Notes";
            this.btnAddNote.ToolTipBody = "View/Update any notes for this survey job.";
            this.btnAddNote.ToolTipTitle = "Associations";
            this.btnAddNote.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // reportingGroup
            // 
            this.reportingGroup.DialogBoxLauncher = false;
            this.reportingGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple14});
            this.reportingGroup.TextLine1 = "Reporting";
            // 
            // kryptonRibbonGroupTriple14
            // 
            this.kryptonRibbonGroupTriple14.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnGenerateBillingReport,
            this.btnGenerateFullReport,
            this.btnFileDetailReport});
            // 
            // btnGenerateBillingReport
            // 
            this.btnGenerateBillingReport.ImageLarge = global::SurveyManager.Properties.Resources.current_bill;
            this.btnGenerateBillingReport.ImageSmall = global::SurveyManager.Properties.Resources.current_bill_16x16;
            this.btnGenerateBillingReport.TextLine1 = "Billing";
            this.btnGenerateBillingReport.TextLine2 = "Report";
            this.btnGenerateBillingReport.ToolTipBody = "Generate a PDF report of just the billing details for the current survey job.";
            this.btnGenerateBillingReport.ToolTipTitle = "Reporting";
            this.btnGenerateBillingReport.Click += new System.EventHandler(this.btnCurrentBill_Click);
            // 
            // btnGenerateFullReport
            // 
            this.btnGenerateFullReport.ImageLarge = global::SurveyManager.Properties.Resources.pdf;
            this.btnGenerateFullReport.ImageSmall = global::SurveyManager.Properties.Resources.pdf_16x16;
            this.btnGenerateFullReport.TextLine1 = "Full Survey";
            this.btnGenerateFullReport.TextLine2 = "Report";
            this.btnGenerateFullReport.ToolTipBody = "Generate a full PDF report detailing the current survey job.\r\nThis report also in" +
    "cludes the billing report.";
            this.btnGenerateFullReport.ToolTipTitle = "Reporting";
            this.btnGenerateFullReport.Click += new System.EventHandler(this.btnGenerateFullReport_Click);
            // 
            // btnFileDetailReport
            // 
            this.btnFileDetailReport.ImageLarge = global::SurveyManager.Properties.Resources.file_32x32;
            this.btnFileDetailReport.ImageSmall = global::SurveyManager.Properties.Resources.file;
            this.btnFileDetailReport.TextLine1 = "File Detail";
            this.btnFileDetailReport.TextLine2 = "Report";
            this.btnFileDetailReport.ToolTipBody = "Generate a full detailed report of all of the files associated with this job.";
            this.btnFileDetailReport.ToolTipTitle = "Reporting";
            this.btnFileDetailReport.Click += new System.EventHandler(this.btnFileDetailReport_Click);
            // 
            // surMangRibbonGroup
            // 
            this.surMangRibbonGroup.DialogBoxLauncher = false;
            this.surMangRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple7});
            this.surMangRibbonGroup.TextLine1 = "Survey Manager";
            // 
            // kryptonRibbonGroupTriple7
            // 
            this.kryptonRibbonGroupTriple7.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnOpenHelp,
            this.btnManageLicense,
            this.btnSendFeedback});
            // 
            // btnOpenHelp
            // 
            this.btnOpenHelp.ImageLarge = global::SurveyManager.Properties.Resources.info;
            this.btnOpenHelp.ImageSmall = global::SurveyManager.Properties.Resources.info_16x16;
            this.btnOpenHelp.TextLine1 = "Help";
            this.btnOpenHelp.ToolTipBody = "Opens the help documentation.";
            this.btnOpenHelp.ToolTipTitle = "Survey Manager";
            this.btnOpenHelp.Click += new System.EventHandler(this.btnOpenHelp_Click);
            // 
            // btnManageLicense
            // 
            this.btnManageLicense.ImageLarge = global::SurveyManager.Properties.Resources.license;
            this.btnManageLicense.ImageSmall = global::SurveyManager.Properties.Resources.license_16x16;
            this.btnManageLicense.TextLine1 = "Activation";
            this.btnManageLicense.ToolTipBody = "Activate or purchase a product key.";
            this.btnManageLicense.ToolTipTitle = "Survey Manager";
            this.btnManageLicense.Click += new System.EventHandler(this.btnManageLicense_Click);
            // 
            // btnSendFeedback
            // 
            this.btnSendFeedback.ImageLarge = global::SurveyManager.Properties.Resources.feedback;
            this.btnSendFeedback.ImageSmall = global::SurveyManager.Properties.Resources.feedback_16x16;
            this.btnSendFeedback.TextLine1 = "Send";
            this.btnSendFeedback.TextLine2 = "Feedback";
            this.btnSendFeedback.ToolTipBody = "Send your feedback to the developer including any bugs that you might\r\nhave come " +
    "across or new features you would like to see implemented.";
            this.btnSendFeedback.ToolTipTitle = "Survey Manager";
            this.btnSendFeedback.Visible = false;
            // 
            // objectsTab
            // 
            this.objectsTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.clientRibbonGroup,
            this.realtorRibbonGroup,
            this.tcRibbonGroup,
            this.bRibbonGroup});
            this.objectsTab.Text = "Objects";
            // 
            // clientRibbonGroup
            // 
            this.clientRibbonGroup.DialogBoxLauncher = false;
            this.clientRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2});
            this.clientRibbonGroup.TextLine1 = "Client";
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton4,
            this.kryptonRibbonGroupButton5,
            this.kryptonRibbonGroupButton6});
            // 
            // kryptonRibbonGroupButton4
            // 
            this.kryptonRibbonGroupButton4.ImageLarge = global::SurveyManager.Properties.Resources.client;
            this.kryptonRibbonGroupButton4.ImageSmall = global::SurveyManager.Properties.Resources.client_16x16;
            this.kryptonRibbonGroupButton4.TextLine1 = "Find";
            this.kryptonRibbonGroupButton4.Click += new System.EventHandler(this.findClientBtn_Click);
            // 
            // kryptonRibbonGroupButton5
            // 
            this.kryptonRibbonGroupButton5.ImageLarge = global::SurveyManager.Properties.Resources.add;
            this.kryptonRibbonGroupButton5.ImageSmall = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonRibbonGroupButton5.TextLine1 = "New";
            this.kryptonRibbonGroupButton5.Click += new System.EventHandler(this.newClientBtn_Click);
            // 
            // kryptonRibbonGroupButton6
            // 
            this.kryptonRibbonGroupButton6.ImageLarge = global::SurveyManager.Properties.Resources.view;
            this.kryptonRibbonGroupButton6.ImageSmall = global::SurveyManager.Properties.Resources.view_16x16;
            this.kryptonRibbonGroupButton6.TextLine1 = "View All";
            this.kryptonRibbonGroupButton6.Click += new System.EventHandler(this.viewClientsBtn_Click);
            // 
            // realtorRibbonGroup
            // 
            this.realtorRibbonGroup.DialogBoxLauncher = false;
            this.realtorRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple3});
            this.realtorRibbonGroup.TextLine1 = "Realtor";
            // 
            // kryptonRibbonGroupTriple3
            // 
            this.kryptonRibbonGroupTriple3.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton7,
            this.kryptonRibbonGroupButton8,
            this.kryptonRibbonGroupButton9});
            // 
            // kryptonRibbonGroupButton7
            // 
            this.kryptonRibbonGroupButton7.ImageLarge = global::SurveyManager.Properties.Resources.realtor;
            this.kryptonRibbonGroupButton7.ImageSmall = global::SurveyManager.Properties.Resources.realtor_16x16;
            this.kryptonRibbonGroupButton7.TextLine1 = "Find";
            this.kryptonRibbonGroupButton7.Click += new System.EventHandler(this.findRealtorBtn_Click);
            // 
            // kryptonRibbonGroupButton8
            // 
            this.kryptonRibbonGroupButton8.ImageLarge = global::SurveyManager.Properties.Resources.add;
            this.kryptonRibbonGroupButton8.ImageSmall = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonRibbonGroupButton8.TextLine1 = "New";
            this.kryptonRibbonGroupButton8.Click += new System.EventHandler(this.newRealtorBtn_Click);
            // 
            // kryptonRibbonGroupButton9
            // 
            this.kryptonRibbonGroupButton9.ImageLarge = global::SurveyManager.Properties.Resources.view;
            this.kryptonRibbonGroupButton9.ImageSmall = global::SurveyManager.Properties.Resources.view_16x16;
            this.kryptonRibbonGroupButton9.TextLine1 = "View All";
            this.kryptonRibbonGroupButton9.Click += new System.EventHandler(this.viewRealtorsBtn_Click);
            // 
            // tcRibbonGroup
            // 
            this.tcRibbonGroup.DialogBoxLauncher = false;
            this.tcRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple4});
            this.tcRibbonGroup.TextLine1 = "Title Company";
            // 
            // kryptonRibbonGroupTriple4
            // 
            this.kryptonRibbonGroupTriple4.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton10,
            this.kryptonRibbonGroupButton11,
            this.kryptonRibbonGroupButton12});
            // 
            // kryptonRibbonGroupButton10
            // 
            this.kryptonRibbonGroupButton10.ImageLarge = global::SurveyManager.Properties.Resources.title_company;
            this.kryptonRibbonGroupButton10.ImageSmall = global::SurveyManager.Properties.Resources.title_company_16x16;
            this.kryptonRibbonGroupButton10.TextLine1 = "Find";
            this.kryptonRibbonGroupButton10.Click += new System.EventHandler(this.findTitleCompanyBtn_Click);
            // 
            // kryptonRibbonGroupButton11
            // 
            this.kryptonRibbonGroupButton11.ImageLarge = global::SurveyManager.Properties.Resources.add;
            this.kryptonRibbonGroupButton11.ImageSmall = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonRibbonGroupButton11.TextLine1 = "New";
            this.kryptonRibbonGroupButton11.Click += new System.EventHandler(this.newTitleCompanyBtn_Click);
            // 
            // kryptonRibbonGroupButton12
            // 
            this.kryptonRibbonGroupButton12.ImageLarge = global::SurveyManager.Properties.Resources.view;
            this.kryptonRibbonGroupButton12.ImageSmall = global::SurveyManager.Properties.Resources.view_16x16;
            this.kryptonRibbonGroupButton12.TextLine1 = "View All";
            this.kryptonRibbonGroupButton12.Click += new System.EventHandler(this.viewTitleCompanyBtn_Click);
            // 
            // bRibbonGroup
            // 
            this.bRibbonGroup.DialogBoxLauncher = false;
            this.bRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple16});
            this.bRibbonGroup.TextLine1 = "Billing";
            this.bRibbonGroup.TextLine2 = "Rates";
            // 
            // kryptonRibbonGroupTriple16
            // 
            this.kryptonRibbonGroupTriple16.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnFindRate,
            this.btnNewRate,
            this.btnViewAllRates});
            // 
            // btnFindRate
            // 
            this.btnFindRate.ImageLarge = global::SurveyManager.Properties.Resources.billing_rates;
            this.btnFindRate.ImageSmall = global::SurveyManager.Properties.Resources.billing_rates_16x16;
            this.btnFindRate.TextLine1 = "Find";
            this.btnFindRate.Click += new System.EventHandler(this.btnFindRate_Click);
            // 
            // btnNewRate
            // 
            this.btnNewRate.ImageLarge = global::SurveyManager.Properties.Resources.add;
            this.btnNewRate.ImageSmall = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnNewRate.TextLine1 = "New";
            this.btnNewRate.Click += new System.EventHandler(this.btnNewRate_Click);
            // 
            // btnViewAllRates
            // 
            this.btnViewAllRates.ImageLarge = global::SurveyManager.Properties.Resources.view;
            this.btnViewAllRates.ImageSmall = global::SurveyManager.Properties.Resources.view_16x16;
            this.btnViewAllRates.TextLine1 = "View";
            this.btnViewAllRates.TextLine2 = "All";
            this.btnViewAllRates.Click += new System.EventHandler(this.btnViewAllRates_Click);
            // 
            // databaseTab
            // 
            this.databaseTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1,
            this.kryptonRibbonGroup2});
            this.databaseTab.Text = "Database";
            // 
            // kryptonRibbonGroup1
            // 
            this.kryptonRibbonGroup1.DialogBoxLauncher = false;
            this.kryptonRibbonGroup1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple5});
            this.kryptonRibbonGroup1.TextLine1 = "Connection";
            // 
            // kryptonRibbonGroupTriple5
            // 
            this.kryptonRibbonGroupTriple5.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnDBConnection});
            // 
            // btnDBConnection
            // 
            this.btnDBConnection.ImageLarge = global::SurveyManager.Properties.Resources.db_connection;
            this.btnDBConnection.ImageSmall = global::SurveyManager.Properties.Resources.db_connection;
            this.btnDBConnection.TextLine1 = "Connection";
            this.btnDBConnection.TextLine2 = "Settings";
            this.btnDBConnection.Click += new System.EventHandler(this.dbConnectionBtn_Click);
            // 
            // kryptonRibbonGroup2
            // 
            this.kryptonRibbonGroup2.DialogBoxLauncher = false;
            this.kryptonRibbonGroup2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple6});
            this.kryptonRibbonGroup2.TextLine1 = "Data";
            // 
            // kryptonRibbonGroupTriple6
            // 
            this.kryptonRibbonGroupTriple6.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.exportDataBtn,
            this.importDataBtn,
            this.btnSqlQuery});
            // 
            // exportDataBtn
            // 
            this.exportDataBtn.ImageLarge = global::SurveyManager.Properties.Resources.export;
            this.exportDataBtn.ImageSmall = global::SurveyManager.Properties.Resources.export;
            this.exportDataBtn.TextLine1 = "Export";
            this.exportDataBtn.TextLine2 = "Data";
            this.exportDataBtn.Click += new System.EventHandler(this.exportDataBtn_Click);
            // 
            // importDataBtn
            // 
            this.importDataBtn.ImageLarge = global::SurveyManager.Properties.Resources.import;
            this.importDataBtn.ImageSmall = global::SurveyManager.Properties.Resources.import;
            this.importDataBtn.TextLine1 = "Import";
            this.importDataBtn.TextLine2 = "Data";
            this.importDataBtn.Visible = false;
            // 
            // btnSqlQuery
            // 
            this.btnSqlQuery.ImageLarge = global::SurveyManager.Properties.Resources.sql;
            this.btnSqlQuery.ImageSmall = global::SurveyManager.Properties.Resources.sql_16x16;
            this.btnSqlQuery.TextLine1 = "SQL";
            this.btnSqlQuery.TextLine2 = "Query";
            this.btnSqlQuery.Click += new System.EventHandler(this.sqlQueryBtn_Click);
            // 
            // dockingManager
            // 
            this.dockingManager.DefaultCloseRequest = ComponentFactory.Krypton.Docking.DockingCloseRequest.RemovePageAndDispose;
            this.dockingManager.DockableWorkspaceCellAdding += new System.EventHandler<ComponentFactory.Krypton.Docking.DockableWorkspaceCellEventArgs>(this.dockingManager_DockableWorkspaceCellAdding);
            // 
            // borderPanel
            // 
            this.borderPanel.Controls.Add(this.dockableWorkspace);
            this.borderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderPanel.Location = new System.Drawing.Point(0, 115);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Padding = new System.Windows.Forms.Padding(1);
            this.borderPanel.Size = new System.Drawing.Size(1536, 611);
            this.borderPanel.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.borderPanel.TabIndex = 5;
            // 
            // dockableWorkspace
            // 
            this.dockableWorkspace.AutoHiddenHost = false;
            this.dockableWorkspace.CompactFlags = ((ComponentFactory.Krypton.Workspace.CompactFlags)(((ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptyCells | ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptySequences) 
            | ComponentFactory.Krypton.Workspace.CompactFlags.PromoteLeafs)));
            this.dockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockableWorkspace.Location = new System.Drawing.Point(1, 1);
            this.dockableWorkspace.Name = "dockableWorkspace";
            // 
            // 
            // 
            this.dockableWorkspace.Root.UniqueName = "FD3F779B80FA42AB2284FE60B3AE5414";
            this.dockableWorkspace.Root.WorkspaceControl = this.dockableWorkspace;
            this.dockableWorkspace.ShowMaximizeButton = false;
            this.dockableWorkspace.Size = new System.Drawing.Size(1534, 609);
            this.dockableWorkspace.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dockableWorkspace.TabIndex = 0;
            this.dockableWorkspace.TabStop = true;
            // 
            // kryptonContextMenuHeading1
            // 
            this.kryptonContextMenuHeading1.ExtraText = "";
            // 
            // checkConnectionBGWorker
            // 
            this.checkConnectionBGWorker.WorkerReportsProgress = true;
            this.checkConnectionBGWorker.WorkerSupportsCancellation = true;
            this.checkConnectionBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkConnectionBGWorker_DoWork);
            this.checkConnectionBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.checkConnectionBGWorker_ProgressChanged);
            this.checkConnectionBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkConnectionBGWorker_RunWorkerCompleted);
            // 
            // surveyAutosave
            // 
            this.surveyAutosave.Tick += new System.EventHandler(this.surveyAutosave_Tick);
            // 
            // logAutoSave
            // 
            this.logAutoSave.Tick += new System.EventHandler(this.logAutoSave_Tick);
            // 
            // dumpDatabaseBGWorker
            // 
            this.dumpDatabaseBGWorker.WorkerReportsProgress = true;
            this.dumpDatabaseBGWorker.WorkerSupportsCancellation = true;
            this.dumpDatabaseBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dumpDatabaseBGWorker_DoWork);
            this.dumpDatabaseBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dumpDatabaseBGWorker_ProgressChanged);
            this.dumpDatabaseBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dumpDatabaseBGWorker_RunWorkerCompleted);
            // 
            // kryptonContextMenuItem7
            // 
            this.kryptonContextMenuItem7.Text = "Menu Item";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1536, 749);
            this.Controls.Add(this.borderPanel);
            this.Controls.Add(this.mainRibbon);
            this.Controls.Add(this.mainStatusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.FormCustom1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Palette = this.office2013_edited;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderPanel)).EndInit();
            this.borderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockableWorkspace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusDate;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Timer clockTimer;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette office2013_edited;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbon mainRibbon;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab objectsTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup clientRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton4;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton5;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton6;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup realtorRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton7;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton8;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton9;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup tcRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton10;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton11;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton12;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab databaseTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple5;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnDBConnection;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple6;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton exportDataBtn;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton importDataBtn;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSqlQuery;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel borderPanel;
        private ComponentFactory.Krypton.Docking.KryptonDockableWorkspace dockableWorkspace;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab surveyTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup jobsRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnOpenSurveyJob;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnNewSurveyJob;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnViewAllJobs;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup filesRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple8;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnAddNewFile;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnViewAllFiles;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup billingRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple9;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnBillingPortal;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup assetsRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple10;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnAssocClient;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnAssocRealtor;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnAssocTitleComp;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup surMangRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple7;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnOpenHelp;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnManageLicense;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSendFeedback;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple11;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnBasicInfo;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnOpenViewPanel;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple12;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnCloseCurrentJob;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator3;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple13;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnAddNote;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu surveyClientContextMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
        protected ComponentFactory.Krypton.Docking.KryptonDockingManager dockingManager;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu surveyRealtorContextMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem4;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu surveyTitleCompanyContextMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems4;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem5;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem6;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private System.ComponentModel.BackgroundWorker checkConnectionBGWorker;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup reportingGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple14;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnGenerateBillingReport;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnGenerateFullReport;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnFileDetailReport;
        private System.Windows.Forms.Timer surveyAutosave;
        private System.Windows.Forms.Timer logAutoSave;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup bRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple16;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnFindRate;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnNewRate;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnViewAllRates;
        private System.ComponentModel.BackgroundWorker dumpDatabaseBGWorker;
        private System.Windows.Forms.FolderBrowserDialog csvSaveFolder;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple15;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnToggleReadOnly;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnReloadFromDatabase;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems5;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem8;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem7;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator kryptonContextMenuSeparator1;
    }
}

