
namespace SurveyManager.forms.userControls
{
    partial class NewObject
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
            this.propGrid = new SurveyManager.utility.CustomControls.CPropertyGrid();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Location = new System.Drawing.Point(0, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(695, 478);
            this.propGrid.TabIndex = 0;
            // 
            // NewObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propGrid);
            this.Name = "NewObject";
            this.Size = new System.Drawing.Size(695, 478);
            this.ResumeLayout(false);

        }

        #endregion

        private SurveyManager.utility.CustomControls.CPropertyGrid propGrid;
    }
}
