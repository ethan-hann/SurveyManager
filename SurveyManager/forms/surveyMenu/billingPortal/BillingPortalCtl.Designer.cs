
namespace SurveyManager.forms.userControls
{
    partial class BillingPortalCtl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection outlookGridGroupCollection1 = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridGroupCollection();
            this.hdrGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pgTimeEntries = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.lbTimeEntries = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveTime = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddTime = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gridHeaderGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnNewEntry = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnSaveAndUpdate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditTime = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.billingGrid = new JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid();
            this.pgAdditionalLineItems = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.loadProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadBillingDetailsWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).BeginInit();
            this.hdrGroup.Panel.SuspendLayout();
            this.hdrGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgTimeEntries)).BeginInit();
            this.pgTimeEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaderGroup.Panel)).BeginInit();
            this.gridHeaderGroup.Panel.SuspendLayout();
            this.gridHeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgAdditionalLineItems)).BeginInit();
            this.SuspendLayout();
            // 
            // hdrGroup
            // 
            this.hdrGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hdrGroup.Location = new System.Drawing.Point(0, 0);
            this.hdrGroup.Name = "hdrGroup";
            // 
            // hdrGroup.Panel
            // 
            this.hdrGroup.Panel.Controls.Add(this.kryptonNavigator1);
            this.hdrGroup.Panel.Controls.Add(this.loadProgressBar);
            this.hdrGroup.Size = new System.Drawing.Size(1133, 756);
            this.hdrGroup.TabIndex = 0;
            this.hdrGroup.ValuesPrimary.Heading = "Billing Portal";
            this.hdrGroup.ValuesPrimary.Image = null;
            this.hdrGroup.ValuesSecondary.Heading = "Manage the rates, billing items, and time entries for the current job.";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SmoothEqual;
            this.kryptonNavigator1.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.OneNote;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pgTimeEntries,
            this.pgAdditionalLineItems});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1131, 680);
            this.kryptonNavigator1.TabIndex = 1;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // pgTimeEntries
            // 
            this.pgTimeEntries.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pgTimeEntries.Controls.Add(this.kryptonSplitContainer1);
            this.pgTimeEntries.Flags = 65534;
            this.pgTimeEntries.ImageSmall = global::SurveyManager.Properties.Resources.billing_rates_16x16;
            this.pgTimeEntries.LastVisibleSet = true;
            this.pgTimeEntries.MinimumSize = new System.Drawing.Size(50, 50);
            this.pgTimeEntries.Name = "pgTimeEntries";
            this.pgTimeEntries.Size = new System.Drawing.Size(1129, 651);
            this.pgTimeEntries.Text = "Time Entries";
            this.pgTimeEntries.ToolTipTitle = "Page ToolTip";
            this.pgTimeEntries.UniqueName = "7E5565BDE95841DBC9BDE8BA804433B8";
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lbTimeEntries);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonSplitContainer1.Panel1MinSize = 269;
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.gridHeaderGroup);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1129, 651);
            this.kryptonSplitContainer1.SplitterDistance = 270;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // lbTimeEntries
            // 
            this.lbTimeEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimeEntries.Location = new System.Drawing.Point(0, 0);
            this.lbTimeEntries.Name = "lbTimeEntries";
            this.lbTimeEntries.Size = new System.Drawing.Size(270, 619);
            this.lbTimeEntries.TabIndex = 3;
            this.lbTimeEntries.SelectedIndexChanged += new System.EventHandler(this.lbTimeEntries_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveTime);
            this.flowLayoutPanel1.Controls.Add(this.btnAddTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 619);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(270, 32);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnRemoveTime
            // 
            this.btnRemoveTime.Location = new System.Drawing.Point(133, 3);
            this.btnRemoveTime.Name = "btnRemoveTime";
            this.btnRemoveTime.Size = new System.Drawing.Size(134, 25);
            this.btnRemoveTime.TabIndex = 1;
            this.btnRemoveTime.Values.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveTime.Values.Text = "Remove Day";
            this.btnRemoveTime.Click += new System.EventHandler(this.btnRemoveTime_Click);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(4, 3);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(123, 25);
            this.btnAddTime.TabIndex = 0;
            this.btnAddTime.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddTime.Values.Text = "New Day";
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // gridHeaderGroup
            // 
            this.gridHeaderGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnNewEntry,
            this.btnSaveAndUpdate,
            this.btnEditTime});
            this.gridHeaderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.gridHeaderGroup.Name = "gridHeaderGroup";
            // 
            // gridHeaderGroup.Panel
            // 
            this.gridHeaderGroup.Panel.Controls.Add(this.billingGrid);
            this.gridHeaderGroup.Size = new System.Drawing.Size(854, 651);
            this.gridHeaderGroup.TabIndex = 2;
            this.gridHeaderGroup.ValuesPrimary.Heading = "Total Time: ";
            this.gridHeaderGroup.ValuesPrimary.Image = global::SurveyManager.Properties.Resources.time_16x16;
            this.gridHeaderGroup.ValuesSecondary.Heading = "Shows all of the time entries for the selected day. Double-click a row to edit it" +
    " or select a row and press <DEL> on keyboard to remove it.";
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnNewEntry.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnNewEntry.Text = "New Time Entry...";
            this.btnNewEntry.ToolTipBody = "Create a new time entry for the selected day.";
            this.btnNewEntry.ToolTipTitle = "Time Entries";
            this.btnNewEntry.UniqueName = "505F945D91C44B679A9F72A5BFAD1F79";
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // btnSaveAndUpdate
            // 
            this.btnSaveAndUpdate.Image = global::SurveyManager.Properties.Resources.save_16x16;
            this.btnSaveAndUpdate.Text = "Save and Update";
            this.btnSaveAndUpdate.ToolTipBody = "Saves the time entries internally. Does not save to database.";
            this.btnSaveAndUpdate.ToolTipTitle = "Save";
            this.btnSaveAndUpdate.UniqueName = "78CDC8FC2E324D5D3088A8C6BA0657B1";
            this.btnSaveAndUpdate.Click += new System.EventHandler(this.btnSaveAndUpdate_Click);
            // 
            // btnEditTime
            // 
            this.btnEditTime.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnEditTime.Image = global::SurveyManager.Properties.Resources.edit_16x16;
            this.btnEditTime.Text = "Edit Time...";
            this.btnEditTime.ToolTipBody = "Opens the selected row for editing.";
            this.btnEditTime.ToolTipTitle = "Edit";
            this.btnEditTime.UniqueName = "E3E3C5B10803428C489F888D84A648C2";
            this.btnEditTime.Click += new System.EventHandler(this.btnEditTime_Click);
            // 
            // billingGrid
            // 
            this.billingGrid.AllowUserToAddRows = false;
            this.billingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billingGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.billingGrid.FillMode = JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.FillMode.GROUPSANDNODES;
            this.billingGrid.GroupCollection = outlookGridGroupCollection1;
            this.billingGrid.Location = new System.Drawing.Point(0, 0);
            this.billingGrid.Name = "billingGrid";
            this.billingGrid.PreviousSelectedGroupRow = -1;
            this.billingGrid.ReadOnly = true;
            this.billingGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.billingGrid.Size = new System.Drawing.Size(852, 594);
            this.billingGrid.TabIndex = 1;
            this.billingGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.billingGrid_CellDoubleClick);
            this.billingGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.billingGrid_UserDeletedRow);
            this.billingGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.billingGrid_UserDeletingRow);
            // 
            // pgAdditionalLineItems
            // 
            this.pgAdditionalLineItems.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pgAdditionalLineItems.Flags = 65534;
            this.pgAdditionalLineItems.ImageSmall = global::SurveyManager.Properties.Resources.billing_line_items_16x16;
            this.pgAdditionalLineItems.LastVisibleSet = true;
            this.pgAdditionalLineItems.MinimumSize = new System.Drawing.Size(50, 50);
            this.pgAdditionalLineItems.Name = "pgAdditionalLineItems";
            this.pgAdditionalLineItems.Size = new System.Drawing.Size(1129, 646);
            this.pgAdditionalLineItems.Text = "Additional Items";
            this.pgAdditionalLineItems.ToolTipTitle = "Page ToolTip";
            this.pgAdditionalLineItems.UniqueName = "4F7B8A032FAD42B69485BD8A5F4E589F";
            // 
            // loadProgressBar
            // 
            this.loadProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadProgressBar.Location = new System.Drawing.Point(0, 680);
            this.loadProgressBar.Name = "loadProgressBar";
            this.loadProgressBar.Size = new System.Drawing.Size(1131, 23);
            this.loadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loadProgressBar.TabIndex = 1;
            this.loadProgressBar.Visible = false;
            // 
            // loadBillingDetailsWorker
            // 
            this.loadBillingDetailsWorker.WorkerReportsProgress = true;
            this.loadBillingDetailsWorker.WorkerSupportsCancellation = true;
            this.loadBillingDetailsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadBillingDetailsWorker_DoWork);
            this.loadBillingDetailsWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.loadBillingDetailsWorker_ProgressChanged);
            this.loadBillingDetailsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadBillingDetailsWorker_RunWorkerCompleted);
            // 
            // BillingPortalCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hdrGroup);
            this.Name = "BillingPortalCtl";
            this.Size = new System.Drawing.Size(1133, 756);
            this.Load += new System.EventHandler(this.BillingPortalCtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).EndInit();
            this.hdrGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).EndInit();
            this.hdrGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgTimeEntries)).EndInit();
            this.pgTimeEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaderGroup.Panel)).EndInit();
            this.gridHeaderGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaderGroup)).EndInit();
            this.gridHeaderGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.billingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgAdditionalLineItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hdrGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbTimeEntries;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveTime;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddTime;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage pgTimeEntries;
        private ComponentFactory.Krypton.Navigator.KryptonPage pgAdditionalLineItems;
        private System.ComponentModel.BackgroundWorker loadBillingDetailsWorker;
        private System.Windows.Forms.ProgressBar loadProgressBar;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup gridHeaderGroup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnNewEntry;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSaveAndUpdate;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditTime;
        private JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.KryptonOutlookGrid billingGrid;
    }
}
