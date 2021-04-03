
namespace SurveyManager.forms
{
    partial class FilterResults
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
            this.lbResults = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.resultPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // lbResults
            // 
            this.lbResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbResults.Location = new System.Drawing.Point(0, 0);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(268, 596);
            this.lbResults.TabIndex = 0;
            this.lbResults.SelectedIndexChanged += new System.EventHandler(this.lbResults_SelectedIndexChanged);
            // 
            // resultPropertyGrid
            // 
            this.resultPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPropertyGrid.Enabled = false;
            this.resultPropertyGrid.Location = new System.Drawing.Point(268, 0);
            this.resultPropertyGrid.Name = "resultPropertyGrid";
            this.resultPropertyGrid.Size = new System.Drawing.Size(555, 596);
            this.resultPropertyGrid.TabIndex = 1;
            // 
            // FilterResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(823, 596);
            this.Controls.Add(this.resultPropertyGrid);
            this.Controls.Add(this.lbResults);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FilterResults";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.FilterResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbResults;
        private System.Windows.Forms.PropertyGrid resultPropertyGrid;
    }
}