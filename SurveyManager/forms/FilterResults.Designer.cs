
namespace SurveyManager.forms
{
    partial class ViewObjects
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
            this.lbResults = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.resultPropertyGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.SuspendLayout();
            // 
            // lbResults
            // 
            this.lbResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbResults.Location = new System.Drawing.Point(0, 0);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(267, 596);
            this.lbResults.Sorted = true;
            this.lbResults.TabIndex = 0;
            this.lbResults.SelectedIndexChanged += new System.EventHandler(this.lbResults_SelectedIndexChanged);
            // 
            // resultPropertyGrid
            // 
            this.resultPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPropertyGrid.Enabled = false;
            this.resultPropertyGrid.Location = new System.Drawing.Point(267, 0);
            this.resultPropertyGrid.Name = "resultPropertyGrid";
            this.resultPropertyGrid.Size = new System.Drawing.Size(556, 596);
            this.resultPropertyGrid.TabIndex = 1;
            this.resultPropertyGrid.ToolbarVisible = false;
            // 
            // ViewObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(823, 596);
            this.Controls.Add(this.resultPropertyGrid);
            this.Controls.Add(this.lbResults);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewObjects";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.FilterResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbResults;
        private SurveyManager.utility.CustomControls.CPropertyGrid resultPropertyGrid;
    }
}