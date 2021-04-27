
namespace SurveyManager.forms.dialogs
{
    partial class ActivationDlg
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
            this.grpLicenseGUID = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lnkCopyGUID = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.rtbGUID = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnPurchase = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.radHasLicenseFile = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radNeedLicenseFile = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grpLicenseInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pgLicense = new System.Windows.Forms.PropertyGrid();
            this.lblLicenseInvalid = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnBrowseForLicense = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnFinish = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseGUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseGUID.Panel)).BeginInit();
            this.grpLicenseGUID.Panel.SuspendLayout();
            this.grpLicenseGUID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseInfo.Panel)).BeginInit();
            this.grpLicenseInfo.Panel.SuspendLayout();
            this.grpLicenseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLicenseGUID
            // 
            this.grpLicenseGUID.Location = new System.Drawing.Point(387, 3);
            this.grpLicenseGUID.Name = "grpLicenseGUID";
            // 
            // grpLicenseGUID.Panel
            // 
            this.grpLicenseGUID.Panel.Controls.Add(this.lnkCopyGUID);
            this.grpLicenseGUID.Panel.Controls.Add(this.rtbGUID);
            this.grpLicenseGUID.Panel.Controls.Add(this.kryptonLabel1);
            this.grpLicenseGUID.Size = new System.Drawing.Size(451, 110);
            this.grpLicenseGUID.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.grpLicenseGUID.TabIndex = 0;
            this.grpLicenseGUID.Values.Heading = "License GUID";
            this.grpLicenseGUID.Visible = false;
            // 
            // lnkCopyGUID
            // 
            this.lnkCopyGUID.Location = new System.Drawing.Point(334, 62);
            this.lnkCopyGUID.Name = "lnkCopyGUID";
            this.lnkCopyGUID.Size = new System.Drawing.Size(110, 20);
            this.lnkCopyGUID.TabIndex = 2;
            this.lnkCopyGUID.Values.Text = "Copy to Clipboard";
            this.lnkCopyGUID.LinkClicked += new System.EventHandler(this.lnkCopyGUID_LinkClicked);
            // 
            // rtbGUID
            // 
            this.rtbGUID.Location = new System.Drawing.Point(4, 30);
            this.rtbGUID.Multiline = false;
            this.rtbGUID.Name = "rtbGUID";
            this.rtbGUID.ReadOnly = true;
            this.rtbGUID.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbGUID.Size = new System.Drawing.Size(440, 26);
            this.rtbGUID.TabIndex = 1;
            this.rtbGUID.Text = "";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(340, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Please provide the GUID below when purchasing the license:";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(361, 74);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(105, 25);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Values.Text = "Purchase";
            this.btnPurchase.Visible = false;
            // 
            // radHasLicenseFile
            // 
            this.radHasLicenseFile.Checked = true;
            this.radHasLicenseFile.Location = new System.Drawing.Point(3, 3);
            this.radHasLicenseFile.Name = "radHasLicenseFile";
            this.radHasLicenseFile.Size = new System.Drawing.Size(127, 20);
            this.radHasLicenseFile.TabIndex = 2;
            this.radHasLicenseFile.Values.Text = "I have a license file.";
            this.radHasLicenseFile.CheckedChanged += new System.EventHandler(this.radHasLicenseFile_CheckedChanged);
            // 
            // radNeedLicenseFile
            // 
            this.radNeedLicenseFile.Location = new System.Drawing.Point(3, 29);
            this.radNeedLicenseFile.Name = "radNeedLicenseFile";
            this.radNeedLicenseFile.Size = new System.Drawing.Size(176, 20);
            this.radNeedLicenseFile.TabIndex = 3;
            this.radNeedLicenseFile.Values.Text = "I need to purchase a license.";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.radHasLicenseFile);
            this.kryptonGroupBox2.Panel.Controls.Add(this.radNeedLicenseFile);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(199, 84);
            this.kryptonGroupBox2.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonGroupBox2.TabIndex = 4;
            this.kryptonGroupBox2.Values.Heading = "Choose One";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.grpLicenseInfo);
            this.flowLayoutPanel1.Controls.Add(this.grpLicenseGUID);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 102);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(845, 363);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // grpLicenseInfo
            // 
            this.grpLicenseInfo.Location = new System.Drawing.Point(3, 3);
            this.grpLicenseInfo.Name = "grpLicenseInfo";
            // 
            // grpLicenseInfo.Panel
            // 
            this.grpLicenseInfo.Panel.Controls.Add(this.kryptonLabel2);
            this.grpLicenseInfo.Panel.Controls.Add(this.pgLicense);
            this.grpLicenseInfo.Panel.Controls.Add(this.lblLicenseInvalid);
            this.grpLicenseInfo.Panel.Controls.Add(this.btnBrowseForLicense);
            this.grpLicenseInfo.Size = new System.Drawing.Size(378, 360);
            this.grpLicenseInfo.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.grpLicenseInfo.TabIndex = 12;
            this.grpLicenseInfo.Values.Heading = "License Information";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Select License: ";
            // 
            // pgLicense
            // 
            this.pgLicense.Location = new System.Drawing.Point(3, 55);
            this.pgLicense.Name = "pgLicense";
            this.pgLicense.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgLicense.Size = new System.Drawing.Size(368, 278);
            this.pgLicense.TabIndex = 10;
            this.pgLicense.ToolbarVisible = false;
            // 
            // lblLicenseInvalid
            // 
            this.lblLicenseInvalid.Location = new System.Drawing.Point(3, 29);
            this.lblLicenseInvalid.Name = "lblLicenseInvalid";
            this.lblLicenseInvalid.Size = new System.Drawing.Size(308, 21);
            this.lblLicenseInvalid.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.lblLicenseInvalid.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseInvalid.TabIndex = 7;
            this.lblLicenseInvalid.Values.Text = "License Invalid! Please select a valid license file.";
            this.lblLicenseInvalid.Visible = false;
            // 
            // btnBrowseForLicense
            // 
            this.btnBrowseForLicense.Location = new System.Drawing.Point(98, 3);
            this.btnBrowseForLicense.Name = "btnBrowseForLicense";
            this.btnBrowseForLicense.Size = new System.Drawing.Size(105, 25);
            this.btnBrowseForLicense.TabIndex = 8;
            this.btnBrowseForLicense.Values.Text = "Browse...";
            this.btnBrowseForLicense.Click += new System.EventHandler(this.btnBrowseForLicense_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "License.lic";
            this.dlgOpenFile.Filter = "License File|*.lic";
            this.dlgOpenFile.ReadOnlyChecked = true;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(361, 74);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(105, 25);
            this.btnFinish.TabIndex = 13;
            this.btnFinish.Values.Text = "Finish";
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // ActivationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 477);
            this.ControlBox = false;
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.kryptonGroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivationDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey Manager Activation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Activation_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Activation_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseGUID.Panel)).EndInit();
            this.grpLicenseGUID.Panel.ResumeLayout(false);
            this.grpLicenseGUID.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseGUID)).EndInit();
            this.grpLicenseGUID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseInfo.Panel)).EndInit();
            this.grpLicenseInfo.Panel.ResumeLayout(false);
            this.grpLicenseInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLicenseInfo)).EndInit();
            this.grpLicenseInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpLicenseGUID;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lnkCopyGUID;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox rtbGUID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPurchase;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radHasLicenseFile;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radNeedLicenseFile;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpLicenseInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.PropertyGrid pgLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLicenseInvalid;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowseForLicense;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFinish;
    }
}