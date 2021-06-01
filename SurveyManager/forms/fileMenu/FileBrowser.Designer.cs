
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
            this.splitPanels = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanels)).BeginInit();
            this.splitPanels.Panel1.SuspendLayout();
            this.splitPanels.Panel2.SuspendLayout();
            this.splitPanels.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesList
            // 
            this.filesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesList.HideSelection = false;
            this.filesList.Location = new System.Drawing.Point(0, 0);
            this.filesList.Name = "filesList";
            this.filesList.Size = new System.Drawing.Size(800, 527);
            this.filesList.TabIndex = 0;
            this.filesList.UseCompatibleStateImageBehavior = false;
            this.filesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filesList_MouseClick);
            this.filesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesList_MouseDoubleClick);
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Enabled = false;
            this.propGrid.Location = new System.Drawing.Point(0, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(409, 527);
            this.propGrid.TabIndex = 1;
            this.propGrid.ToolbarVisible = false;
            // 
            // btnDownloadFiles
            // 
            this.btnDownloadFiles.Image = global::SurveyManager.Properties.Resources.download_16x16;
            this.btnDownloadFiles.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Inherit;
            this.btnDownloadFiles.Text = "Download Selected File(s)";
            this.btnDownloadFiles.ToolTipBody = "Download the selected files to a compressed zip file.";
            this.btnDownloadFiles.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.btnDownloadFiles.ToolTipTitle = "Download";
            this.btnDownloadFiles.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Generic;
            this.btnDownloadFiles.UniqueName = "41E809C1501B47F0E6AC85E8A2B0B6A9";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Compressed Zip Archive (*.zip)|*.zip";
            this.saveDialog.Title = "Download Multiple Files";
            // 
            // splitPanels
            // 
            this.splitPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanels.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPanels.Location = new System.Drawing.Point(0, 0);
            this.splitPanels.Name = "splitPanels";
            // 
            // splitPanels.Panel1
            // 
            this.splitPanels.Panel1.Controls.Add(this.filesList);
            // 
            // splitPanels.Panel2
            // 
            this.splitPanels.Panel2.Controls.Add(this.propGrid);
            this.splitPanels.Panel2Collapsed = true;
            this.splitPanels.Size = new System.Drawing.Size(800, 527);
            this.splitPanels.SplitterDistance = 387;
            this.splitPanels.TabIndex = 2;
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnDownloadFiles});
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.splitPanels);
            this.Name = "FileBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileBrowser_FormClosed);
            this.Load += new System.EventHandler(this.FileBrowser_Load);
            this.splitPanels.Panel1.ResumeLayout(false);
            this.splitPanels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanels)).EndInit();
            this.splitPanels.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView filesList;
        private System.Windows.Forms.PropertyGrid propGrid;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnDownloadFiles;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.SplitContainer splitPanels;
    }
}