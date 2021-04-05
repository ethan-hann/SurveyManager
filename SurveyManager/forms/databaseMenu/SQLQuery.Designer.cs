
namespace SurveyManager.forms.databaseMenu
{
    partial class SQLQuery
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
            this.navigator = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pgOne = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btnAddNewPage = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.SqlControl = new SurveyManager.forms.databaseMenu.SqlControl();
            this.rightClickContext = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.navigator)).BeginInit();
            this.navigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgOne)).BeginInit();
            this.pgOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigator
            // 
            this.navigator.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SlantEqualFar;
            this.navigator.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.Dock;
            this.navigator.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.navigator.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.SelectPage;
            this.navigator.Button.NextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.ShowEnabled;
            this.navigator.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.SelectPage;
            this.navigator.Button.PreviousButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.ShowEnabled;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navigator.Name = "navigator";
            this.navigator.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pgOne});
            this.navigator.SelectedIndex = 0;
            this.navigator.Size = new System.Drawing.Size(737, 453);
            this.navigator.TabIndex = 0;
            this.navigator.CloseAction += new System.EventHandler<ComponentFactory.Krypton.Navigator.CloseActionEventArgs>(this.navigator_CloseAction);
            // 
            // pgOne
            // 
            this.pgOne.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pgOne.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewPage});
            this.pgOne.Controls.Add(this.SqlControl);
            this.pgOne.Flags = 63994;
            this.pgOne.KryptonContextMenu = this.rightClickContext;
            this.pgOne.LastVisibleSet = true;
            this.pgOne.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgOne.MinimumSize = new System.Drawing.Size(50, 61);
            this.pgOne.Name = "pgOne";
            this.pgOne.Size = new System.Drawing.Size(735, 426);
            this.pgOne.Text = "Query";
            this.pgOne.ToolTipTitle = "Page ToolTip";
            this.pgOne.UniqueName = "366DD626044A4C4DE5856332DAF0DCF5";
            // 
            // btnAddNewPage
            // 
            this.btnAddNewPage.Image = global::SurveyManager.Properties.Resources.add_16x16;
            this.btnAddNewPage.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.ButtonSpec;
            this.btnAddNewPage.UniqueName = "E195E8349F3C4FA211AD242DFAD709B0";
            this.btnAddNewPage.Click += new System.EventHandler(this.btnAddNewPage_Click);
            // 
            // SqlControl
            // 
            this.SqlControl.AutoSize = true;
            this.SqlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SqlControl.Location = new System.Drawing.Point(0, 0);
            this.SqlControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SqlControl.Name = "SqlControl";
            this.SqlControl.Size = new System.Drawing.Size(735, 426);
            this.SqlControl.TabIndex = 0;
            // 
            // rightClickContext
            // 
            this.rightClickContext.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems1});
            this.rightClickContext.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.rightClickContext_Closed);
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Image = global::SurveyManager.Properties.Resources.edit_16x16;
            this.kryptonContextMenuItem1.Text = "Edit Title";
            // 
            // SQLQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 453);
            this.Controls.Add(this.navigator);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SQLQuery";
            this.ShowIcon = false;
            this.Text = "Custom Queries";
            this.Load += new System.EventHandler(this.SQLQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navigator)).EndInit();
            this.navigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgOne)).EndInit();
            this.pgOne.ResumeLayout(false);
            this.pgOne.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator navigator;
        private ComponentFactory.Krypton.Navigator.KryptonPage pgOne;
        private SurveyManager.forms.databaseMenu.SqlControl SqlControl;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewPage;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu rightClickContext;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
    }
}