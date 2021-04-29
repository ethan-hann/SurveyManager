
namespace SurveyManager.forms.dialogs
{
    partial class ActivationDlg
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
            this.btnPurchase = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnActivate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtProductKey = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblActivationStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpInfoBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.infoPropGrid = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfoBox.Panel)).BeginInit();
            this.grpInfoBox.Panel.SuspendLayout();
            this.grpInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(6, 71);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(168, 25);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Values.Text = "Purchase New Product Key";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "License.lic";
            this.dlgOpenFile.Filter = "License File|*.lic";
            this.dlgOpenFile.ReadOnlyChecked = true;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(361, 71);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(105, 25);
            this.btnActivate.TabIndex = 13;
            this.btnActivate.Values.Text = "Activate";
            this.btnActivate.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(184, 24);
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 14;
            this.kryptonLabel1.Values.Text = "Enter your Product Key:";
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(6, 42);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(460, 20);
            this.txtProductKey.StateCommon.Content.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductKey.StateNormal.Content.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductKey.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblActivationStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(472, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 16;
            // 
            // lblActivationStatus
            // 
            this.lblActivationStatus.Name = "lblActivationStatus";
            this.lblActivationStatus.Size = new System.Drawing.Size(77, 17);
            this.lblActivationStatus.Text = "Status: Ready";
            // 
            // grpInfoBox
            // 
            this.grpInfoBox.Location = new System.Drawing.Point(6, 103);
            this.grpInfoBox.Name = "grpInfoBox";
            // 
            // grpInfoBox.Panel
            // 
            this.grpInfoBox.Panel.Controls.Add(this.infoPropGrid);
            this.grpInfoBox.Size = new System.Drawing.Size(460, 200);
            this.grpInfoBox.TabIndex = 17;
            this.grpInfoBox.Values.Heading = "Key Information";
            // 
            // infoPropGrid
            // 
            this.infoPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPropGrid.HelpVisible = false;
            this.infoPropGrid.Location = new System.Drawing.Point(0, 0);
            this.infoPropGrid.Name = "infoPropGrid";
            this.infoPropGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.infoPropGrid.Size = new System.Drawing.Size(456, 176);
            this.infoPropGrid.TabIndex = 0;
            this.infoPropGrid.ToolbarVisible = false;
            // 
            // ActivationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 331);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtProductKey);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.grpInfoBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivationDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey Manager Activation";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActivationDlg_FormClosing);
            this.Load += new System.EventHandler(this.Activation_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfoBox.Panel)).EndInit();
            this.grpInfoBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpInfoBox)).EndInit();
            this.grpInfoBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPurchase;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnActivate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProductKey;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblActivationStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpInfoBox;
        private System.Windows.Forms.PropertyGrid infoPropGrid;
    }
}