
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
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.kManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.office2013_edited = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.mainRibbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.homeTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.surveyRibbonGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
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
            this.helpGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple7 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnUserManual = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dockableWorkspace = new ComponentFactory.Krypton.Docking.KryptonDockableWorkspace();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockableWorkspace)).BeginInit();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusDate});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 838);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.mainStatusStrip.Size = new System.Drawing.Size(1584, 23);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1504, 18);
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
            this.office2013_edited.BaseRenderMode = ComponentFactory.Krypton.Toolkit.RendererMode.Professional;
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
            this.mainRibbon.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.mainRibbon.RibbonAppButton.AppButtonText = "Menu";
            this.mainRibbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.homeTab,
            this.databaseTab});
            this.mainRibbon.SelectedContext = null;
            this.mainRibbon.SelectedTab = this.databaseTab;
            this.mainRibbon.Size = new System.Drawing.Size(1584, 115);
            this.mainRibbon.TabIndex = 4;
            // 
            // homeTab
            // 
            this.homeTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.surveyRibbonGroup,
            this.clientRibbonGroup,
            this.realtorRibbonGroup,
            this.tcRibbonGroup,
            this.helpGroup});
            this.homeTab.Text = "Home";
            // 
            // surveyRibbonGroup
            // 
            this.surveyRibbonGroup.DialogBoxLauncher = false;
            this.surveyRibbonGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
            this.surveyRibbonGroup.TextLine1 = "Survey";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton1,
            this.kryptonRibbonGroupButton2,
            this.kryptonRibbonGroupButton3});
            // 
            // kryptonRibbonGroupButton1
            // 
            this.kryptonRibbonGroupButton1.ImageLarge = global::SurveyManager.Properties.Resources.surveying;
            this.kryptonRibbonGroupButton1.ImageSmall = global::SurveyManager.Properties.Resources.surveying_16x16;
            this.kryptonRibbonGroupButton1.TextLine1 = "Find";
            this.kryptonRibbonGroupButton1.Click += new System.EventHandler(this.findSurveyBtn_Click);
            // 
            // kryptonRibbonGroupButton2
            // 
            this.kryptonRibbonGroupButton2.ImageLarge = global::SurveyManager.Properties.Resources.add;
            this.kryptonRibbonGroupButton2.ImageSmall = global::SurveyManager.Properties.Resources.add_16x16;
            this.kryptonRibbonGroupButton2.TextLine1 = "New";
            this.kryptonRibbonGroupButton2.Click += new System.EventHandler(this.newSurveyBtn_Click);
            // 
            // kryptonRibbonGroupButton3
            // 
            this.kryptonRibbonGroupButton3.ImageLarge = global::SurveyManager.Properties.Resources.view;
            this.kryptonRibbonGroupButton3.ImageSmall = global::SurveyManager.Properties.Resources.view_16x16;
            this.kryptonRibbonGroupButton3.TextLine1 = "View All";
            this.kryptonRibbonGroupButton3.Click += new System.EventHandler(this.viewSurveysBtn_Click);
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
            // helpGroup
            // 
            this.helpGroup.DialogBoxLauncher = false;
            this.helpGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple7});
            this.helpGroup.TextLine1 = "Help";
            // 
            // kryptonRibbonGroupTriple7
            // 
            this.kryptonRibbonGroupTriple7.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnUserManual});
            // 
            // btnUserManual
            // 
            this.btnUserManual.ImageLarge = global::SurveyManager.Properties.Resources.info;
            this.btnUserManual.ImageSmall = global::SurveyManager.Properties.Resources.info_16x16;
            this.btnUserManual.TextLine1 = "User";
            this.btnUserManual.TextLine2 = "Manual";
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
            // 
            // importDataBtn
            // 
            this.importDataBtn.ImageLarge = global::SurveyManager.Properties.Resources.import;
            this.importDataBtn.ImageSmall = global::SurveyManager.Properties.Resources.import;
            this.importDataBtn.TextLine1 = "Import";
            this.importDataBtn.TextLine2 = "Data";
            // 
            // btnSqlQuery
            // 
            this.btnSqlQuery.ImageLarge = global::SurveyManager.Properties.Resources.sql;
            this.btnSqlQuery.ImageSmall = global::SurveyManager.Properties.Resources.sql_16x16;
            this.btnSqlQuery.TextLine1 = "SQL";
            this.btnSqlQuery.TextLine2 = "Query";
            this.btnSqlQuery.Click += new System.EventHandler(this.sqlQueryBtn_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dockableWorkspace);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 115);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1584, 723);
            this.kryptonPanel1.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.kryptonPanel1.TabIndex = 5;
            // 
            // dockableWorkspace
            // 
            this.dockableWorkspace.AutoHiddenHost = false;
            this.dockableWorkspace.CompactFlags = ((ComponentFactory.Krypton.Workspace.CompactFlags)(((ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptyCells | ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptySequences) 
            | ComponentFactory.Krypton.Workspace.CompactFlags.PromoteLeafs)));
            this.dockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockableWorkspace.Location = new System.Drawing.Point(0, 0);
            this.dockableWorkspace.Name = "dockableWorkspace";
            // 
            // 
            // 
            this.dockableWorkspace.Root.UniqueName = "FD3F779B80FA42AB2284FE60B3AE5414";
            this.dockableWorkspace.Root.WorkspaceControl = this.dockableWorkspace;
            this.dockableWorkspace.ShowMaximizeButton = false;
            this.dockableWorkspace.Size = new System.Drawing.Size(1584, 723);
            this.dockableWorkspace.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dockableWorkspace.TabIndex = 0;
            this.dockableWorkspace.TabStop = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.mainRibbon);
            this.Controls.Add(this.mainStatusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
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
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab homeTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup surveyRibbonGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton3;
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
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup helpGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple7;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnUserManual;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab databaseTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple5;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnDBConnection;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple6;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton exportDataBtn;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton importDataBtn;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSqlQuery;
        private ComponentFactory.Krypton.Docking.KryptonDockingManager dockingManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Docking.KryptonDockableWorkspace dockableWorkspace;
    }
}

