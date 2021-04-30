
namespace SurveyManager.forms.dialogs.SettingsDialog
{
    partial class FileSettings
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
            this.radCreateNewLogFile = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radOverwriteLog = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonBreadCrumbItem4 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem5 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem6 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.lblPathTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblPath = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pgLogOptions = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenLogPath = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnChangeLogPath = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.openLogFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSaveInterval = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.nudAutoSaveInterval = new System.Windows.Forms.NumericUpDown();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgLogOptions)).BeginInit();
            this.pgLogOptions.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSaveInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // radCreateNewLogFile
            // 
            this.radCreateNewLogFile.Location = new System.Drawing.Point(3, 3);
            this.radCreateNewLogFile.Name = "radCreateNewLogFile";
            this.radCreateNewLogFile.Size = new System.Drawing.Size(261, 20);
            this.radCreateNewLogFile.TabIndex = 0;
            this.radCreateNewLogFile.Values.Text = "New log file everytime application launched";
            this.radCreateNewLogFile.MouseEnter += new System.EventHandler(this.radCreateNewLogFile_MouseEnter);
            this.radCreateNewLogFile.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // radOverwriteLog
            // 
            this.radOverwriteLog.Checked = true;
            this.radOverwriteLog.Location = new System.Drawing.Point(3, 29);
            this.radOverwriteLog.Name = "radOverwriteLog";
            this.radOverwriteLog.Size = new System.Drawing.Size(161, 20);
            this.radOverwriteLog.TabIndex = 1;
            this.radOverwriteLog.Values.Text = "Overwrite existing log file";
            this.radOverwriteLog.MouseEnter += new System.EventHandler(this.radOverwriteLog_MouseEnter);
            this.radOverwriteLog.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // kryptonBreadCrumbItem4
            // 
            this.kryptonBreadCrumbItem4.ShortText = "ListItem";
            // 
            // kryptonBreadCrumbItem5
            // 
            this.kryptonBreadCrumbItem5.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem[] {
            this.kryptonBreadCrumbItem6});
            this.kryptonBreadCrumbItem5.ShortText = "C:";
            // 
            // kryptonBreadCrumbItem6
            // 
            this.kryptonBreadCrumbItem6.ShortText = "Documnets:";
            // 
            // lblPathTitle
            // 
            this.lblPathTitle.Location = new System.Drawing.Point(3, 55);
            this.lblPathTitle.Name = "lblPathTitle";
            this.lblPathTitle.Size = new System.Drawing.Size(99, 24);
            this.lblPathTitle.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathTitle.TabIndex = 2;
            this.lblPathTitle.Values.Text = "Log File Path";
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(3, 85);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(53, 19);
            this.lblPath.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.lblPath.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.TabIndex = 3;
            this.lblPath.Values.Text = "<PATH>";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SlantEqualBoth;
            this.kryptonNavigator1.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.OneNote;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pgLogOptions,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(574, 403);
            this.kryptonNavigator1.TabIndex = 2;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // pgLogOptions
            // 
            this.pgLogOptions.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pgLogOptions.Controls.Add(this.flowLayoutPanel2);
            this.pgLogOptions.Flags = 65534;
            this.pgLogOptions.LastVisibleSet = true;
            this.pgLogOptions.MinimumSize = new System.Drawing.Size(50, 50);
            this.pgLogOptions.Name = "pgLogOptions";
            this.pgLogOptions.Size = new System.Drawing.Size(572, 377);
            this.pgLogOptions.Text = "Logging";
            this.pgLogOptions.ToolTipTitle = "Page ToolTip";
            this.pgLogOptions.UniqueName = "864D732DCCFA4C0B36BC57FD4E5D2AF9";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Controls.Add(this.radCreateNewLogFile);
            this.flowLayoutPanel2.Controls.Add(this.radOverwriteLog);
            this.flowLayoutPanel2.Controls.Add(this.lblPathTitle);
            this.flowLayoutPanel2.Controls.Add(this.lblPath);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(572, 377);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnOpenLogPath);
            this.flowLayoutPanel1.Controls.Add(this.btnChangeLogPath);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 110);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(307, 31);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnOpenLogPath
            // 
            this.btnOpenLogPath.Location = new System.Drawing.Point(172, 3);
            this.btnOpenLogPath.Name = "btnOpenLogPath";
            this.btnOpenLogPath.Size = new System.Drawing.Size(132, 25);
            this.btnOpenLogPath.TabIndex = 4;
            this.btnOpenLogPath.Values.Image = global::SurveyManager.Properties.Resources.txt_16x16;
            this.btnOpenLogPath.Values.Text = "Open Log File";
            this.btnOpenLogPath.Click += new System.EventHandler(this.btnOpenLogPath_Click);
            // 
            // btnChangeLogPath
            // 
            this.btnChangeLogPath.Location = new System.Drawing.Point(7, 3);
            this.btnChangeLogPath.Name = "btnChangeLogPath";
            this.btnChangeLogPath.Size = new System.Drawing.Size(159, 25);
            this.btnChangeLogPath.TabIndex = 4;
            this.btnChangeLogPath.Values.Image = global::SurveyManager.Properties.Resources.folder_16x16;
            this.btnChangeLogPath.Values.Text = "Change Logging Path";
            this.btnChangeLogPath.Click += new System.EventHandler(this.btnChangeLogPath_Click);
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(100, 100);
            this.kryptonPage2.Text = "kryptonPage2";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "67F25DADF07F44F1DD92922206205DC9";
            // 
            // lblSaveInterval
            // 
            this.lblSaveInterval.Location = new System.Drawing.Point(3, 3);
            this.lblSaveInterval.Name = "lblSaveInterval";
            this.lblSaveInterval.Size = new System.Drawing.Size(107, 20);
            this.lblSaveInterval.TabIndex = 6;
            this.lblSaveInterval.Values.Text = "Autosave Interval: ";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel3.Controls.Add(this.lblSaveInterval);
            this.flowLayoutPanel3.Controls.Add(this.nudAutoSaveInterval);
            this.flowLayoutPanel3.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 147);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(307, 31);
            this.flowLayoutPanel3.TabIndex = 7;
            this.flowLayoutPanel3.MouseEnter += new System.EventHandler(this.flowLayoutPanel3_MouseEnter);
            this.flowLayoutPanel3.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // nudAutoSaveInterval
            // 
            this.nudAutoSaveInterval.Location = new System.Drawing.Point(116, 3);
            this.nudAutoSaveInterval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudAutoSaveInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAutoSaveInterval.Name = "nudAutoSaveInterval";
            this.nudAutoSaveInterval.Size = new System.Drawing.Size(50, 20);
            this.nudAutoSaveInterval.TabIndex = 7;
            this.nudAutoSaveInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(172, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "minutes";
            // 
            // FileSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonNavigator1);
            this.Name = "FileSettings";
            this.Size = new System.Drawing.Size(574, 403);
            this.Load += new System.EventHandler(this.FileSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgLogOptions)).EndInit();
            this.pgLogOptions.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSaveInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radCreateNewLogFile;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radOverwriteLog;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem5;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem6;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPathTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPath;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage pgLogOptions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOpenLogPath;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnChangeLogPath;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FolderBrowserDialog openLogFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSaveInterval;
        private System.Windows.Forms.NumericUpDown nudAutoSaveInterval;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
