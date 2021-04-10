
namespace SurveyManager.forms.userControls
{
    partial class NewSurveyCtl
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
            this.components = new System.ComponentModel.Container();
            this.surveyPropGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.SuspendLayout();
            // 
            // surveyPropGrid
            // 
            this.surveyPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surveyPropGrid.Location = new System.Drawing.Point(0, 0);
            this.surveyPropGrid.Name = "surveyPropGrid";
            this.surveyPropGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.surveyPropGrid.Size = new System.Drawing.Size(994, 548);
            this.surveyPropGrid.TabIndex = 3;
            // 
            // NewSurveyCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.surveyPropGrid);
            this.Name = "NewSurveyCtl";
            this.Size = new System.Drawing.Size(994, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private utility.CustomControls.CPropertyGrid surveyPropGrid;
    }
}
