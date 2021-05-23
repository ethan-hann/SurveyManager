
namespace SurveyManager.forms.mailClient
{
    partial class SendEmail
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblToAddress = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtToAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCCAddresses = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddAttachments = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblAttachedFiles = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSendEmail = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonRichTextBox1 = new SurveyManager.utility.CustomControls.CRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(750, 603);
            this.kryptonSplitContainer1.SplitterDistance = 164;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 164);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblToAddress);
            this.flowLayoutPanel2.Controls.Add(this.txtToAddress);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(740, 36);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // lblToAddress
            // 
            this.lblToAddress.Location = new System.Drawing.Point(3, 3);
            this.lblToAddress.Name = "lblToAddress";
            this.lblToAddress.Size = new System.Drawing.Size(27, 20);
            this.lblToAddress.TabIndex = 0;
            this.lblToAddress.Values.Text = "To:";
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(36, 3);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(695, 23);
            this.txtToAddress.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel3.Controls.Add(this.txtCCAddresses);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 45);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(740, 36);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(28, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "CC: ";
            // 
            // txtCCAddresses
            // 
            this.txtCCAddresses.Location = new System.Drawing.Point(37, 3);
            this.txtCCAddresses.Name = "txtCCAddresses";
            this.txtCCAddresses.Size = new System.Drawing.Size(695, 23);
            this.txtCCAddresses.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel4.Controls.Add(this.txtSubject);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 87);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(740, 36);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "Subject: ";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(62, 3);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(670, 23);
            this.txtSubject.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.btnAddAttachments);
            this.flowLayoutPanel5.Controls.Add(this.lblAttachedFiles);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 129);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(740, 32);
            this.flowLayoutPanel5.TabIndex = 4;
            // 
            // btnAddAttachments
            // 
            this.btnAddAttachments.Location = new System.Drawing.Point(3, 3);
            this.btnAddAttachments.Name = "btnAddAttachments";
            this.btnAddAttachments.Size = new System.Drawing.Size(119, 25);
            this.btnAddAttachments.TabIndex = 0;
            this.btnAddAttachments.Values.Text = "Add Attachment(s)";
            // 
            // lblAttachedFiles
            // 
            this.lblAttachedFiles.Location = new System.Drawing.Point(128, 3);
            this.lblAttachedFiles.Name = "lblAttachedFiles";
            this.lblAttachedFiles.Size = new System.Drawing.Size(100, 20);
            this.lblAttachedFiles.TabIndex = 1;
            this.lblAttachedFiles.Values.Text = "(Attached Files: )";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Image = global::SurveyManager.Properties.Resources.send_email_16x16;
            this.btnSendEmail.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSendEmail.Text = "Send Message";
            this.btnSendEmail.UniqueName = "C9C6BB4976FC4B3E44957E95D4BD8E6B";
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.RTFText = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil Microsoft " +
    "Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs29\\" +
    "par\r\n}\r\n";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(750, 434);
            this.kryptonRichTextBox1.TabIndex = 0;
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSendEmail});
            this.ClientSize = new System.Drawing.Size(750, 603);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Email";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblToAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtToAddress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCCAddresses;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubject;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddAttachments;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAttachedFiles;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSendEmail;
        private SurveyManager.utility.CustomControls.CRichTextBox kryptonRichTextBox1;
    }
}