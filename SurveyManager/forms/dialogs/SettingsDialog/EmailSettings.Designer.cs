
namespace SurveyManager.forms.dialogs.SettingsDialog
{
    partial class EmailSettings
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
            this.kryptonWrapLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSMTPUsername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSMTPPassword = new ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox();
            this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSMTPServer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSMTPPort = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtFromAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel13.SuspendLayout();
            this.flowLayoutPanel12.SuspendLayout();
            this.flowLayoutPanel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.kryptonWrapLabel8);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel13);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel12);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel14);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(325, 232);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // kryptonWrapLabel8
            // 
            this.kryptonWrapLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel8.Location = new System.Drawing.Point(3, 0);
            this.kryptonWrapLabel8.Name = "kryptonWrapLabel8";
            this.kryptonWrapLabel8.Size = new System.Drawing.Size(0, 15);
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel10.Controls.Add(this.txtSMTPUsername);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(314, 36);
            this.flowLayoutPanel10.TabIndex = 1;
            this.flowLayoutPanel10.MouseEnter += new System.EventHandler(this.flowLayoutPanel10_MouseEnter);
            this.flowLayoutPanel10.MouseLeave += new System.EventHandler(this.flowLayoutPanel10_MouseLeave);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.TabStop = false;
            this.kryptonLabel3.Values.Text = "SMTP Username: ";
            // 
            // txtSMTPUsername
            // 
            this.txtSMTPUsername.Location = new System.Drawing.Point(112, 3);
            this.txtSMTPUsername.Name = "txtSMTPUsername";
            this.txtSMTPUsername.Size = new System.Drawing.Size(188, 23);
            this.txtSMTPUsername.TabIndex = 0;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.kryptonLabel6);
            this.flowLayoutPanel11.Controls.Add(this.txtSMTPPassword);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(3, 60);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(314, 36);
            this.flowLayoutPanel11.TabIndex = 2;
            this.flowLayoutPanel11.MouseEnter += new System.EventHandler(this.flowLayoutPanel11_MouseEnter);
            this.flowLayoutPanel11.MouseLeave += new System.EventHandler(this.flowLayoutPanel11_MouseLeave);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(99, 20);
            this.kryptonLabel6.TabIndex = 0;
            this.kryptonLabel6.TabStop = false;
            this.kryptonLabel6.Values.Text = "SMTP Password: ";
            // 
            // txtSMTPPassword
            // 
            this.txtSMTPPassword.Location = new System.Drawing.Point(108, 3);
            this.txtSMTPPassword.Name = "txtSMTPPassword";
            this.txtSMTPPassword.PasswordChar = '●';
            this.txtSMTPPassword.Size = new System.Drawing.Size(192, 23);
            this.txtSMTPPassword.TabIndex = 0;
            this.txtSMTPPassword.UseSystemPasswordChar = true;
            // 
            // flowLayoutPanel13
            // 
            this.flowLayoutPanel13.Controls.Add(this.kryptonLabel9);
            this.flowLayoutPanel13.Controls.Add(this.txtSMTPServer);
            this.flowLayoutPanel13.Location = new System.Drawing.Point(3, 102);
            this.flowLayoutPanel13.Name = "flowLayoutPanel13";
            this.flowLayoutPanel13.Size = new System.Drawing.Size(314, 36);
            this.flowLayoutPanel13.TabIndex = 3;
            this.flowLayoutPanel13.MouseEnter += new System.EventHandler(this.flowLayoutPanel13_MouseEnter);
            this.flowLayoutPanel13.MouseLeave += new System.EventHandler(this.flowLayoutPanel13_MouseLeave);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(129, 20);
            this.kryptonLabel9.TabIndex = 0;
            this.kryptonLabel9.TabStop = false;
            this.kryptonLabel9.Values.Text = "SMTP Server Address: ";
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Location = new System.Drawing.Point(138, 3);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(162, 23);
            this.txtSMTPServer.TabIndex = 0;
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.Controls.Add(this.kryptonLabel7);
            this.flowLayoutPanel12.Controls.Add(this.txtSMTPPort);
            this.flowLayoutPanel12.Location = new System.Drawing.Point(3, 144);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(314, 36);
            this.flowLayoutPanel12.TabIndex = 4;
            this.flowLayoutPanel12.MouseEnter += new System.EventHandler(this.flowLayoutPanel12_MouseEnter);
            this.flowLayoutPanel12.MouseLeave += new System.EventHandler(this.flowLayoutPanel12_MouseLeave);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel7.TabIndex = 0;
            this.kryptonLabel7.TabStop = false;
            this.kryptonLabel7.Values.Text = "SMTP Port:";
            // 
            // txtSMTPPort
            // 
            this.txtSMTPPort.Location = new System.Drawing.Point(79, 3);
            this.txtSMTPPort.Name = "txtSMTPPort";
            this.txtSMTPPort.Size = new System.Drawing.Size(60, 23);
            this.txtSMTPPort.TabIndex = 0;
            // 
            // flowLayoutPanel14
            // 
            this.flowLayoutPanel14.Controls.Add(this.kryptonLabel11);
            this.flowLayoutPanel14.Controls.Add(this.txtFromAddress);
            this.flowLayoutPanel14.Location = new System.Drawing.Point(3, 186);
            this.flowLayoutPanel14.Name = "flowLayoutPanel14";
            this.flowLayoutPanel14.Size = new System.Drawing.Size(314, 33);
            this.flowLayoutPanel14.TabIndex = 5;
            this.flowLayoutPanel14.MouseEnter += new System.EventHandler(this.flowLayoutPanel14_MouseEnter);
            this.flowLayoutPanel14.MouseLeave += new System.EventHandler(this.flowLayoutPanel14_MouseLeave);
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel11.TabIndex = 0;
            this.kryptonLabel11.TabStop = false;
            this.kryptonLabel11.Values.Text = "From Address:";
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.Location = new System.Drawing.Point(98, 3);
            this.txtFromAddress.Name = "txtFromAddress";
            this.txtFromAddress.Size = new System.Drawing.Size(202, 23);
            this.txtFromAddress.TabIndex = 0;
            // 
            // EmailSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmailSettings";
            this.Size = new System.Drawing.Size(325, 232);
            this.Load += new System.EventHandler(this.EmailSettings_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.flowLayoutPanel13.ResumeLayout(false);
            this.flowLayoutPanel13.PerformLayout();
            this.flowLayoutPanel12.ResumeLayout(false);
            this.flowLayoutPanel12.PerformLayout();
            this.flowLayoutPanel14.ResumeLayout(false);
            this.flowLayoutPanel14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSMTPUsername;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox txtSMTPPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel13;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSMTPServer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel12;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSMTPPort;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFromAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel8;
    }
}
