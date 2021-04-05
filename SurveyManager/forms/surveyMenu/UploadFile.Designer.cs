
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
            this.lbFileNames = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveSelected = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddFile = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFileNames
            // 
            this.lbFileNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFileNames.Location = new System.Drawing.Point(0, 0);
            this.lbFileNames.Name = "lbFileNames";
            this.lbFileNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFileNames.Size = new System.Drawing.Size(297, 461);
            this.lbFileNames.TabIndex = 0;
            this.lbFileNames.SelectedIndexChanged += new System.EventHandler(this.lbFileNames_SelectedIndexChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lbFileNames);
            this.kryptonPanel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(297, 498);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveSelected);
            this.flowLayoutPanel1.Controls.Add(this.btnAddFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 461);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(297, 37);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(170, 3);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(124, 25);
            this.btnRemoveSelected.TabIndex = 0;
            this.btnRemoveSelected.Values.Image = global::SurveyManager.Properties.Resources.delete_16x16;
            this.btnRemoveSelected.Values.Text = "Remove Selected";
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(40, 3);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(124, 25);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Values.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddFile.Values.Text = "Add File(s)...";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Location = new System.Drawing.Point(297, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(547, 498);
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
            this.fileDialog.Filter = "AutoCAD Drawing (*.dwg)|*.dwg|PDF (*.pdf)|*.pdf|Word Document (*.doc;*.docx)|*.do" +
    "c;*.docx|Text File|*.txt|Image (*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png";
            this.fileDialog.Multiselect = true;
            this.fileDialog.Title = "Select files to upload";
            // 
            // UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSave});
            this.ClientSize = new System.Drawing.Size(844, 498);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UploadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload Files";
            this.Load += new System.EventHandler(this.UploadFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}