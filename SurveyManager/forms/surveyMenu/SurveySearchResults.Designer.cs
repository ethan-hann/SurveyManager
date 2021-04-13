
namespace SurveyManager.forms.surveyMenu
{
    partial class SurveySearchResults
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
            this.lbJobs = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.propGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.SuspendLayout();
            // 
            // lbJobs
            // 
            this.lbJobs.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbJobs.Location = new System.Drawing.Point(0, 0);
            this.lbJobs.Name = "lbJobs";
            this.lbJobs.Size = new System.Drawing.Size(221, 450);
            this.lbJobs.TabIndex = 0;
            this.lbJobs.SelectedIndexChanged += new System.EventHandler(this.lbJobs_SelectedIndexChanged);
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.Location = new System.Drawing.Point(221, 0);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(579, 450);
            this.propGrid.TabIndex = 1;
            // 
            // SurveySearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.lbJobs);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SurveySearchResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Results";
            this.Load += new System.EventHandler(this.SurveySearchResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbJobs;
        private SurveyManager.utility.CustomControls.CPropertyGrid propGrid;
    }
}