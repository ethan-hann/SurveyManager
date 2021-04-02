
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.surveysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSurveyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newSurveyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editSurveyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSurveysBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findClientBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newClientBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editClientBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewClientsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.realtorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findRealtorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newRealtorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editRealtorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRealtorsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.titleCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findTitleCompanyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.newTitleCompanyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editTitleCompanyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTitleCompanyBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConnectionBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDatabaseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.importDatabaseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlQueryBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.kManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.office2013_edited = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.menuStrip1.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.surveysToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.realtorToolStripMenuItem,
            this.titleCompanyToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsBtn,
            this.aboutBtn,
            this.toolStripSeparator5,
            this.exitBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Image = global::SurveyManager.Properties.Resources.settings;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(136, 26);
            this.settingsBtn.Text = "Settings";
            // 
            // aboutBtn
            // 
            this.aboutBtn.Image = global::SurveyManager.Properties.Resources.info;
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(136, 26);
            this.aboutBtn.Text = "About";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(133, 6);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(136, 26);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // surveysToolStripMenuItem
            // 
            this.surveysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findSurveyBtn,
            this.toolStripSeparator1,
            this.newSurveyBtn,
            this.editSurveyBtn,
            this.viewSurveysBtn});
            this.surveysToolStripMenuItem.Name = "surveysToolStripMenuItem";
            this.surveysToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.surveysToolStripMenuItem.Text = "Survey";
            // 
            // findSurveyBtn
            // 
            this.findSurveyBtn.Image = global::SurveyManager.Properties.Resources.surveying;
            this.findSurveyBtn.Name = "findSurveyBtn";
            this.findSurveyBtn.Size = new System.Drawing.Size(132, 26);
            this.findSurveyBtn.Text = "Find...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // newSurveyBtn
            // 
            this.newSurveyBtn.Image = global::SurveyManager.Properties.Resources.add;
            this.newSurveyBtn.Name = "newSurveyBtn";
            this.newSurveyBtn.Size = new System.Drawing.Size(132, 26);
            this.newSurveyBtn.Text = "New...";
            // 
            // editSurveyBtn
            // 
            this.editSurveyBtn.Image = global::SurveyManager.Properties.Resources.edit;
            this.editSurveyBtn.Name = "editSurveyBtn";
            this.editSurveyBtn.Size = new System.Drawing.Size(132, 26);
            this.editSurveyBtn.Text = "Edit...";
            // 
            // viewSurveysBtn
            // 
            this.viewSurveysBtn.Image = global::SurveyManager.Properties.Resources.view;
            this.viewSurveysBtn.Name = "viewSurveysBtn";
            this.viewSurveysBtn.Size = new System.Drawing.Size(132, 26);
            this.viewSurveysBtn.Text = "View...";
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findClientBtn,
            this.toolStripSeparator2,
            this.newClientBtn,
            this.editClientBtn,
            this.viewClientsBtn});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(64, 26);
            this.clientToolStripMenuItem.Text = "Client";
            // 
            // findClientBtn
            // 
            this.findClientBtn.Image = global::SurveyManager.Properties.Resources.client;
            this.findClientBtn.Name = "findClientBtn";
            this.findClientBtn.Size = new System.Drawing.Size(132, 26);
            this.findClientBtn.Text = "Find...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // newClientBtn
            // 
            this.newClientBtn.Image = global::SurveyManager.Properties.Resources.add;
            this.newClientBtn.Name = "newClientBtn";
            this.newClientBtn.Size = new System.Drawing.Size(132, 26);
            this.newClientBtn.Text = "New...";
            this.newClientBtn.Click += new System.EventHandler(this.newClientBtn_Click);
            // 
            // editClientBtn
            // 
            this.editClientBtn.Image = global::SurveyManager.Properties.Resources.edit;
            this.editClientBtn.Name = "editClientBtn";
            this.editClientBtn.Size = new System.Drawing.Size(132, 26);
            this.editClientBtn.Text = "Edit...";
            // 
            // viewClientsBtn
            // 
            this.viewClientsBtn.Image = global::SurveyManager.Properties.Resources.view;
            this.viewClientsBtn.Name = "viewClientsBtn";
            this.viewClientsBtn.Size = new System.Drawing.Size(132, 26);
            this.viewClientsBtn.Text = "View...";
            // 
            // realtorToolStripMenuItem
            // 
            this.realtorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findRealtorBtn,
            this.toolStripSeparator3,
            this.newRealtorBtn,
            this.editRealtorBtn,
            this.viewRealtorsBtn});
            this.realtorToolStripMenuItem.Name = "realtorToolStripMenuItem";
            this.realtorToolStripMenuItem.Size = new System.Drawing.Size(72, 26);
            this.realtorToolStripMenuItem.Text = "Realtor";
            // 
            // findRealtorBtn
            // 
            this.findRealtorBtn.Image = global::SurveyManager.Properties.Resources.realtor;
            this.findRealtorBtn.Name = "findRealtorBtn";
            this.findRealtorBtn.Size = new System.Drawing.Size(132, 26);
            this.findRealtorBtn.Text = "Find...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(129, 6);
            // 
            // newRealtorBtn
            // 
            this.newRealtorBtn.Image = global::SurveyManager.Properties.Resources.add;
            this.newRealtorBtn.Name = "newRealtorBtn";
            this.newRealtorBtn.Size = new System.Drawing.Size(132, 26);
            this.newRealtorBtn.Text = "New...";
            // 
            // editRealtorBtn
            // 
            this.editRealtorBtn.Image = global::SurveyManager.Properties.Resources.edit;
            this.editRealtorBtn.Name = "editRealtorBtn";
            this.editRealtorBtn.Size = new System.Drawing.Size(132, 26);
            this.editRealtorBtn.Text = "Edit...";
            // 
            // viewRealtorsBtn
            // 
            this.viewRealtorsBtn.Image = global::SurveyManager.Properties.Resources.view;
            this.viewRealtorsBtn.Name = "viewRealtorsBtn";
            this.viewRealtorsBtn.Size = new System.Drawing.Size(132, 26);
            this.viewRealtorsBtn.Text = "View...";
            // 
            // titleCompanyToolStripMenuItem
            // 
            this.titleCompanyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findTitleCompanyBtn,
            this.toolStripSeparator4,
            this.newTitleCompanyBtn,
            this.editTitleCompanyBtn,
            this.viewTitleCompanyBtn});
            this.titleCompanyToolStripMenuItem.Name = "titleCompanyToolStripMenuItem";
            this.titleCompanyToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.titleCompanyToolStripMenuItem.Text = "Title Company";
            // 
            // findTitleCompanyBtn
            // 
            this.findTitleCompanyBtn.Image = global::SurveyManager.Properties.Resources.title_company;
            this.findTitleCompanyBtn.Name = "findTitleCompanyBtn";
            this.findTitleCompanyBtn.Size = new System.Drawing.Size(132, 26);
            this.findTitleCompanyBtn.Text = "Find...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(129, 6);
            // 
            // newTitleCompanyBtn
            // 
            this.newTitleCompanyBtn.Image = global::SurveyManager.Properties.Resources.add;
            this.newTitleCompanyBtn.Name = "newTitleCompanyBtn";
            this.newTitleCompanyBtn.Size = new System.Drawing.Size(132, 26);
            this.newTitleCompanyBtn.Text = "New...";
            // 
            // editTitleCompanyBtn
            // 
            this.editTitleCompanyBtn.Image = global::SurveyManager.Properties.Resources.edit;
            this.editTitleCompanyBtn.Name = "editTitleCompanyBtn";
            this.editTitleCompanyBtn.Size = new System.Drawing.Size(132, 26);
            this.editTitleCompanyBtn.Text = "Edit...";
            // 
            // viewTitleCompanyBtn
            // 
            this.viewTitleCompanyBtn.Image = global::SurveyManager.Properties.Resources.view;
            this.viewTitleCompanyBtn.Name = "viewTitleCompanyBtn";
            this.viewTitleCompanyBtn.Size = new System.Drawing.Size(132, 26);
            this.viewTitleCompanyBtn.Text = "View...";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbConnectionBtn,
            this.toolStripSeparator6,
            this.exportDatabaseBtn,
            this.importDatabaseBtn,
            this.sqlQueryBtn});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(86, 26);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // dbConnectionBtn
            // 
            this.dbConnectionBtn.Image = global::SurveyManager.Properties.Resources.db_connection;
            this.dbConnectionBtn.Name = "dbConnectionBtn";
            this.dbConnectionBtn.Size = new System.Drawing.Size(239, 26);
            this.dbConnectionBtn.Text = "Connection Settings...";
            this.dbConnectionBtn.Click += new System.EventHandler(this.dbConnectionBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(236, 6);
            // 
            // exportDatabaseBtn
            // 
            this.exportDatabaseBtn.Image = global::SurveyManager.Properties.Resources.export;
            this.exportDatabaseBtn.Name = "exportDatabaseBtn";
            this.exportDatabaseBtn.Size = new System.Drawing.Size(239, 26);
            this.exportDatabaseBtn.Text = "Export...";
            // 
            // importDatabaseBtn
            // 
            this.importDatabaseBtn.Image = global::SurveyManager.Properties.Resources.import;
            this.importDatabaseBtn.Name = "importDatabaseBtn";
            this.importDatabaseBtn.Size = new System.Drawing.Size(239, 26);
            this.importDatabaseBtn.Text = "Import...";
            // 
            // sqlQueryBtn
            // 
            this.sqlQueryBtn.Image = global::SurveyManager.Properties.Resources.sql;
            this.sqlQueryBtn.Name = "sqlQueryBtn";
            this.sqlQueryBtn.Size = new System.Drawing.Size(239, 26);
            this.sqlQueryBtn.Text = "SQL Query...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualBtn});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(54, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualBtn
            // 
            this.userManualBtn.Image = global::SurveyManager.Properties.Resources.info;
            this.userManualBtn.Name = "userManualBtn";
            this.userManualBtn.Size = new System.Drawing.Size(163, 26);
            this.userManualBtn.Text = "User Manual";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusDate});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 568);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.mainStatusStrip.Size = new System.Drawing.Size(1028, 23);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(948, 18);
            this.lblStatus.Spring = true;
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
            this.office2013_edited.ToolMenuStatus.MenuStrip.MenuStripFont = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.office2013_edited.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.office2013_edited.ToolMenuStatus.MenuStrip.MenuStripText = System.Drawing.Color.Black;
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = System.Drawing.Color.SteelBlue;
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = System.Drawing.Color.SteelBlue;
            this.office2013_edited.ToolMenuStatus.StatusStrip.StatusStripText = System.Drawing.Color.LightYellow;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 591);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsBtn;
        private System.Windows.Forms.ToolStripMenuItem aboutBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.ToolStripMenuItem surveysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSurveyBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newSurveyBtn;
        private System.Windows.Forms.ToolStripMenuItem editSurveyBtn;
        private System.Windows.Forms.ToolStripMenuItem viewSurveysBtn;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findClientBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem newClientBtn;
        private System.Windows.Forms.ToolStripMenuItem editClientBtn;
        private System.Windows.Forms.ToolStripMenuItem viewClientsBtn;
        private System.Windows.Forms.ToolStripMenuItem realtorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findRealtorBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem newRealtorBtn;
        private System.Windows.Forms.ToolStripMenuItem editRealtorBtn;
        private System.Windows.Forms.ToolStripMenuItem viewRealtorsBtn;
        private System.Windows.Forms.ToolStripMenuItem titleCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findTitleCompanyBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem newTitleCompanyBtn;
        private System.Windows.Forms.ToolStripMenuItem editTitleCompanyBtn;
        private System.Windows.Forms.ToolStripMenuItem viewTitleCompanyBtn;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDatabaseBtn;
        private System.Windows.Forms.ToolStripMenuItem importDatabaseBtn;
        private System.Windows.Forms.ToolStripMenuItem sqlQueryBtn;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualBtn;
        private System.Windows.Forms.ToolStripMenuItem dbConnectionBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusDate;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Timer clockTimer;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette office2013_edited;
    }
}

