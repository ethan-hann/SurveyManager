
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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.messageView = new System.Windows.Forms.WebBrowser();
            this.infoPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblAttachments = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblSubject = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblFrom = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnReply = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnForward = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnSync = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.tvMailbox = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.fetchMailWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.tvMailbox);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.messageView);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.infoPanel);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1067, 688);
            this.kryptonSplitContainer1.SplitterDistance = 259;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // messageView
            // 
            this.messageView.AllowWebBrowserDrop = false;
            this.messageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageView.IsWebBrowserContextMenuEnabled = false;
            this.messageView.Location = new System.Drawing.Point(0, 109);
            this.messageView.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageView.Name = "messageView";
            this.messageView.ScriptErrorsSuppressed = true;
            this.messageView.Size = new System.Drawing.Size(803, 579);
            this.messageView.TabIndex = 1;
            this.messageView.Url = new System.Uri("", System.UriKind.Relative);
            this.messageView.WebBrowserShortcutsEnabled = false;
            this.messageView.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.messageView_Navigating);
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.lblAttachments);
            this.infoPanel.Controls.Add(this.lblSubject);
            this.infoPanel.Controls.Add(this.lblTo);
            this.infoPanel.Controls.Add(this.lblFrom);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(803, 109);
            this.infoPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.infoPanel.TabIndex = 0;
            // 
            // lblAttachments
            // 
            this.lblAttachments.Location = new System.Drawing.Point(3, 81);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(82, 20);
            this.lblAttachments.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.lblAttachments.TabIndex = 3;
            this.lblAttachments.Values.Text = "Attachments: ";
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(3, 55);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(53, 20);
            this.lblSubject.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Values.Text = "Subject: ";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(3, 29);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 20);
            this.lblTo.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.lblTo.TabIndex = 1;
            this.lblTo.Values.Text = "To: ";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(3, 3);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 20);
            this.lblFrom.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Values.Text = "From: ";
            // 
            // btnReply
            // 
            this.btnReply.Image = global::SurveyManager.Properties.Resources.email_16x16;
            this.btnReply.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnReply.Text = "Reply";
            this.btnReply.UniqueName = "9D1874E44E6E43EF70AAED9495FA04FB";
            // 
            // btnForward
            // 
            this.btnForward.Image = global::SurveyManager.Properties.Resources.forward_16x16;
            this.btnForward.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnForward.Text = "Forward";
            this.btnForward.UniqueName = "3A1C40FFD8E045A7DB8114A6EBA53330";
            // 
            // btnSync
            // 
            this.btnSync.Image = global::SurveyManager.Properties.Resources.sync_16x16;
            this.btnSync.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnSync.Text = "Sync From Server";
            this.btnSync.UniqueName = "596C7EA7CA69462406B0E1EA043F23EE";
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
            this.btnReply,
            this.btnForward,
            this.btnSync});
            this.ClientSize = new System.Drawing.Size(1067, 710);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewEmail_FormClosing);
            this.Load += new System.EventHandler(this.ViewEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel infoPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAttachments;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFrom;
        private System.Windows.Forms.WebBrowser messageView;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnReply;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnForward;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSync;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView tvMailbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker fetchMailWorker;
    }
}