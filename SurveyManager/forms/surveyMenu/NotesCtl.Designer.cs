
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalNoteCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCharCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNoteKeys
            // 
            this.lbNoteKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNoteKeys.Location = new System.Drawing.Point(0, 0);
            this.lbNoteKeys.Name = "lbNoteKeys";
            this.lbNoteKeys.Size = new System.Drawing.Size(271, 578);
            this.lbNoteKeys.TabIndex = 0;
            this.lbNoteKeys.SelectedIndexChanged += new System.EventHandler(this.lbNoteKeys_SelectedIndexChanged);
            // 
            // txtNoteContents
            // 
            this.txtNoteContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoteContents.Location = new System.Drawing.Point(271, 0);
            this.txtNoteContents.MaxLength = 4000;
            this.txtNoteContents.Name = "txtNoteContents";
            this.txtNoteContents.Size = new System.Drawing.Size(534, 610);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 578);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(271, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnRemoveNote
            // 
            this.btnRemoveNote.Location = new System.Drawing.Point(134, 3);
            this.btnRemoveNote.Name = "btnRemoveNote";
            this.btnRemoveNote.Size = new System.Drawing.Size(134, 25);
            this.btnRemoveNote.TabIndex = 1;
            this.btnRemoveNote.Values.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveNote.Values.Text = "Remove Note";
            this.btnRemoveNote.Click += new System.EventHandler(this.btnRemoveNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(5, 3);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(123, 25);
            this.btnAddNote.TabIndex = 0;
            this.btnAddNote.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddNote.Values.Text = "New Note";
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lbNoteKeys);
            this.kryptonPanel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(271, 610);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalNoteCount,
            this.toolStripStatusLabel1,
            this.lblCharCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(544, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblCharCount
            // 
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCharCount.Size = new System.Drawing.Size(144, 17);
            this.lblCharCount.Text = "Character Count: 0 / 4,000";
            // 
            // NotesCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNoteContents);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "NotesCtl";
            this.Size = new System.Drawing.Size(805, 632);
            this.Load += new System.EventHandler(this.NotesCtl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbNoteKeys;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtNoteContents;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveNote;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNote;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalNoteCount;
        private System.Windows.Forms.ToolStripStatusLabel lblCharCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
