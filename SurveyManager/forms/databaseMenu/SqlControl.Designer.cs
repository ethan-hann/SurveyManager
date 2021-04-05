
namespace SurveyManager.forms.databaseMenu
{
    partial class SqlControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection outlookGridGroupCollection1 = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection();
            this.resultsGrid = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.txtQuery = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.btnExecuteQuery = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnSqlHelp = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultsGrid
            // 
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGrid.FillMode = JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.FillMode.GROUPSANDNODES;
            this.resultsGrid.GroupCollection = outlookGridGroupCollection1;
            this.resultsGrid.Location = new System.Drawing.Point(0, 183);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.PreviousSelectedGroupRow = -1;
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.Size = new System.Drawing.Size(704, 256);
            this.resultsGrid.TabIndex = 4;
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
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(704, 183);
            this.kryptonHeaderGroup1.TabIndex = 3;
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "Click \"Execute\" to run the query:";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = global::SurveyManager.Properties.Resources.sql_16x16;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Run a custom query against the database and show the results below.";
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(702, 131);
            this.txtQuery.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.StateNormal.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.Text = "";
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
            this.btnSqlHelp.Click += new System.EventHandler(this.btnSqlHelp_Click);
            // 
            // SqlControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "SqlControl";
            this.Size = new System.Drawing.Size(704, 439);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid resultsGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnExecuteQuery;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSqlHelp;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtQuery;
    }
}
