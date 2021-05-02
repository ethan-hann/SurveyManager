using ComponentFactory.Krypton.Toolkit;

namespace SurveyManager.forms.dialogs
{
    partial class SaveMessageForm
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
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnYes = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.radSaveDontExit = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radExitWithoutSaving = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radSaveJobAndExit = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.ErrorImage = null;
            this.picImage.InitialImage = null;
            this.picImage.Location = new System.Drawing.Point(15, 15);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(64, 64);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.lblText.Location = new System.Drawing.Point(85, 15);
            this.lblText.MaximumSize = new System.Drawing.Size(294, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 15);
            this.lblText.Text = "Text";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(220, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Values.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(301, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Location = new System.Drawing.Point(220, 182);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 25);
            this.btnNo.TabIndex = 1;
            this.btnNo.Values.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Location = new System.Drawing.Point(139, 182);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 25);
            this.btnYes.TabIndex = 0;
            this.btnYes.Values.Text = "Yes";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Location = new System.Drawing.Point(15, 86);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.radSaveDontExit);
            this.kryptonGroup1.Panel.Controls.Add(this.radExitWithoutSaving);
            this.kryptonGroup1.Panel.Controls.Add(this.radSaveJobAndExit);
            this.kryptonGroup1.Size = new System.Drawing.Size(361, 90);
            this.kryptonGroup1.TabIndex = 5;
            // 
            // radSaveDontExit
            // 
            this.radSaveDontExit.Location = new System.Drawing.Point(4, 56);
            this.radSaveDontExit.Name = "radSaveDontExit";
            this.radSaveDontExit.Size = new System.Drawing.Size(156, 20);
            this.radSaveDontExit.TabIndex = 2;
            this.radSaveDontExit.Values.Text = "Save Job and DON\'T Exit";
            // 
            // radExitWithoutSaving
            // 
            this.radExitWithoutSaving.Location = new System.Drawing.Point(4, 30);
            this.radExitWithoutSaving.Name = "radExitWithoutSaving";
            this.radExitWithoutSaving.Size = new System.Drawing.Size(129, 20);
            this.radExitWithoutSaving.TabIndex = 1;
            this.radExitWithoutSaving.Values.Text = "Exit Without Saving";
            // 
            // radSaveJobAndExit
            // 
            this.radSaveJobAndExit.Checked = true;
            this.radSaveJobAndExit.Location = new System.Drawing.Point(4, 4);
            this.radSaveJobAndExit.Name = "radSaveJobAndExit";
            this.radSaveJobAndExit.Size = new System.Drawing.Size(116, 20);
            this.radSaveJobAndExit.TabIndex = 0;
            this.radSaveJobAndExit.Values.Text = "Save Job and Exit";
            // 
            // SaveMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 223);
            this.Controls.Add(this.kryptonGroup1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveMessageForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            this.kryptonGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.PictureBox picImage;
        internal KryptonWrapLabel lblText;
        internal KryptonButton btnOK;
        internal KryptonButton btnCancel;
        internal KryptonButton btnNo;
        internal KryptonButton btnYes;
        private KryptonGroup kryptonGroup1;
        internal KryptonRadioButton radSaveDontExit;
        internal KryptonRadioButton radExitWithoutSaving;
        internal KryptonRadioButton radSaveJobAndExit;
    }
}