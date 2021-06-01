
namespace SurveyManager.forms.surveyMenu.subdivisionInfo
{
    partial class SubdivisionCtl
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
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLot = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtBlock = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSection = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.TabStop = false;
            this.kryptonLabel1.Values.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(367, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtName.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Controls.Add(this.txtName);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(432, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(30, 20);
            this.kryptonLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.TabStop = false;
            this.kryptonLabel2.Values.Text = "Lot:";
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(39, 3);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(160, 23);
            this.txtLot.TabIndex = 0;
            this.txtLot.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtLot.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel2.Controls.Add(this.txtLot);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 71);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(315, 29);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel3.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.TabStop = false;
            this.kryptonLabel3.Values.Text = "Block";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(49, 3);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(150, 23);
            this.txtBlock.TabIndex = 0;
            this.txtBlock.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtBlock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtBlock.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel3.Controls.Add(this.txtBlock);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 37);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel4.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.TabStop = false;
            this.kryptonLabel4.Values.Text = "Section:";
            // 
            // txtSection
            // 
            this.txtSection.Location = new System.Drawing.Point(62, 3);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(137, 23);
            this.txtSection.TabIndex = 0;
            this.txtSection.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtSection.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.kryptonLabel4);
            this.flowLayoutPanel4.Controls.Add(this.txtSection);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 106);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // SubdivisionCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Name = "SubdivisionCtl";
            this.Size = new System.Drawing.Size(471, 147);
            this.Load += new System.EventHandler(this.SubdivisionCtl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLot;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBlock;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    }
}
