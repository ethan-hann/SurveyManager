
namespace SurveyManager.forms.surveyMenu.billingPortal
{
    partial class NewEntryDlg
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
            this.radOfficeTime = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radFieldTime = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.lblRate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbRates = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnRefreshRates = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddNewRate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.grpDescritpion = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.rtbDescription = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDescCharCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeEntry = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpTimeEntry = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnSaveEntry = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.lblFormatBold = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblHelpText = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDescritpion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDescritpion.Panel)).BeginInit();
            this.grpDescritpion.Panel.SuspendLayout();
            this.grpDescritpion.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radOfficeTime
            // 
            this.radOfficeTime.Checked = true;
            this.radOfficeTime.Location = new System.Drawing.Point(15, 15);
            this.radOfficeTime.Margin = new System.Windows.Forms.Padding(6);
            this.radOfficeTime.Name = "radOfficeTime";
            this.radOfficeTime.Size = new System.Drawing.Size(173, 30);
            this.radOfficeTime.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOfficeTime.TabIndex = 1;
            this.radOfficeTime.Values.Text = "Office Time Entry";
            this.radOfficeTime.CheckedChanged += new System.EventHandler(this.radOfficeTime_CheckedChanged);
            this.radOfficeTime.MouseEnter += new System.EventHandler(this.radOfficeTime_MouseEnter);
            this.radOfficeTime.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // radFieldTime
            // 
            this.radFieldTime.Location = new System.Drawing.Point(200, 15);
            this.radFieldTime.Margin = new System.Windows.Forms.Padding(6);
            this.radFieldTime.Name = "radFieldTime";
            this.radFieldTime.Size = new System.Drawing.Size(162, 30);
            this.radFieldTime.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFieldTime.TabIndex = 2;
            this.radFieldTime.Values.Text = "Field Time Entry";
            this.radFieldTime.MouseEnter += new System.EventHandler(this.radFieldTime_MouseEnter);
            this.radFieldTime.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(18, 139);
            this.lblRate.Margin = new System.Windows.Forms.Padding(6);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(48, 26);
            this.lblRate.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.TabIndex = 0;
            this.lblRate.Values.Text = "Rate: ";
            this.lblRate.MouseEnter += new System.EventHandler(this.cmbRates_MouseEnter);
            this.lblRate.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // cmbRates
            // 
            this.cmbRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRates.DropDownWidth = 323;
            this.cmbRates.Location = new System.Drawing.Point(78, 144);
            this.cmbRates.Margin = new System.Windows.Forms.Padding(6);
            this.cmbRates.Name = "cmbRates";
            this.cmbRates.Size = new System.Drawing.Size(426, 21);
            this.cmbRates.TabIndex = 1;
            this.cmbRates.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // btnRefreshRates
            // 
            this.btnRefreshRates.Location = new System.Drawing.Point(516, 133);
            this.btnRefreshRates.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefreshRates.Name = "btnRefreshRates";
            this.btnRefreshRates.Size = new System.Drawing.Size(32, 32);
            this.btnRefreshRates.TabIndex = 3;
            this.btnRefreshRates.Values.Image = global::SurveyManager.Properties.Resources.reload_16x16;
            this.btnRefreshRates.Values.Text = "";
            this.btnRefreshRates.Click += new System.EventHandler(this.btnRefreshRates_Click);
            this.btnRefreshRates.MouseEnter += new System.EventHandler(this.btnRefreshRates_MouseEnter);
            this.btnRefreshRates.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // btnAddNewRate
            // 
            this.btnAddNewRate.Location = new System.Drawing.Point(560, 135);
            this.btnAddNewRate.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNewRate.Name = "btnAddNewRate";
            this.btnAddNewRate.Size = new System.Drawing.Size(129, 30);
            this.btnAddNewRate.TabIndex = 2;
            this.btnAddNewRate.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddNewRate.Values.Text = "Add New Rate...";
            this.btnAddNewRate.Click += new System.EventHandler(this.btnAddNewRate_Click);
            this.btnAddNewRate.MouseEnter += new System.EventHandler(this.btnAddNewRate_MouseEnter);
            this.btnAddNewRate.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // grpDescritpion
            // 
            this.grpDescritpion.CaptionOverlap = 0D;
            this.grpDescritpion.Location = new System.Drawing.Point(18, 177);
            this.grpDescritpion.Margin = new System.Windows.Forms.Padding(6);
            this.grpDescritpion.Name = "grpDescritpion";
            // 
            // grpDescritpion.Panel
            // 
            this.grpDescritpion.Panel.Controls.Add(this.rtbDescription);
            this.grpDescritpion.Panel.Controls.Add(this.statusStrip2);
            this.grpDescritpion.Size = new System.Drawing.Size(671, 151);
            this.grpDescritpion.TabIndex = 5;
            this.grpDescritpion.Values.Heading = "Short Description";
            this.grpDescritpion.MouseEnter += new System.EventHandler(this.rtbDescription_MouseEnter);
            this.grpDescritpion.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(0, 0);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(6);
            this.rtbDescription.MaxLength = 255;
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(667, 105);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            this.rtbDescription.TextChanged += new System.EventHandler(this.rtbDescription_TextChanged);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblDescCharCount});
            this.statusStrip2.Location = new System.Drawing.Point(0, 105);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip2.Size = new System.Drawing.Size(667, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(527, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // lblDescCharCount
            // 
            this.lblDescCharCount.Name = "lblDescCharCount";
            this.lblDescCharCount.Size = new System.Drawing.Size(112, 17);
            this.lblDescCharCount.Text = "Char. Count: 0 / 255";
            // 
            // lblTimeEntry
            // 
            this.lblTimeEntry.Location = new System.Drawing.Point(15, 68);
            this.lblTimeEntry.Margin = new System.Windows.Forms.Padding(6);
            this.lblTimeEntry.Name = "lblTimeEntry";
            this.lblTimeEntry.Size = new System.Drawing.Size(51, 26);
            this.lblTimeEntry.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeEntry.TabIndex = 0;
            this.lblTimeEntry.Values.Text = "Time: ";
            // 
            // dtpTimeEntry
            // 
            this.dtpTimeEntry.CustomFormat = "HH:mm:ss";
            this.dtpTimeEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEntry.Location = new System.Drawing.Point(78, 57);
            this.dtpTimeEntry.Margin = new System.Windows.Forms.Padding(6);
            this.dtpTimeEntry.Name = "dtpTimeEntry";
            this.dtpTimeEntry.ShowUpDown = true;
            this.dtpTimeEntry.Size = new System.Drawing.Size(123, 37);
            this.dtpTimeEntry.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeEntry.TabIndex = 1;
            this.dtpTimeEntry.MouseEnter += new System.EventHandler(this.dtpTimeEntry_MouseEnter);
            this.dtpTimeEntry.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // btnSaveEntry
            // 
            this.btnSaveEntry.Image = global::SurveyManager.Properties.Resources.save_16x16;
            this.btnSaveEntry.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnSaveEntry.Text = "Save";
            this.btnSaveEntry.ToolTipBody = "Save the entry to the grid.";
            this.btnSaveEntry.ToolTipTitle = "Save";
            this.btnSaveEntry.UniqueName = "F1EF53BC3A754C27099CA723B6C34E66";
            // 
            // btnReset
            // 
            this.btnReset.Image = global::SurveyManager.Properties.Resources.reload_16x16;
            this.btnReset.Text = "Reset Fields";
            this.btnReset.ToolTipBody = "Reset the fields to their default values.";
            this.btnReset.ToolTipTitle = "Reset";
            this.btnReset.UniqueName = "339AF97CB7454FD6E0BA58D7B03B55E7";
            // 
            // lblFormatBold
            // 
            this.lblFormatBold.Location = new System.Drawing.Point(32, 103);
            this.lblFormatBold.Name = "lblFormatBold";
            this.lblFormatBold.Size = new System.Drawing.Size(169, 21);
            this.lblFormatBold.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatBold.TabIndex = 9;
            this.lblFormatBold.Values.Text = "hours : minutes : seconds";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHelpText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblHelpText
            // 
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Size = new System.Drawing.Size(0, 17);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(210, 68);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(346, 21);
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 11;
            this.kryptonLabel1.Values.Text = "Max time allowed: 23 hours : 59 minutes : 59 seconds";
            // 
            // NewEntryDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSaveEntry,
            this.btnReset});
            this.ClientSize = new System.Drawing.Size(698, 377);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAddNewRate);
            this.Controls.Add(this.btnRefreshRates);
            this.Controls.Add(this.cmbRates);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblFormatBold);
            this.Controls.Add(this.dtpTimeEntry);
            this.Controls.Add(this.lblTimeEntry);
            this.Controls.Add(this.grpDescritpion);
            this.Controls.Add(this.radOfficeTime);
            this.Controls.Add(this.radFieldTime);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "NewEntryDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Time Entry";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NewEntryDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDescritpion.Panel)).EndInit();
            this.grpDescritpion.Panel.ResumeLayout(false);
            this.grpDescritpion.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDescritpion)).EndInit();
            this.grpDescritpion.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radOfficeTime;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radFieldTime;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRate;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbRates;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRefreshRates;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNewRate;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpDescritpion;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox rtbDescription;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblDescCharCount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTimeEntry;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpTimeEntry;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSaveEntry;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFormatBold;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblHelpText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}