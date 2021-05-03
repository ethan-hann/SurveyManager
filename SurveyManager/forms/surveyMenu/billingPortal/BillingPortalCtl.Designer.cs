
namespace SurveyManager.forms.userControls
{
    partial class BillingPortalCtl
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
            this.hdrGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.lbTimeEntries = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveTime = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddTime = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radOfficeTime = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radFieldTime = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbRates = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewRate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimeEntry = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpTimeEntry = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btnSaveTimeEntry = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRefreshRates = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).BeginInit();
            this.hdrGroup.Panel.SuspendLayout();
            this.hdrGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRates)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.Panel2.SuspendLayout();
            this.kryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
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
            this.hdrGroup.Size = new System.Drawing.Size(1133, 756);
            this.hdrGroup.TabIndex = 0;
            this.hdrGroup.ValuesPrimary.Heading = "Billing Portal";
            this.hdrGroup.ValuesPrimary.Image = global::SurveyManager.Properties.Resources.billing_portal_32x32;
            this.hdrGroup.ValuesSecondary.Heading = "Manage the rates, billing items, and time entries for the current job.";
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1129, 671);
            this.kryptonSplitContainer1.SplitterDistance = 270;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // lbTimeEntries
            // 
            this.lbTimeEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimeEntries.Location = new System.Drawing.Point(0, 0);
            this.lbTimeEntries.Name = "lbTimeEntries";
            this.lbTimeEntries.Size = new System.Drawing.Size(270, 639);
            this.lbTimeEntries.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveTime);
            this.flowLayoutPanel1.Controls.Add(this.btnAddTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 639);
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
            this.btnRemoveTime.Values.Text = "Remove Time Entry";
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(4, 3);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(123, 25);
            this.btnAddTime.TabIndex = 0;
            this.btnAddTime.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddTime.Values.Text = "Add Time Entry";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(854, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(772, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel2.Text = "Total Time: ";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Controls.Add(this.radOfficeTime);
            this.flowLayoutPanel2.Controls.Add(this.radFieldTime);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveTimeEntry);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(854, 200);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // radOfficeTime
            // 
            this.radOfficeTime.Checked = true;
            this.radOfficeTime.Location = new System.Drawing.Point(3, 3);
            this.radOfficeTime.Name = "radOfficeTime";
            this.radOfficeTime.Size = new System.Drawing.Size(116, 20);
            this.radOfficeTime.TabIndex = 1;
            this.radOfficeTime.Values.Text = "Office Time Entry";
            this.radOfficeTime.CheckedChanged += new System.EventHandler(this.radOfficeTime_CheckedChanged);
            // 
            // radFieldTime
            // 
            this.radFieldTime.Location = new System.Drawing.Point(3, 29);
            this.radFieldTime.Name = "radFieldTime";
            this.radFieldTime.Size = new System.Drawing.Size(109, 20);
            this.radFieldTime.TabIndex = 2;
            this.radFieldTime.Values.Text = "Field Time Entry";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblRate);
            this.flowLayoutPanel3.Controls.Add(this.cmbRates);
            this.flowLayoutPanel3.Controls.Add(this.btnRefreshRates);
            this.flowLayoutPanel3.Controls.Add(this.btnAddNewRate);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(544, 32);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(3, 3);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(38, 20);
            this.lblRate.TabIndex = 0;
            this.lblRate.Values.Text = "Rate: ";
            // 
            // cmbRates
            // 
            this.cmbRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRates.DropDownWidth = 323;
            this.cmbRates.Location = new System.Drawing.Point(47, 3);
            this.cmbRates.Name = "cmbRates";
            this.cmbRates.Size = new System.Drawing.Size(323, 21);
            this.cmbRates.TabIndex = 1;
            // 
            // btnAddNewRate
            // 
            this.btnAddNewRate.Location = new System.Drawing.Point(417, 3);
            this.btnAddNewRate.Name = "btnAddNewRate";
            this.btnAddNewRate.Size = new System.Drawing.Size(123, 25);
            this.btnAddNewRate.TabIndex = 2;
            this.btnAddNewRate.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddNewRate.Values.Text = "Add New Rate...";
            this.btnAddNewRate.Click += new System.EventHandler(this.btnAddNewRate_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.lblTimeEntry);
            this.flowLayoutPanel4.Controls.Add(this.dtpTimeEntry);
            this.flowLayoutPanel4.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 93);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(406, 45);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // lblTimeEntry
            // 
            this.lblTimeEntry.Location = new System.Drawing.Point(3, 3);
            this.lblTimeEntry.Name = "lblTimeEntry";
            this.lblTimeEntry.Size = new System.Drawing.Size(40, 20);
            this.lblTimeEntry.TabIndex = 0;
            this.lblTimeEntry.Values.Text = "Time: ";
            // 
            // dtpTimeEntry
            // 
            this.dtpTimeEntry.CustomFormat = "HH:mm:ss";
            this.dtpTimeEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEntry.Location = new System.Drawing.Point(49, 3);
            this.dtpTimeEntry.Name = "dtpTimeEntry";
            this.dtpTimeEntry.ShowUpDown = true;
            this.dtpTimeEntry.Size = new System.Drawing.Size(117, 37);
            this.dtpTimeEntry.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeEntry.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(172, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(229, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Format -> (hours) : (minutes) : (seconds)";
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            this.kryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.flowLayoutPanel2);
            this.kryptonSplitContainer2.Panel1MinSize = 200;
            // 
            // kryptonSplitContainer2.Panel2
            // 
            this.kryptonSplitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(854, 649);
            this.kryptonSplitContainer2.SplitterDistance = 200;
            this.kryptonSplitContainer2.TabIndex = 2;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(854, 444);
            this.propertyGrid1.TabIndex = 0;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1131, 698);
            this.kryptonNavigator1.TabIndex = 1;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(1129, 671);
            this.kryptonPage1.Text = "Time Entries";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "7E5565BDE95841DBC9BDE8BA804433B8";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(1129, 671);
            this.kryptonPage2.Text = "Additional Items";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "4F7B8A032FAD42B69485BD8A5F4E589F";
            // 
            // btnSaveTimeEntry
            // 
            this.btnSaveTimeEntry.Location = new System.Drawing.Point(3, 144);
            this.btnSaveTimeEntry.Name = "btnSaveTimeEntry";
            this.btnSaveTimeEntry.Size = new System.Drawing.Size(228, 42);
            this.btnSaveTimeEntry.TabIndex = 4;
            this.btnSaveTimeEntry.Values.Image = global::SurveyManager.Properties.Resources.save_16x16;
            this.btnSaveTimeEntry.Values.Text = "Save Entry";
            this.btnSaveTimeEntry.Click += new System.EventHandler(this.btnSaveTimeEntry_Click);
            // 
            // btnRefreshRates
            // 
            this.btnRefreshRates.Location = new System.Drawing.Point(376, 3);
            this.btnRefreshRates.Name = "btnRefreshRates";
            this.btnRefreshRates.Size = new System.Drawing.Size(35, 25);
            this.btnRefreshRates.TabIndex = 3;
            this.btnRefreshRates.Values.Image = global::SurveyManager.Properties.Resources.reload_16x16;
            this.btnRefreshRates.Values.Text = "";
            this.btnRefreshRates.Click += new System.EventHandler(this.btnRefreshRates_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRates)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            this.kryptonSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hdrGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbTimeEntries;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveTime;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radOfficeTime;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radFieldTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRate;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbRates;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNewRate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTimeEntry;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpTimeEntry;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveTimeEntry;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRefreshRates;
    }
}
