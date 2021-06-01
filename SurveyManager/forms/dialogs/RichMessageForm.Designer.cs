
namespace SurveyManager.forms.dialogs
{
    partial class RichMessageForm
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblText = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.rtbMessage = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.btnYes = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.ErrorImage = null;
            this.picImage.InitialImage = null;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(64, 64);
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.lblText.Location = new System.Drawing.Point(82, 12);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 15);
            this.lblText.Text = "Text";
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(12, 82);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.ReadOnly = true;
            this.rtbMessage.Size = new System.Drawing.Size(601, 205);
            this.rtbMessage.TabIndex = 0;
            this.rtbMessage.Text = "";
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Location = new System.Drawing.Point(376, 295);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 25);
            this.btnYes.TabIndex = 1;
            this.btnYes.Values.Text = "Yes";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Location = new System.Drawing.Point(457, 295);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 25);
            this.btnNo.TabIndex = 2;
            this.btnNo.Values.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(538, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(457, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Values.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // RichMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 332);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.picImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RichMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picImage;
        internal ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblText;
        internal ComponentFactory.Krypton.Toolkit.KryptonRichTextBox rtbMessage;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnYes;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnNo;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
    }
}