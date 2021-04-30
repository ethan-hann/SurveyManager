
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
            this.flowLayoutPanel1.SuspendLayout();
            this.flpInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkEnableSurveyAutoSave);
            this.flowLayoutPanel1.Controls.Add(this.flpInterval);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkEnableSurveyAutoSave;
        private System.Windows.Forms.FlowLayoutPanel flpInterval;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudAutoSaveInterval;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}
