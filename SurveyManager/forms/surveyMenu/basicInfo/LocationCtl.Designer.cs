
namespace SurveyManager.forms.surveyMenu.basicInfo
{
    partial class LocationCtl
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
            this.txtStreet = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCity = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtZipCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbCounty = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSameAsClient = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCounty)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Street:";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(54, 3);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(248, 23);
            this.txtStreet.TabIndex = 1;
            this.txtStreet.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtStreet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtStreet.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Controls.Add(this.txtStreet);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(34, 20);
            this.kryptonLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "City:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(43, 3);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(107, 23);
            this.txtCity.TabIndex = 1;
            this.txtCity.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JobModified);
            this.txtCity.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel2.Controls.Add(this.txtCity);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 68);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel3.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "Zip Code:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(72, 3);
            this.txtZipCode.MaxLength = 10;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(78, 23);
            this.txtZipCode.TabIndex = 1;
            this.txtZipCode.Enter += new System.EventHandler(this.textBox_Enter);
            this.txtZipCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZipCode_KeyPress);
            this.txtZipCode.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel3.Controls.Add(this.txtZipCode);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 102);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(315, 28);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel4.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "County:";
            // 
            // cmbCounty
            // 
            this.cmbCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounty.DropDownWidth = 131;
            this.cmbCounty.Location = new System.Drawing.Point(61, 3);
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(131, 21);
            this.cmbCounty.TabIndex = 1;
            this.cmbCounty.DropDownClosed += new System.EventHandler(this.cmbCounty_DropDownClosed);
            this.cmbCounty.SelectedIndexChanged += new System.EventHandler(this.cmbCounty_SelectedIndexChanged);
            this.cmbCounty.Enter += new System.EventHandler(this.textBox_Enter);
            this.cmbCounty.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.kryptonLabel4);
            this.flowLayoutPanel4.Controls.Add(this.cmbCounty);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 136);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(315, 29);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // btnSameAsClient
            // 
            this.btnSameAsClient.Location = new System.Drawing.Point(3, 3);
            this.btnSameAsClient.Name = "btnSameAsClient";
            this.btnSameAsClient.Size = new System.Drawing.Size(168, 25);
            this.btnSameAsClient.TabIndex = 4;
            this.btnSameAsClient.Values.Text = "Set to Client\'s Address";
            this.btnSameAsClient.Click += new System.EventHandler(this.btnSameAsClient_Click);
            // 
            // LocationCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSameAsClient);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Name = "LocationCtl";
            this.Size = new System.Drawing.Size(330, 180);
            this.Load += new System.EventHandler(this.LocationCtl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCounty)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtStreet;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtZipCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbCounty;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSameAsClient;
    }
}
