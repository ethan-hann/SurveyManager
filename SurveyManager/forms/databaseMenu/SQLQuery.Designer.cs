
namespace SurveyManager.forms.databaseMenu
{
    partial class SQLQuery
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
            JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection outlookGridGroupCollection2 = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection();
            this.txtQuery = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnExecuteQuery = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnSqlHelp = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.resultsGrid = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(720, 130);
            this.txtQuery.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.StateNormal.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.Text = "";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnExecuteQuery,
            this.btnSqlHelp});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtQuery);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(722, 183);
            this.kryptonHeaderGroup1.TabIndex = 1;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Enter your SQL query below:";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = global::SurveyManager.Properties.Resources.sql_16x16;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Run a custom query against the database and show the results below.";
            // 
            // btnExecuteQuery
            // 
            this.btnExecuteQuery.Image = global::SurveyManager.Properties.Resources.execute_16x16;
            this.btnExecuteQuery.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnExecuteQuery.Text = "Execute";
            this.btnExecuteQuery.ToolTipBody = "Execute the SQL query against the database.";
            this.btnExecuteQuery.ToolTipTitle = "Execute";
            this.btnExecuteQuery.UniqueName = "D2B0B7114BAE4CD70FBB632603785179";
            this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
            // 
            // btnSqlHelp
            // 
            this.btnSqlHelp.Image = global::SurveyManager.Properties.Resources.info_16x16;
            this.btnSqlHelp.Text = "SQL Help";
            this.btnSqlHelp.ToolTipBody = "Takes you to a web page where you can view help about basic SQL commands.";
            this.btnSqlHelp.ToolTipTitle = "SQL Help";
            this.btnSqlHelp.UniqueName = "17FB047BEFA14FEF5080A263F9A06CC9";
            // 
            // resultsGrid
            // 
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGrid.FillMode = JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.FillMode.GROUPSANDNODES;
            this.resultsGrid.GroupCollection = outlookGridGroupCollection2;
            this.resultsGrid.Location = new System.Drawing.Point(0, 183);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.PreviousSelectedGroupRow = -1;
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.Size = new System.Drawing.Size(722, 161);
            this.resultsGrid.TabIndex = 2;
            // 
            // SQLQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 344);
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "SQLQuery";
            this.Text = "SQLQuery";
            this.Load += new System.EventHandler(this.SQLQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtQuery;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid resultsGrid;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnExecuteQuery;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSqlHelp;
    }
}