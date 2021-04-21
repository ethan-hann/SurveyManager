
namespace SurveyManager.forms.surveyMenu
{
    partial class TimeEntry
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
            this.dtpTimeEntry = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAddTime = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnRemoveTime = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpTimeEntry
            // 
            this.dtpTimeEntry.CustomFormat = "HH:mm:ss";
            this.dtpTimeEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEntry.Location = new System.Drawing.Point(108, 12);
            this.dtpTimeEntry.Name = "dtpTimeEntry";
            this.dtpTimeEntry.ShowUpDown = true;
            this.dtpTimeEntry.Size = new System.Drawing.Size(111, 27);
            this.dtpTimeEntry.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeEntry.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTotalTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 107);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(348, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(647, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(138, 17);
            this.lblTotalTime.Text = "Total Time Spent on Job: ";
            // 
            // btnAddTime
            // 
            this.btnAddTime.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddTime.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnAddTime.Text = "Add Time";
            this.btnAddTime.UniqueName = "C041BADA86C847644BBC4F72D93E0EE7";
            // 
            // btnRemoveTime
            // 
            this.btnRemoveTime.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveTime.Text = "Remove Time";
            this.btnRemoveTime.UniqueName = "37DA50E36D6045C7A38EFF40BFEC0825";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(12, 42);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(256, 60);
            this.kryptonWrapLabel1.Text = "Format -> HH:mm:ss (Hours:Minutes:Seconds)\r\n\r\nYou can add or remove the specified" +
    " amount \r\nof time from this job.";
            // 
            // TimeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddTime,
            this.btnRemoveTime});
            this.ClientSize = new System.Drawing.Size(348, 129);
            this.Controls.Add(this.kryptonWrapLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtpTimeEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TimeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Time Entry";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpTimeEntry;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalTime;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddTime;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnRemoveTime;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
    }
}