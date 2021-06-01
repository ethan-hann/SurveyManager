
namespace SurveyManager.forms.surveyMenu
{
    partial class UploadFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadFile));
            this.lbFileNames = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveSelected = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddFile = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.picPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tblProgress = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelLoading = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPreview = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFileSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).BeginInit();
            this.picPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.tblProgress.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFileNames
            // 
            this.lbFileNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFileNames.Location = new System.Drawing.Point(0, 0);
            this.lbFileNames.Name = "lbFileNames";
            this.lbFileNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFileNames.Size = new System.Drawing.Size(300, 408);
            this.lbFileNames.TabIndex = 0;
            this.lbFileNames.SelectedIndexChanged += new System.EventHandler(this.lbFileNames_SelectedIndexChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lbFileNames);
            this.kryptonPanel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(300, 448);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveSelected);
            this.flowLayoutPanel1.Controls.Add(this.btnAddFile);
            this.flowLayoutPanel1.Controls.Add(this.picPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 408);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 40);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(173, 3);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(124, 32);
            this.btnRemoveSelected.TabIndex = 0;
            this.btnRemoveSelected.Values.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveSelected.Values.Text = "Remove Selected";
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(43, 3);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(124, 32);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddFile.Values.Text = "Add File(s)...";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // picPanel
            // 
            this.picPanel.Controls.Add(this.picBox);
            this.picPanel.Location = new System.Drawing.Point(5, 3);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(32, 32);
            this.picPanel.TabIndex = 2;
            this.picPanel.Visible = false;
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.White;
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(32, 32);
            this.picBox.TabIndex = 5;
            this.picBox.TabStop = false;
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Location = new System.Drawing.Point(0, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(540, 448);
            this.propGrid.TabIndex = 2;
            this.propGrid.ToolbarVisible = false;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SurveyManager.Properties.Resources.success_16x16;
            this.btnSave.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnSave.Text = "Save and Close";
            this.btnSave.ToolTipBody = "Saves the files and closes this dialog.";
            this.btnSave.ToolTipTitle = "Save";
            this.btnSave.UniqueName = "11B6C9518DC647896F9EB159CBE849FD";
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = resources.GetString("fileDialog.Filter");
            this.fileDialog.Multiselect = true;
            this.fileDialog.Title = "Select files to upload";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(698, 22);
            this.progressBar.TabIndex = 3;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // tblProgress
            // 
            this.tblProgress.ColumnCount = 2;
            this.tblProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.41232F));
            this.tblProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.58768F));
            this.tblProgress.Controls.Add(this.progressBar, 0, 0);
            this.tblProgress.Controls.Add(this.btnCancelLoading, 1, 0);
            this.tblProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblProgress.Location = new System.Drawing.Point(0, 448);
            this.tblProgress.Name = "tblProgress";
            this.tblProgress.RowCount = 1;
            this.tblProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProgress.Size = new System.Drawing.Size(844, 28);
            this.tblProgress.TabIndex = 5;
            this.tblProgress.Visible = false;
            // 
            // btnCancelLoading
            // 
            this.btnCancelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelLoading.Location = new System.Drawing.Point(707, 3);
            this.btnCancelLoading.Name = "btnCancelLoading";
            this.btnCancelLoading.Size = new System.Drawing.Size(134, 22);
            this.btnCancelLoading.TabIndex = 4;
            this.btnCancelLoading.Values.Image = global::SurveyManager.Properties.Resources.error_16x16;
            this.btnCancelLoading.Values.Text = "Cancel";
            this.btnCancelLoading.Click += new System.EventHandler(this.btnCancelLoading_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::SurveyManager.Properties.Resources.view_16x16;
            this.btnPreview.Text = "Preview...";
            this.btnPreview.UniqueName = "9375A9B752B1440D459DA3AD6C2A3260";
            this.btnPreview.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblFileSize});
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(844, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(685, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblFileSize
            // 
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(144, 17);
            this.lblFileSize.Text = "Total File Size For This Job:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.kryptonPanel1);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propGrid);
            this.splitContainer1.Size = new System.Drawing.Size(844, 448);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 7;
            // 
            // UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSave,
            this.btnPreview});
            this.ClientSize = new System.Drawing.Size(844, 498);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tblProgress);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UploadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Files";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadFile_FormClosing);
            this.Load += new System.EventHandler(this.UploadFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).EndInit();
            this.picPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.tblProgress.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbFileNames;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemoveSelected;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddFile;
        private System.Windows.Forms.PropertyGrid propGrid;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSave;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.PictureBox picBox;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel picPanel;
        private System.Windows.Forms.TableLayoutPanel tblProgress;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelLoading;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnPreview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblFileSize;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}