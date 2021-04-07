
namespace SurveyManager.forms.newForms
{
    partial class NewSurvey
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
            this.components = new System.ComponentModel.Container();
            this.hdrGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.clientPage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.clientPropGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.realtorPage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.realtorPropGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.titleCompanyPage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tcPropGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.filesPage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.fileCtl = new SurveyManager.forms.surveyMenu.UploadFileCtl();
            this.surveyPropGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).BeginInit();
            this.hdrGroup.Panel.SuspendLayout();
            this.hdrGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientPage)).BeginInit();
            this.clientPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realtorPage)).BeginInit();
            this.realtorPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleCompanyPage)).BeginInit();
            this.titleCompanyPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filesPage)).BeginInit();
            this.filesPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // hdrGroup
            // 
            this.hdrGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.hdrGroup.Location = new System.Drawing.Point(0, 0);
            this.hdrGroup.Name = "hdrGroup";
            // 
            // hdrGroup.Panel
            // 
            this.hdrGroup.Panel.Controls.Add(this.kryptonNavigator1);
            this.hdrGroup.Size = new System.Drawing.Size(571, 455);
            this.hdrGroup.TabIndex = 2;
            this.hdrGroup.ValuesPrimary.Heading = "Associated Objects";
            this.hdrGroup.ValuesPrimary.Image = null;
            this.hdrGroup.ValuesSecondary.Heading = "You can drag-and-drop objects here from another window or enter the required info" +
    "rmation manually.";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SlantEqualFar;
            this.kryptonNavigator1.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.Dock;
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.clientPage,
            this.realtorPage,
            this.titleCompanyPage,
            this.filesPage});
            this.kryptonNavigator1.SelectedIndex = 2;
            this.kryptonNavigator1.Size = new System.Drawing.Size(569, 402);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // clientPage
            // 
            this.clientPage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.clientPage.Controls.Add(this.clientPropGrid);
            this.clientPage.Flags = 65534;
            this.clientPage.LastVisibleSet = true;
            this.clientPage.MinimumSize = new System.Drawing.Size(50, 50);
            this.clientPage.Name = "clientPage";
            this.clientPage.Size = new System.Drawing.Size(567, 379);
            this.clientPage.Text = "Client";
            this.clientPage.ToolTipTitle = "Page ToolTip";
            this.clientPage.UniqueName = "5E51557D83E74BB373BFA70C3F2B42BB";
            this.clientPage.DragDrop += new System.Windows.Forms.DragEventHandler(this.propGrid_DragDrop);
            this.clientPage.DragEnter += new System.Windows.Forms.DragEventHandler(this.propGrid_DragEnter);
            // 
            // clientPropGrid
            // 
            this.clientPropGrid.AllowDrop = true;
            this.clientPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPropGrid.Location = new System.Drawing.Point(0, 0);
            this.clientPropGrid.Name = "clientPropGrid";
            this.clientPropGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.clientPropGrid.Size = new System.Drawing.Size(567, 379);
            this.clientPropGrid.TabIndex = 1;
            this.clientPropGrid.SelectedObjectsChanged += new System.EventHandler(this.clientPropGrid_SelectedObjectsChanged);
            this.clientPropGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.propGrid_DragDrop);
            this.clientPropGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.propGrid_DragEnter);
            // 
            // realtorPage
            // 
            this.realtorPage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.realtorPage.Controls.Add(this.realtorPropGrid);
            this.realtorPage.Flags = 65534;
            this.realtorPage.LastVisibleSet = true;
            this.realtorPage.MinimumSize = new System.Drawing.Size(50, 50);
            this.realtorPage.Name = "realtorPage";
            this.realtorPage.Size = new System.Drawing.Size(567, 379);
            this.realtorPage.Text = "Realtor";
            this.realtorPage.ToolTipTitle = "Page ToolTip";
            this.realtorPage.UniqueName = "3ED21E09D9CA4B5FFDBF0B2E0596E99D";
            this.realtorPage.DragDrop += new System.Windows.Forms.DragEventHandler(this.propGrid_DragDrop);
            this.realtorPage.DragEnter += new System.Windows.Forms.DragEventHandler(this.propGrid_DragEnter);
            // 
            // realtorPropGrid
            // 
            this.realtorPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.realtorPropGrid.Location = new System.Drawing.Point(0, 0);
            this.realtorPropGrid.Name = "realtorPropGrid";
            this.realtorPropGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.realtorPropGrid.Size = new System.Drawing.Size(567, 379);
            this.realtorPropGrid.TabIndex = 2;
            this.realtorPropGrid.SelectedObjectsChanged += new System.EventHandler(this.realtorPropGrid_SelectedObjectsChanged);
            this.realtorPropGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.propGrid_DragDrop);
            this.realtorPropGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.propGrid_DragEnter);
            // 
            // titleCompanyPage
            // 
            this.titleCompanyPage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.titleCompanyPage.Controls.Add(this.tcPropGrid);
            this.titleCompanyPage.Flags = 65534;
            this.titleCompanyPage.LastVisibleSet = true;
            this.titleCompanyPage.MinimumSize = new System.Drawing.Size(50, 50);
            this.titleCompanyPage.Name = "titleCompanyPage";
            this.titleCompanyPage.Size = new System.Drawing.Size(567, 379);
            this.titleCompanyPage.Text = "Title Company";
            this.titleCompanyPage.ToolTipTitle = "Page ToolTip";
            this.titleCompanyPage.UniqueName = "3A50FE19802745FD41BB070254C13799";
            this.titleCompanyPage.DragDrop += new System.Windows.Forms.DragEventHandler(this.propGrid_DragDrop);
            this.titleCompanyPage.DragEnter += new System.Windows.Forms.DragEventHandler(this.propGrid_DragEnter);
            // 
            // tcPropGrid
            // 
            this.tcPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPropGrid.Location = new System.Drawing.Point(0, 0);
            this.tcPropGrid.Name = "tcPropGrid";
            this.tcPropGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.tcPropGrid.Size = new System.Drawing.Size(567, 379);
            this.tcPropGrid.TabIndex = 3;
            this.tcPropGrid.SelectedObjectsChanged += new System.EventHandler(this.tcPropGrid_SelectedObjectsChanged);
            this.tcPropGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.propGrid_DragDrop);
            this.tcPropGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.propGrid_DragEnter);
            // 
            // filesPage
            // 
            this.filesPage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.filesPage.Controls.Add(this.fileCtl);
            this.filesPage.Flags = 65534;
            this.filesPage.LastVisibleSet = true;
            this.filesPage.MinimumSize = new System.Drawing.Size(50, 50);
            this.filesPage.Name = "filesPage";
            this.filesPage.Size = new System.Drawing.Size(567, 379);
            this.filesPage.Text = "Files";
            this.filesPage.ToolTipTitle = "Page ToolTip";
            this.filesPage.UniqueName = "08A3EB4E75F84CAB8A988469CB5679BF";
            // 
            // fileCtl
            // 
            this.fileCtl.AutoSize = true;
            this.fileCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileCtl.Location = new System.Drawing.Point(0, 0);
            this.fileCtl.Name = "fileCtl";
            this.fileCtl.Size = new System.Drawing.Size(567, 379);
            this.fileCtl.TabIndex = 0;
            // 
            // surveyPropGrid
            // 
            this.surveyPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surveyPropGrid.Location = new System.Drawing.Point(571, 0);
            this.surveyPropGrid.Name = "surveyPropGrid";
            this.surveyPropGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.surveyPropGrid.Size = new System.Drawing.Size(444, 455);
            this.surveyPropGrid.TabIndex = 0;
            // 
            // NewSurvey
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 455);
            this.Controls.Add(this.surveyPropGrid);
            this.Controls.Add(this.hdrGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewSurvey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Survey";
            this.Load += new System.EventHandler(this.NewSurvey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup.Panel)).EndInit();
            this.hdrGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hdrGroup)).EndInit();
            this.hdrGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientPage)).EndInit();
            this.clientPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.realtorPage)).EndInit();
            this.realtorPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.titleCompanyPage)).EndInit();
            this.titleCompanyPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filesPage)).EndInit();
            this.filesPage.ResumeLayout(false);
            this.filesPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SurveyManager.utility.CustomControls.CPropertyGrid surveyPropGrid;
        private utility.CustomControls.CPropertyGrid clientPropGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hdrGroup;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage clientPage;
        private ComponentFactory.Krypton.Navigator.KryptonPage realtorPage;
        private utility.CustomControls.CPropertyGrid realtorPropGrid;
        private ComponentFactory.Krypton.Navigator.KryptonPage titleCompanyPage;
        private utility.CustomControls.CPropertyGrid tcPropGrid;
        private ComponentFactory.Krypton.Navigator.KryptonPage filesPage;
        private SurveyManager.forms.surveyMenu.UploadFileCtl fileCtl;
    }
}