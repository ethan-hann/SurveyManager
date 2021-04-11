
namespace SurveyManager.forms.userControls
{
    partial class ViewObjectsCtl
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
            this.components = new System.ComponentModel.Container();
            JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection outlookGridGroupCollection1 = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection();
            this.hdrGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.dataGrid = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid();
            this.groupBox = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGridGroupBox();
            this.loadProgressBar = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.propGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.btnDeleteRow = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).BeginInit();
            this.hdrGroup.Panel.SuspendLayout();
            this.hdrGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // hdrGroup
            // 
            this.hdrGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnFilter,
            this.btnRefresh,
            this.btnDeleteRow});
            this.hdrGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdrGroup.Location = new System.Drawing.Point(0, 0);
            this.hdrGroup.Name = "hdrGroup";
            // 
            // hdrGroup.Panel
            // 
            this.hdrGroup.Panel.Controls.Add(this.dataGrid);
            this.hdrGroup.Panel.Controls.Add(this.groupBox);
            this.hdrGroup.Size = new System.Drawing.Size(957, 287);
            this.hdrGroup.TabIndex = 7;
            this.hdrGroup.ValuesPrimary.Heading = "";
            this.hdrGroup.ValuesPrimary.Image = null;
            this.hdrGroup.ValuesSecondary.Heading = "Select a row to display its properties below. You can edit the property grid belo" +
    "w and click save to update the database.";
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::SurveyManager.Properties.Resources.filter_16x16;
            this.btnFilter.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnFilter.Text = "Filter...";
            this.btnFilter.ToolTipBody = "Filter the data in the grid to find exactly what you are looking for.";
            this.btnFilter.ToolTipTitle = "Filter";
            this.btnFilter.UniqueName = "5077032067AC4562BBB84A45FEEB2C81";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::SurveyManager.Properties.Resources.reload_16x16;
            this.btnRefresh.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UniqueName = "193F7B3442034733E7BBC4E91B0F7F8B";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowDrop = true;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.FillMode = JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.FillMode.GROUPSANDNODES;
            this.dataGrid.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dataGrid.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dataGrid.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dataGrid.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dataGrid.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dataGrid.GroupBox = this.groupBox;
            this.dataGrid.GroupCollection = outlookGridGroupCollection1;
            this.dataGrid.Location = new System.Drawing.Point(0, 31);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.PreviousSelectedGroupRow = -1;
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(955, 198);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // groupBox
            // 
            this.groupBox.AllowDrop = true;
            this.groupBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(955, 31);
            this.groupBox.TabIndex = 1;
            // 
            // loadProgressBar
            // 
            this.loadProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadProgressBar.Location = new System.Drawing.Point(0, 608);
            this.loadProgressBar.MarqueeAnimationSpeed = 10;
            this.loadProgressBar.Name = "loadProgressBar";
            this.loadProgressBar.Size = new System.Drawing.Size(957, 23);
            this.loadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadProgressBar.TabIndex = 6;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Compressed Zip File (*.zip)|*.zip";
            this.saveDialog.Title = "Save Files";
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Location = new System.Drawing.Point(0, 287);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(957, 321);
            this.propGrid.TabIndex = 5;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnDeleteRow.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnDeleteRow.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.ToolTipBody = "Deletes the selected row entry from the database.";
            this.btnDeleteRow.ToolTipTitle = "Delete";
            this.btnDeleteRow.UniqueName = "12A3525AC11A4985AB8BD4CBA1F36584";
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // ViewObjectsCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.hdrGroup);
            this.Controls.Add(this.loadProgressBar);
            this.Name = "ViewObjectsCtl";
            this.Size = new System.Drawing.Size(957, 631);
            this.Load += new System.EventHandler(this.ViewObjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).EndInit();
            this.hdrGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).EndInit();
            this.hdrGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private utility.CustomControls.CPropertyGrid propGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hdrGroup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnFilter;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid dataGrid;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGridGroupBox groupBox;
        private System.Windows.Forms.ProgressBar loadProgressBar;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteRow;
    }
}
