
namespace SurveyManager.forms.dialogs.SettingsDialog
{
    partial class CurrencySettings
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDefaultFieldRate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtFieldRate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOfficeRate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtOfficeRate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTaxRate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtTaxRate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblPercentage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(278, 132);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblDefaultFieldRate);
            this.flowLayoutPanel2.Controls.Add(this.txtFieldRate);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(256, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.Visible = false;
            this.flowLayoutPanel2.MouseEnter += new System.EventHandler(this.flowLayoutPanel2_MouseEnter);
            this.flowLayoutPanel2.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // lblDefaultFieldRate
            // 
            this.lblDefaultFieldRate.Location = new System.Drawing.Point(3, 3);
            this.lblDefaultFieldRate.Name = "lblDefaultFieldRate";
            this.lblDefaultFieldRate.Size = new System.Drawing.Size(150, 20);
            this.lblDefaultFieldRate.TabIndex = 0;
            this.lblDefaultFieldRate.Values.Image = global::SurveyManager.Properties.Resources.surveying_16x16;
            this.lblDefaultFieldRate.Values.Text = "Default Field Rate:     $";
            // 
            // txtFieldRate
            // 
            this.txtFieldRate.Location = new System.Drawing.Point(159, 3);
            this.txtFieldRate.Name = "txtFieldRate";
            this.txtFieldRate.Size = new System.Drawing.Size(85, 23);
            this.txtFieldRate.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblOfficeRate);
            this.flowLayoutPanel3.Controls.Add(this.txtOfficeRate);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 41);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(256, 32);
            this.flowLayoutPanel3.TabIndex = 1;
            this.flowLayoutPanel3.Visible = false;
            this.flowLayoutPanel3.MouseEnter += new System.EventHandler(this.flowLayoutPanel3_MouseEnter);
            this.flowLayoutPanel3.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // lblOfficeRate
            // 
            this.lblOfficeRate.Location = new System.Drawing.Point(3, 3);
            this.lblOfficeRate.Name = "lblOfficeRate";
            this.lblOfficeRate.Size = new System.Drawing.Size(150, 20);
            this.lblOfficeRate.TabIndex = 0;
            this.lblOfficeRate.Values.Image = global::SurveyManager.Properties.Resources.billing_rates_16x16;
            this.lblOfficeRate.Values.Text = "Default Office Rate:   $";
            // 
            // txtOfficeRate
            // 
            this.txtOfficeRate.Location = new System.Drawing.Point(159, 3);
            this.txtOfficeRate.Name = "txtOfficeRate";
            this.txtOfficeRate.Size = new System.Drawing.Size(85, 23);
            this.txtOfficeRate.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.lblTaxRate);
            this.flowLayoutPanel4.Controls.Add(this.txtTaxRate);
            this.flowLayoutPanel4.Controls.Add(this.lblPercentage);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 79);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(256, 32);
            this.flowLayoutPanel4.TabIndex = 2;
            this.flowLayoutPanel4.MouseEnter += new System.EventHandler(this.flowLayoutPanel4_MouseEnter);
            this.flowLayoutPanel4.MouseLeave += new System.EventHandler(this.ResetHelpText);
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.Location = new System.Drawing.Point(3, 3);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(102, 20);
            this.lblTaxRate.TabIndex = 0;
            this.lblTaxRate.Values.Text = "Default Tax Rate: ";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Location = new System.Drawing.Point(111, 3);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(63, 23);
            this.txtTaxRate.TabIndex = 1;
            this.txtTaxRate.TextChanged += new System.EventHandler(this.txtTaxRate_TextChanged);
            // 
            // lblPercentage
            // 
            this.lblPercentage.Location = new System.Drawing.Point(180, 3);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(21, 20);
            this.lblPercentage.TabIndex = 2;
            this.lblPercentage.Values.Text = "%";
            // 
            // CurrencySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CurrencySettings";
            this.Size = new System.Drawing.Size(278, 132);
            this.Load += new System.EventHandler(this.CurrencySettings_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDefaultFieldRate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFieldRate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblOfficeRate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOfficeRate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTaxRate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTaxRate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPercentage;
    }
}
