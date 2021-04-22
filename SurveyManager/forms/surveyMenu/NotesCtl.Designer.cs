
namespace SurveyManager.forms.surveyMenu
{
    partial class NotesCtl
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
            this.lbNoteKeys = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.txtNoteContents = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveNote = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddNote = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalNoteCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCharCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.btnSaveUpdate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNoteKeys
            // 
            this.lbNoteKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNoteKeys.Location = new System.Drawing.Point(0, 0);
            this.lbNoteKeys.Name = "lbNoteKeys";
            this.lbNoteKeys.Size = new System.Drawing.Size(269, 765);
            this.lbNoteKeys.TabIndex = 0;
            this.lbNoteKeys.SelectedIndexChanged += new System.EventHandler(this.lbNoteKeys_SelectedIndexChanged);
            // 
            // txtNoteContents
            // 
            this.txtNoteContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoteContents.Location = new System.Drawing.Point(0, 0);
            this.txtNoteContents.MaxLength = 4000;
            this.txtNoteContents.Name = "txtNoteContents";
            this.txtNoteContents.Size = new System.Drawing.Size(1039, 775);
            this.txtNoteContents.TabIndex = 1;
            this.txtNoteContents.Text = "";
            this.txtNoteContents.TextChanged += new System.EventHandler(this.txtNoteContents_TextChanged);
            this.txtNoteContents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoteContents_KeyPress);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveNote);
            this.flowLayoutPanel1.Controls.Add(this.btnAddNote);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 765);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnRemoveNote
            // 
            this.btnRemoveNote.Location = new System.Drawing.Point(132, 3);
            this.btnRemoveNote.Name = "btnRemoveNote";
            this.btnRemoveNote.Size = new System.Drawing.Size(134, 25);
            this.btnRemoveNote.TabIndex = 1;
            this.btnRemoveNote.Values.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveNote.Values.Text = "Remove Note";
            this.btnRemoveNote.Click += new System.EventHandler(this.btnRemoveNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(3, 3);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(123, 25);
            this.btnAddNote.TabIndex = 0;
            this.btnAddNote.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddNote.Values.Text = "New Note";
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalNoteCount,
            this.toolStripStatusLabel1,
            this.lblCharCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 775);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1039, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalNoteCount
            // 
            this.lblTotalNoteCount.Name = "lblTotalNoteCount";
            this.lblTotalNoteCount.Size = new System.Drawing.Size(102, 17);
            this.lblTotalNoteCount.Text = "Total # of Notes: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(778, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblCharCount
            // 
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCharCount.Size = new System.Drawing.Size(144, 17);
            this.lblCharCount.Text = "Character Count: 0 / 4,000";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSaveUpdate});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(1315, 850);
            this.kryptonHeaderGroup1.TabIndex = 5;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Notes";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Add or remove notes for this survey job.";
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lbNoteKeys);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonSplitContainer1.Panel1MinSize = 269;
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.txtNoteContents);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1313, 797);
            this.kryptonSplitContainer1.SplitterDistance = 269;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Image = global::SurveyManager.Properties.Resources.save_16x16;
            this.btnSaveUpdate.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSaveUpdate.Text = "Save and Update";
            this.btnSaveUpdate.UniqueName = "45228DD5F5884DC512B13DB153AB511A";
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // NotesCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "NotesCtl";
            this.Size = new System.Drawing.Size(1315, 850);
            this.Load += new System.EventHandler(this.NotesCtl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbNoteKeys;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtNoteContents;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveNote;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNote;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalNoteCount;
        private System.Windows.Forms.ToolStripStatusLabel lblCharCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSaveUpdate;
    }
}
