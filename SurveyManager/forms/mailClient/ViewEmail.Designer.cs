
namespace SurveyManager.forms.mailClient
{
    partial class ViewEmail
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
            this.splitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tvMailbox = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.btnSync = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.fetchMailWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvMailbox);
            this.splitContainer.Size = new System.Drawing.Size(1067, 688);
            this.splitContainer.SplitterDistance = 259;
            this.splitContainer.TabIndex = 0;
            // 
            // tvMailbox
            // 
            this.tvMailbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMailbox.Location = new System.Drawing.Point(0, 0);
            this.tvMailbox.Name = "tvMailbox";
            this.tvMailbox.Size = new System.Drawing.Size(259, 688);
            this.tvMailbox.TabIndex = 0;
            this.tvMailbox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMailbox_AfterSelect);
            // 
            // btnSync
            // 
            this.btnSync.Image = global::SurveyManager.Properties.Resources.sync_16x16;
            this.btnSync.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnSync.Text = "Sync From Server";
            this.btnSync.UniqueName = "596C7EA7CA69462406B0E1EA043F23EE";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 688);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1067, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // fetchMailWorker
            // 
            this.fetchMailWorker.WorkerReportsProgress = true;
            this.fetchMailWorker.WorkerSupportsCancellation = true;
            this.fetchMailWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fetchMailWorker_DoWork);
            this.fetchMailWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fetchMailWorker_ProgressChanged);
            this.fetchMailWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fetchMailWorker_RunWorkerCompleted);
            // 
            // ViewEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSync});
            this.ClientSize = new System.Drawing.Size(1067, 710);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewEmail_FormClosing);
            this.Load += new System.EventHandler(this.ViewEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainer;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSync;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView tvMailbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker fetchMailWorker;
    }
}