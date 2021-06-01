
namespace SurveyManager.forms.surveyMenu
{
    partial class LineItemsCtl
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
            this.components = new System.ComponentModel.Container();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.lbItems = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveItem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddItem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.propGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSubTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.hdrGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSaveUpdate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).BeginInit();
            this.hdrGroup.Panel.SuspendLayout();
            this.hdrGroup.SuspendLayout();
            this.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lbItems);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonSplitContainer1.Panel1MinSize = 272;
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.propGrid);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.statusStrip);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(827, 737);
            this.kryptonSplitContainer1.SplitterDistance = 272;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // lbItems
            // 
            this.lbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItems.Location = new System.Drawing.Point(0, 0);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(272, 707);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveItem);
            this.flowLayoutPanel1.Controls.Add(this.btnAddItem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 707);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(135, 3);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(134, 25);
            this.btnRemoveItem.TabIndex = 1;
            this.btnRemoveItem.Values.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveItem.Values.Text = "Remove Item";
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(6, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(123, 25);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddItem.Values.Text = "New Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Location = new System.Drawing.Point(0, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propGrid.Size = new System.Drawing.Size(550, 715);
            this.propGrid.TabIndex = 0;
            this.propGrid.ToolbarVisible = false;
            this.propGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblSubTotal});
            this.statusStrip.Location = new System.Drawing.Point(0, 715);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(550, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(402, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(133, 17);
            this.lblSubTotal.Text = "Sub Total for Line Items:";
            // 
            // hdrGroup
            // 
            this.hdrGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSaveUpdate});
            this.hdrGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hdrGroup.Location = new System.Drawing.Point(0, 0);
            this.hdrGroup.Name = "hdrGroup";
            // 
            // hdrGroup.Panel
            // 
            this.hdrGroup.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.hdrGroup.Size = new System.Drawing.Size(829, 790);
            this.hdrGroup.TabIndex = 1;
            this.hdrGroup.ValuesPrimary.Heading = "Billing Line Items";
            this.hdrGroup.ValuesPrimary.Image = null;
            this.hdrGroup.ValuesSecondary.Heading = "Add or remove additional billing line items for this survey job. Once done, be su" +
    "re to click \"Save and Update\".";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Image = global::SurveyManager.Properties.Resources.save_16x16;
            this.btnSaveUpdate.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSaveUpdate.Text = "Save and Update";
            this.btnSaveUpdate.UniqueName = "044D33CA7EE541CB8FA44D6F7BEDCE0A";
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // LineItemsCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hdrGroup);
            this.Name = "LineItemsCtl";
            this.Size = new System.Drawing.Size(829, 790);
            this.Load += new System.EventHandler(this.LineItemsCtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).EndInit();
            this.hdrGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).EndInit();
            this.hdrGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbItems;
        private utility.CustomControls.CPropertyGrid propGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveItem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblSubTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hdrGroup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSaveUpdate;
    }
}
