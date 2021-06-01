
namespace SurveyManager.forms.databaseMenu
{
    partial class DBConnection
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUsername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPort = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblServer = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtServer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDB = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPassword = new ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox();
            this.btnTestConnection = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnFinish = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.txtStatus = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.94444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.05556F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblServer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 75);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(77, 30);
            this.kryptonLabel4.TabIndex = 9;
            this.kryptonLabel4.TabStop = false;
            this.kryptonLabel4.Values.Text = "Database:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 111);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(77, 30);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.TabStop = false;
            this.kryptonLabel2.Values.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(86, 114);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(293, 23);
            this.txtUsername.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 39);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(77, 30);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.TabStop = false;
            this.kryptonLabel1.Values.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(86, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(293, 23);
            this.txtPort.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServer.Location = new System.Drawing.Point(3, 3);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(77, 30);
            this.lblServer.TabIndex = 0;
            this.lblServer.TabStop = false;
            this.lblServer.Values.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(86, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(293, 23);
            this.txtServer.TabIndex = 0;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 147);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(77, 32);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.TabStop = false;
            this.kryptonLabel3.Values.Text = "Password:";
            // 
            // txtDB
            // 
            this.txtDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB.Location = new System.Drawing.Point(86, 78);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(293, 23);
            this.txtDB.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(86, 151);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(293, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Image = global::SurveyManager.Properties.Resources.computer_16x16;
            this.btnTestConnection.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.ToolTipBody = "Try a connection to the database specified by the supplied parameters.";
            this.btnTestConnection.ToolTipTitle = "Test";
            this.btnTestConnection.UniqueName = "8F29BBE0CDF94F1D878168FAA0846762";
            // 
            // btnFinish
            // 
            this.btnFinish.Image = global::SurveyManager.Properties.Resources.success_16x16;
            this.btnFinish.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnFinish.Text = "Finished";
            this.btnFinish.UniqueName = "677A0C82441D446872B53744E2EDC22C";
            this.btnFinish.Visible = false;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLoad.Location = new System.Drawing.Point(195, 7);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(184, 19);
            this.progressBarLoad.TabIndex = 1;
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 2;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.52356F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.47644F));
            this.tlpStatus.Controls.Add(this.txtStatus, 0, 0);
            this.tlpStatus.Controls.Add(this.progressBarLoad, 1, 0);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpStatus.Location = new System.Drawing.Point(0, 182);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 1;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Size = new System.Drawing.Size(382, 34);
            this.tlpStatus.TabIndex = 2;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(3, 7);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(186, 20);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.Values.Text = "<Status>";
            // 
            // DBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnTestConnection,
            this.btnFinish});
            this.ClientSize = new System.Drawing.Size(382, 216);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(398, 255);
            this.Name = "DBConnection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Connection";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DBConnection_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpStatus.ResumeLayout(false);
            this.tlpStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUsername;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPort;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblServer;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtServer;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDB;
        private ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox txtPassword;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnTestConnection;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnFinish;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBarLoad;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtStatus;
    }
}