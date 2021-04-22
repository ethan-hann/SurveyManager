
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAddTime = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnRemoveTime = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.hoursUp = new System.Windows.Forms.PictureBox();
            this.lblHours = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.hoursDown = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hoursGroup = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.minutesGroup = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.minutesUp = new System.Windows.Forms.PictureBox();
            this.lblMinutes = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.minutesDown = new System.Windows.Forms.PictureBox();
            this.secondsGroup = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.secondsUp = new System.Windows.Forms.PictureBox();
            this.lblSeconds = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.secondsDown = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtHours = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtMinutes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtSeconds = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursGroup.Panel)).BeginInit();
            this.hoursGroup.Panel.SuspendLayout();
            this.hoursGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minutesGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesGroup.Panel)).BeginInit();
            this.minutesGroup.Panel.SuspendLayout();
            this.minutesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minutesUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsGroup.Panel)).BeginInit();
            this.secondsGroup.Panel.SuspendLayout();
            this.secondsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsDown)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTotalTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 194);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(318, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(165, 17);
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
            // hoursUp
            // 
            this.hoursUp.Image = global::SurveyManager.Properties.Resources.up_arrow_32x32;
            this.hoursUp.Location = new System.Drawing.Point(3, 8);
            this.hoursUp.Name = "hoursUp";
            this.hoursUp.Size = new System.Drawing.Size(32, 32);
            this.hoursUp.TabIndex = 2;
            this.hoursUp.TabStop = false;
            this.hoursUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hoursUp_MouseClick);
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(3, 46);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(33, 45);
            this.lblHours.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.TabIndex = 4;
            this.lblHours.Values.Text = "0";
            this.lblHours.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblHours_MouseClick);
            // 
            // hoursDown
            // 
            this.hoursDown.Image = global::SurveyManager.Properties.Resources.down_arrow_32x32;
            this.hoursDown.Location = new System.Drawing.Point(3, 97);
            this.hoursDown.Name = "hoursDown";
            this.hoursDown.Size = new System.Drawing.Size(32, 32);
            this.hoursDown.TabIndex = 5;
            this.hoursDown.TabStop = false;
            this.hoursDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hoursDown_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.minutesGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondsGroup, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.hoursGroup, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 142);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // hoursGroup
            // 
            this.hoursGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursGroup.Location = new System.Drawing.Point(3, 3);
            this.hoursGroup.Name = "hoursGroup";
            // 
            // hoursGroup.Panel
            // 
            this.hoursGroup.Panel.Controls.Add(this.txtHours);
            this.hoursGroup.Panel.Controls.Add(this.hoursUp);
            this.hoursGroup.Panel.Controls.Add(this.lblHours);
            this.hoursGroup.Panel.Controls.Add(this.hoursDown);
            this.hoursGroup.Size = new System.Drawing.Size(90, 136);
            this.hoursGroup.TabIndex = 13;
            // 
            // minutesGroup
            // 
            this.minutesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minutesGroup.Location = new System.Drawing.Point(99, 3);
            this.minutesGroup.Name = "minutesGroup";
            // 
            // minutesGroup.Panel
            // 
            this.minutesGroup.Panel.Controls.Add(this.txtMinutes);
            this.minutesGroup.Panel.Controls.Add(this.minutesUp);
            this.minutesGroup.Panel.Controls.Add(this.lblMinutes);
            this.minutesGroup.Panel.Controls.Add(this.minutesDown);
            this.minutesGroup.Size = new System.Drawing.Size(90, 136);
            this.minutesGroup.TabIndex = 14;
            // 
            // minutesUp
            // 
            this.minutesUp.Image = global::SurveyManager.Properties.Resources.up_arrow_32x32;
            this.minutesUp.Location = new System.Drawing.Point(3, 8);
            this.minutesUp.Name = "minutesUp";
            this.minutesUp.Size = new System.Drawing.Size(32, 32);
            this.minutesUp.TabIndex = 2;
            this.minutesUp.TabStop = false;
            this.minutesUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.minutesUp_MouseClick);
            // 
            // lblMinutes
            // 
            this.lblMinutes.Location = new System.Drawing.Point(3, 46);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(33, 45);
            this.lblMinutes.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Values.Text = "0";
            this.lblMinutes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMinutes_MouseClick);
            // 
            // minutesDown
            // 
            this.minutesDown.Image = global::SurveyManager.Properties.Resources.down_arrow_32x32;
            this.minutesDown.Location = new System.Drawing.Point(3, 97);
            this.minutesDown.Name = "minutesDown";
            this.minutesDown.Size = new System.Drawing.Size(32, 32);
            this.minutesDown.TabIndex = 5;
            this.minutesDown.TabStop = false;
            this.minutesDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.minutesDown_MouseClick);
            // 
            // secondsGroup
            // 
            this.secondsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondsGroup.Location = new System.Drawing.Point(195, 3);
            this.secondsGroup.Name = "secondsGroup";
            // 
            // secondsGroup.Panel
            // 
            this.secondsGroup.Panel.Controls.Add(this.txtSeconds);
            this.secondsGroup.Panel.Controls.Add(this.secondsUp);
            this.secondsGroup.Panel.Controls.Add(this.lblSeconds);
            this.secondsGroup.Panel.Controls.Add(this.secondsDown);
            this.secondsGroup.Size = new System.Drawing.Size(93, 136);
            this.secondsGroup.TabIndex = 15;
            // 
            // secondsUp
            // 
            this.secondsUp.Image = global::SurveyManager.Properties.Resources.up_arrow_32x32;
            this.secondsUp.Location = new System.Drawing.Point(3, 8);
            this.secondsUp.Name = "secondsUp";
            this.secondsUp.Size = new System.Drawing.Size(32, 32);
            this.secondsUp.TabIndex = 2;
            this.secondsUp.TabStop = false;
            this.secondsUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.secondsUp_MouseClick);
            // 
            // lblSeconds
            // 
            this.lblSeconds.Location = new System.Drawing.Point(3, 46);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(33, 45);
            this.lblSeconds.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.TabIndex = 4;
            this.lblSeconds.Values.Text = "0";
            this.lblSeconds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblSeconds_MouseClick);
            // 
            // secondsDown
            // 
            this.secondsDown.Image = global::SurveyManager.Properties.Resources.down_arrow_32x32;
            this.secondsDown.Location = new System.Drawing.Point(3, 97);
            this.secondsDown.Name = "secondsDown";
            this.secondsDown.Size = new System.Drawing.Size(32, 32);
            this.secondsDown.TabIndex = 5;
            this.secondsDown.TabStop = false;
            this.secondsDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.secondsDown_MouseClick);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 160);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(76, 30);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 13;
            this.kryptonLabel1.Values.Text = "Hour(s)";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(106, 160);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(94, 30);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 14;
            this.kryptonLabel2.Values.Text = "Minute(s)";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(206, 160);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(97, 30);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 15;
            this.kryptonLabel5.Values.Text = "Second(s)";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(3, 46);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(82, 47);
            this.txtHours.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHours.TabIndex = 6;
            this.txtHours.Text = "0";
            this.txtHours.Visible = false;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHours_KeyPress);
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(3, 46);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(82, 47);
            this.txtMinutes.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.TabIndex = 7;
            this.txtMinutes.Text = "0";
            this.txtMinutes.Visible = false;
            this.txtMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutes_KeyPress);
            // 
            // txtSeconds
            // 
            this.txtSeconds.Location = new System.Drawing.Point(3, 46);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(82, 47);
            this.txtSeconds.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeconds.TabIndex = 8;
            this.txtSeconds.Text = "0";
            this.txtSeconds.Visible = false;
            this.txtSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeconds_KeyPress);
            // 
            // TimeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddTime,
            this.btnRemoveTime});
            this.ClientSize = new System.Drawing.Size(318, 216);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TimeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Time Entry";
            this.Load += new System.EventHandler(this.TimeEntry_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hoursGroup.Panel)).EndInit();
            this.hoursGroup.Panel.ResumeLayout(false);
            this.hoursGroup.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursGroup)).EndInit();
            this.hoursGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minutesGroup.Panel)).EndInit();
            this.minutesGroup.Panel.ResumeLayout(false);
            this.minutesGroup.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minutesGroup)).EndInit();
            this.minutesGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minutesUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsGroup.Panel)).EndInit();
            this.secondsGroup.Panel.ResumeLayout(false);
            this.secondsGroup.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsGroup)).EndInit();
            this.secondsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondsUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalTime;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddTime;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnRemoveTime;
        private System.Windows.Forms.PictureBox hoursUp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblHours;
        private System.Windows.Forms.PictureBox hoursDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup minutesGroup;
        private System.Windows.Forms.PictureBox minutesUp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMinutes;
        private System.Windows.Forms.PictureBox minutesDown;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup secondsGroup;
        private System.Windows.Forms.PictureBox secondsUp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSeconds;
        private System.Windows.Forms.PictureBox secondsDown;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup hoursGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMinutes;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSeconds;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtHours;
    }
}