
namespace SurveyManager.forms.surveyMenu
{
    partial class RatesDialog
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
            this.txtOfficeRate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtFieldRate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnUpdateRates = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOfficeRate
            // 
            this.txtOfficeRate.Location = new System.Drawing.Point(82, 3);
            this.txtOfficeRate.Name = "txtOfficeRate";
            this.txtOfficeRate.Size = new System.Drawing.Size(88, 23);
            this.txtOfficeRate.TabIndex = 3;
            this.txtOfficeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOfficeRate_KeyPress);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Controls.Add(this.txtOfficeRate);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(242, 28);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Office Rate:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(176, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "per hour";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel2.Controls.Add(this.txtFieldRate);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 46);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(242, 28);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Field Rate: ";
            // 
            // txtFieldRate
            // 
            this.txtFieldRate.Location = new System.Drawing.Point(76, 3);
            this.txtFieldRate.Name = "txtFieldRate";
            this.txtFieldRate.Size = new System.Drawing.Size(94, 23);
            this.txtFieldRate.TabIndex = 3;
            this.txtFieldRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFieldRate_KeyPress);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(176, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "per hour";
            // 
            // btnUpdateRates
            // 
            this.btnUpdateRates.Image = global::SurveyManager.Properties.Resources.billing_rates_16x16;
            this.btnUpdateRates.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnUpdateRates.Text = "Update Rates";
            this.btnUpdateRates.UniqueName = "CB7C1F4668884D5BE7AEEE0497AF77FC";
            // 
            // RatesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnUpdateRates});
            this.ClientSize = new System.Drawing.Size(328, 87);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RatesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rates";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RatesDialog_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtOfficeRate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFieldRate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnUpdateRates;
    }
}