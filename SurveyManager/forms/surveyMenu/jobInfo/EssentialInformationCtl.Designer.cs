
namespace SurveyManager.forms.surveyMenu.jobInfo
{
    partial class EssentialInformationCtl
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtJobNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAbstract = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSurvey = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNumOfAcres = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.ExtraText = "*";
            this.kryptonLabel1.Values.Text = "Job Number:";
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(100, 3);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(92, 23);
            this.txtJobNumber.TabIndex = 1;
            this.txtJobNumber.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtJobNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtJobNumber.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Controls.Add(this.txtJobNumber);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.ExtraText = "*";
            this.kryptonLabel2.Values.Text = "Abstract:";
            // 
            // txtAbstract
            // 
            this.txtAbstract.Location = new System.Drawing.Point(78, 3);
            this.txtAbstract.Name = "txtAbstract";
            this.txtAbstract.Size = new System.Drawing.Size(76, 23);
            this.txtAbstract.TabIndex = 1;
            this.txtAbstract.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtAbstract.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtAbstract.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel2.Controls.Add(this.txtAbstract);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 37);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel3.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.ExtraText = "*";
            this.kryptonLabel3.Values.Text = "Survey:";
            // 
            // txtSurvey
            // 
            this.txtSurvey.Location = new System.Drawing.Point(69, 3);
            this.txtSurvey.Name = "txtSurvey";
            this.txtSurvey.Size = new System.Drawing.Size(246, 23);
            this.txtSurvey.TabIndex = 1;
            this.txtSurvey.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtSurvey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtSurvey.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel3.Controls.Add(this.txtSurvey);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 71);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(318, 28);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(79, 20);
            this.kryptonLabel4.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.ExtraText = "*";
            this.kryptonLabel4.Values.Text = "# of Acres:";
            // 
            // txtNumOfAcres
            // 
            this.txtNumOfAcres.Location = new System.Drawing.Point(88, 3);
            this.txtNumOfAcres.Name = "txtNumOfAcres";
            this.txtNumOfAcres.Size = new System.Drawing.Size(104, 23);
            this.txtNumOfAcres.TabIndex = 1;
            this.txtNumOfAcres.TextChanged += new System.EventHandler(this.txtNumOfAcres_TextChanged);
            this.txtNumOfAcres.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtNumOfAcres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumOfAcres_KeyPress);
            this.txtNumOfAcres.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.kryptonLabel4);
            this.flowLayoutPanel4.Controls.Add(this.txtNumOfAcres);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 105);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(321, 133);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // EssentialInformationCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel5);
            this.Name = "EssentialInformationCtl";
            this.Size = new System.Drawing.Size(331, 146);
            this.Load += new System.EventHandler(this.EssentialInformationCtl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtJobNumber;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAbstract;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSurvey;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNumOfAcres;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    }
}
