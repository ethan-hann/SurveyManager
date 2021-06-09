
namespace SurveyManager.forms.surveyMenu.basicInfo
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
            this.descHeaderGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtDescription = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDescCharCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descHeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descHeaderGroup.Panel)).BeginInit();
            this.descHeaderGroup.Panel.SuspendLayout();
            this.descHeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 35);
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
            this.txtSurvey.Size = new System.Drawing.Size(230, 23);
            this.txtSurvey.TabIndex = 1;
            this.txtSurvey.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtSurvey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtSurvey.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel3.Controls.Add(this.txtSurvey);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 69);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(315, 28);
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
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 103);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(315, 32);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // descHeaderGroup
            // 
            this.descHeaderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descHeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.descHeaderGroup.Name = "descHeaderGroup";
            // 
            // descHeaderGroup.Panel
            // 
            this.descHeaderGroup.Panel.Controls.Add(this.kryptonPanel2);
            this.descHeaderGroup.Size = new System.Drawing.Size(759, 316);
            this.descHeaderGroup.StateCommon.HeaderPrimary.Content.LongText.Color2 = System.Drawing.Color.Red;
            this.descHeaderGroup.TabIndex = 1;
            this.descHeaderGroup.ValuesPrimary.Heading = "Description *";
            this.descHeaderGroup.ValuesPrimary.Image = null;
            this.descHeaderGroup.ValuesSecondary.Heading = "Enter the description for this survey job.";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.descHeaderGroup);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 285);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(759, 316);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.txtDescription);
            this.kryptonPanel2.Controls.Add(this.statusStrip1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(757, 263);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.MaxLength = 6000;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(757, 241);
            this.txtDescription.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblDescCharCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 241);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(757, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(627, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblDescCharCount
            // 
            this.lblDescCharCount.Name = "lblDescCharCount";
            this.lblDescCharCount.Size = new System.Drawing.Size(115, 17);
            this.lblDescCharCount.Text = "Char Count: 0 / 6000";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.flowLayoutPanel4);
            this.kryptonPanel3.Controls.Add(this.flowLayoutPanel3);
            this.kryptonPanel3.Controls.Add(this.flowLayoutPanel2);
            this.kryptonPanel3.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(759, 285);
            this.kryptonPanel3.TabIndex = 3;
            // 
            // EssentialInformationCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "EssentialInformationCtl";
            this.Size = new System.Drawing.Size(759, 601);
            this.Load += new System.EventHandler(this.EssentialInformationCtl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descHeaderGroup.Panel)).EndInit();
            this.descHeaderGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descHeaderGroup)).EndInit();
            this.descHeaderGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
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
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup descHeaderGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtDescription;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblDescCharCount;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
    }
}
