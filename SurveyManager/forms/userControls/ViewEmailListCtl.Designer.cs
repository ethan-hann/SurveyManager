
namespace SurveyManager.forms.userControls
{
    partial class ViewEmailListCtl
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
            this.headerGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnMoreOptions = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.moreOptionsContext = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems3 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuSeparator2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator();
            this.kryptonContextMenuHeading2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
            this.kryptonContextMenuItem3 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem4 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem5 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem6 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator();
            this.kryptonContextMenuHeading1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
            this.emailGrid = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid();
            this.emailGroupBox = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGridGroupBox();
            this.loadMailBGWorker = new System.ComponentModel.BackgroundWorker();
            this.statusColumn = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.CustomColumns.KryptonDataGridViewTextAndImageColumn();
            this.senderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup.Panel)).BeginInit();
            this.headerGroup.Panel.SuspendLayout();
            this.headerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroup
            // 
            this.headerGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnMoreOptions});
            this.headerGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroup.Location = new System.Drawing.Point(0, 0);
            this.headerGroup.Name = "headerGroup";
            // 
            // headerGroup.Panel
            // 
            this.headerGroup.Panel.Controls.Add(this.emailGrid);
            this.headerGroup.Panel.Controls.Add(this.emailGroupBox);
            this.headerGroup.Size = new System.Drawing.Size(1091, 701);
            this.headerGroup.TabIndex = 0;
            this.headerGroup.ValuesPrimary.Description = "1-50 of 1882";
            this.headerGroup.ValuesPrimary.Heading = "Unread";
            this.headerGroup.ValuesPrimary.Image = null;
            this.headerGroup.ValuesSecondary.Heading = "";
            // 
            // btnMoreOptions
            // 
            this.btnMoreOptions.Image = global::SurveyManager.Properties.Resources.more_16x16;
            this.btnMoreOptions.KryptonContextMenu = this.moreOptionsContext;
            this.btnMoreOptions.UniqueName = "1A2492EE3D644AA3999D2721DF30D8AC";
            this.btnMoreOptions.Click += new System.EventHandler(this.btnMoreOptions_Click);
            // 
            // moreOptionsContext
            // 
            this.moreOptionsContext.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems3});
            // 
            // kryptonContextMenuItems3
            // 
            this.kryptonContextMenuItems3.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem2,
            this.kryptonContextMenuSeparator2,
            this.kryptonContextMenuHeading2,
            this.kryptonContextMenuItem3,
            this.kryptonContextMenuItem4,
            this.kryptonContextMenuItem5,
            this.kryptonContextMenuItem6});
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.Text = "Show more messages";
            // 
            // kryptonContextMenuHeading2
            // 
            this.kryptonContextMenuHeading2.ExtraText = "";
            this.kryptonContextMenuHeading2.Text = "Show up to";
            // 
            // kryptonContextMenuItem3
            // 
            this.kryptonContextMenuItem3.Text = "5 items";
            // 
            // kryptonContextMenuItem4
            // 
            this.kryptonContextMenuItem4.Text = "10 items";
            // 
            // kryptonContextMenuItem5
            // 
            this.kryptonContextMenuItem5.Text = "25 items";
            // 
            // kryptonContextMenuItem6
            // 
            this.kryptonContextMenuItem6.Text = "50 items";
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "Menu Item";
            // 
            // kryptonContextMenuHeading1
            // 
            this.kryptonContextMenuHeading1.ExtraText = "";
            // 
            // emailGrid
            // 
            this.emailGrid.AllowUserToAddRows = false;
            this.emailGrid.AllowUserToDeleteRows = false;
            this.emailGrid.AllowUserToResizeRows = false;
            this.emailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusColumn,
            this.senderColumn,
            this.contentColumn,
            this.dateColumn});
            this.emailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.emailGrid.FillMode = JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.FillMode.GROUPSANDNODES;
            this.emailGrid.GroupBox = this.emailGroupBox;
            this.emailGrid.GroupCollection = outlookGridGroupCollection1;
            this.emailGrid.Location = new System.Drawing.Point(0, 37);
            this.emailGrid.MultiSelect = false;
            this.emailGrid.Name = "emailGrid";
            this.emailGrid.PreviousSelectedGroupRow = -1;
            this.emailGrid.ReadOnly = true;
            this.emailGrid.Size = new System.Drawing.Size(1089, 629);
            this.emailGrid.TabIndex = 0;
            this.emailGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.emailGrid_CellMouseDoubleClick);
            // 
            // emailGroupBox
            // 
            this.emailGroupBox.AllowDrop = true;
            this.emailGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.emailGroupBox.Location = new System.Drawing.Point(0, 0);
            this.emailGroupBox.Name = "emailGroupBox";
            this.emailGroupBox.Size = new System.Drawing.Size(1089, 37);
            this.emailGroupBox.TabIndex = 1;
            // 
            // loadMailBGWorker
            // 
            this.loadMailBGWorker.WorkerReportsProgress = true;
            this.loadMailBGWorker.WorkerSupportsCancellation = true;
            this.loadMailBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadMailBGWorker_DoWork);
            this.loadMailBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.loadMailBGWorker_ProgressChanged);
            this.loadMailBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadMailBGWorker_RunWorkerCompleted);
            // 
            // statusColumn
            // 
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            // 
            // senderColumn
            // 
            this.senderColumn.HeaderText = "Sender";
            this.senderColumn.Name = "senderColumn";
            this.senderColumn.ReadOnly = true;
            // 
            // contentColumn
            // 
            this.contentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contentColumn.HeaderText = "Content";
            this.contentColumn.Name = "contentColumn";
            this.contentColumn.ReadOnly = true;
            // 
            // dateColumn
            // 
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            // 
            // ViewEmailListCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroup);
            this.Name = "ViewEmailListCtl";
            this.Size = new System.Drawing.Size(1091, 701);
            this.Load += new System.EventHandler(this.ViewEmailListCtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup.Panel)).EndInit();
            this.headerGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup)).EndInit();
            this.headerGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emailGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnMoreOptions;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu moreOptionsContext;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator kryptonContextMenuSeparator2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem4;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem5;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem6;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator kryptonContextMenuSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid emailGrid;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGridGroupBox emailGroupBox;
        private System.ComponentModel.BackgroundWorker loadMailBGWorker;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.CustomColumns.KryptonDataGridViewTextAndImageColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
    }
}
