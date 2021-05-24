
namespace SurveyManager.forms.dialogs.SettingsDialog
{
    partial class GeneralSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkEnableSurveyAutoSave = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.flpInterval = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.nudAutoSaveInterval = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.radLastTwoDigits = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radCustomText = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.flpCustomText = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCustomPrefix = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblCharCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flpExampleText = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPrefixPreview = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flpInterval.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flpCustomText.SuspendLayout();
            this.flpExampleText.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkEnableSurveyAutoSave);
            this.flowLayoutPanel1.Controls.Add(this.flpInterval);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flpCustomText);
            this.flowLayoutPanel1.Controls.Add(this.flpExampleText);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 352);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkEnableSurveyAutoSave
            // 
            this.chkEnableSurveyAutoSave.Location = new System.Drawing.Point(3, 3);
            this.chkEnableSurveyAutoSave.Name = "chkEnableSurveyAutoSave";
            this.chkEnableSurveyAutoSave.Size = new System.Drawing.Size(240, 20);
            this.chkEnableSurveyAutoSave.TabIndex = 0;
            this.chkEnableSurveyAutoSave.Values.Text = "Enable autosave feature for Survey Jobs";
            this.chkEnableSurveyAutoSave.CheckedChanged += new System.EventHandler(this.chkEnableSurveyAutoSave_CheckedChanged);
            this.chkEnableSurveyAutoSave.MouseEnter += new System.EventHandler(this.chkEnableSurveyAutoSave_MouseEnter);
            this.chkEnableSurveyAutoSave.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // flpInterval
            // 
            this.flpInterval.Controls.Add(this.kryptonLabel1);
            this.flpInterval.Controls.Add(this.nudAutoSaveInterval);
            this.flpInterval.Controls.Add(this.kryptonLabel2);
            this.flpInterval.Location = new System.Drawing.Point(3, 29);
            this.flpInterval.Name = "flpInterval";
            this.flpInterval.Size = new System.Drawing.Size(311, 29);
            this.flpInterval.TabIndex = 1;
            this.flpInterval.Visible = false;
            this.flpInterval.MouseEnter += new System.EventHandler(this.flpInterval_MouseEnter);
            this.flpInterval.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(107, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Autosave Interval: ";
            // 
            // nudAutoSaveInterval
            // 
            this.nudAutoSaveInterval.Location = new System.Drawing.Point(116, 3);
            this.nudAutoSaveInterval.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudAutoSaveInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAutoSaveInterval.Name = "nudAutoSaveInterval";
            this.nudAutoSaveInterval.Size = new System.Drawing.Size(90, 22);
            this.nudAutoSaveInterval.TabIndex = 1;
            this.nudAutoSaveInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(212, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "minutes";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel2.Controls.Add(this.radLastTwoDigits);
            this.flowLayoutPanel2.Controls.Add(this.radCustomText);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 64);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(385, 29);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "Job # Prefix:";
            // 
            // radLastTwoDigits
            // 
            this.radLastTwoDigits.Checked = true;
            this.radLastTwoDigits.Location = new System.Drawing.Point(85, 3);
            this.radLastTwoDigits.Name = "radLastTwoDigits";
            this.radLastTwoDigits.Size = new System.Drawing.Size(191, 20);
            this.radLastTwoDigits.TabIndex = 1;
            this.radLastTwoDigits.Values.Text = "Last Two Digits of Current Year";
            this.radLastTwoDigits.CheckedChanged += new System.EventHandler(this.radLastTwoDigits_CheckedChanged);
            this.radLastTwoDigits.MouseEnter += new System.EventHandler(this.radLastTwoDigits_MouseEnter);
            this.radLastTwoDigits.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // radCustomText
            // 
            this.radCustomText.Location = new System.Drawing.Point(282, 3);
            this.radCustomText.Name = "radCustomText";
            this.radCustomText.Size = new System.Drawing.Size(91, 20);
            this.radCustomText.TabIndex = 2;
            this.radCustomText.Values.Text = "Custom Text";
            this.radCustomText.MouseEnter += new System.EventHandler(this.radCustomText_MouseEnter);
            this.radCustomText.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // flpCustomText
            // 
            this.flpCustomText.Controls.Add(this.kryptonLabel4);
            this.flpCustomText.Controls.Add(this.txtCustomPrefix);
            this.flpCustomText.Controls.Add(this.lblCharCount);
            this.flpCustomText.Location = new System.Drawing.Point(3, 99);
            this.flpCustomText.Name = "flpCustomText";
            this.flpCustomText.Size = new System.Drawing.Size(385, 29);
            this.flpCustomText.TabIndex = 3;
            this.flpCustomText.Visible = false;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel4.TabIndex = 1;
            this.kryptonLabel4.Values.Text = "Enter Text: ";
            // 
            // txtCustomPrefix
            // 
            this.txtCustomPrefix.Location = new System.Drawing.Point(77, 3);
            this.txtCustomPrefix.MaxLength = 128;
            this.txtCustomPrefix.Name = "txtCustomPrefix";
            this.txtCustomPrefix.Size = new System.Drawing.Size(172, 23);
            this.txtCustomPrefix.TabIndex = 2;
            this.txtCustomPrefix.TextChanged += new System.EventHandler(this.txtCustomPrefix_TextChanged);
            // 
            // lblCharCount
            // 
            this.lblCharCount.Location = new System.Drawing.Point(255, 3);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(119, 20);
            this.lblCharCount.TabIndex = 3;
            this.lblCharCount.Values.Text = "Char. Count: 0 / 128 ";
            // 
            // flpExampleText
            // 
            this.flpExampleText.BackColor = System.Drawing.Color.Silver;
            this.flpExampleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpExampleText.Controls.Add(this.lblPrefixPreview);
            this.flpExampleText.Location = new System.Drawing.Point(3, 134);
            this.flpExampleText.Name = "flpExampleText";
            this.flpExampleText.Size = new System.Drawing.Size(385, 34);
            this.flpExampleText.TabIndex = 4;
            this.flpExampleText.MouseEnter += new System.EventHandler(this.flpExampleText_MouseEnter);
            this.flpExampleText.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // lblPrefixPreview
            // 
            this.lblPrefixPreview.Location = new System.Drawing.Point(3, 3);
            this.lblPrefixPreview.Name = "lblPrefixPreview";
            this.lblPrefixPreview.Size = new System.Drawing.Size(187, 26);
            this.lblPrefixPreview.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.lblPrefixPreview.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefixPreview.StateCommon.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.lblPrefixPreview.StateCommon.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.lblPrefixPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefixPreview.StateCommon.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.lblPrefixPreview.StateCommon.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.lblPrefixPreview.TabIndex = 3;
            this.lblPrefixPreview.Values.ExtraText = "21-1252";
            this.lblPrefixPreview.Values.Text = "Example Job #: ";
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GeneralSettings";
            this.Size = new System.Drawing.Size(519, 352);
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flpInterval.ResumeLayout(false);
            this.flpInterval.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flpCustomText.ResumeLayout(false);
            this.flpCustomText.PerformLayout();
            this.flpExampleText.ResumeLayout(false);
            this.flpExampleText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkEnableSurveyAutoSave;
        private System.Windows.Forms.FlowLayoutPanel flpInterval;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudAutoSaveInterval;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radLastTwoDigits;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radCustomText;
        private System.Windows.Forms.FlowLayoutPanel flpCustomText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCustomPrefix;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCharCount;
        private System.Windows.Forms.FlowLayoutPanel flpExampleText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPrefixPreview;
    }
}
