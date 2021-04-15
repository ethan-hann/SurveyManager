
namespace SurveyManager.forms.fileMenu
{
    partial class FileBrowser
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
            this.filesList = new System.Windows.Forms.ListView();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.btnDownloadFiles = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // filesList
            // 
            this.filesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesList.HideSelection = false;
            this.filesList.Location = new System.Drawing.Point(0, 0);
            this.filesList.Name = "filesList";
            this.filesList.Size = new System.Drawing.Size(481, 527);
            this.filesList.TabIndex = 0;
            this.filesList.UseCompatibleStateImageBehavior = false;
            this.filesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filesList_MouseClick);
            this.filesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesList_MouseDoubleClick);
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.propGrid.Location = new System.Drawing.Point(481, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(319, 527);
            this.propGrid.TabIndex = 1;
            // 
            // btnDownloadFiles
            // 
            this.btnDownloadFiles.Image = global::SurveyManager.Properties.Resources.download_16x16;
            this.btnDownloadFiles.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Inherit;
            this.btnDownloadFiles.Text = "Download Selected Files";
            this.btnDownloadFiles.ToolTipBody = "Download the selected files to a compressed zip file.";
            this.btnDownloadFiles.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.btnDownloadFiles.ToolTipTitle = "Download";
            this.btnDownloadFiles.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Generic;
            this.btnDownloadFiles.UniqueName = "41E809C1501B47F0E6AC85E8A2B0B6A9";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Compressed Zip Archive (*.zip)|*.zip";
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnDownloadFiles});
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.filesList);
            this.Controls.Add(this.propGrid);
            this.Name = "FileBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileBrowser_FormClosed);
            this.Load += new System.EventHandler(this.FileBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView filesList;
        private System.Windows.Forms.PropertyGrid propGrid;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnDownloadFiles;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}