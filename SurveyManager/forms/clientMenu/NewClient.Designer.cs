
namespace SurveyManager.forms.clientMenu
{
    partial class NewClient
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
            this.clientPropGrid = new SurveyManager.utility.CustomControls.CPropertyGrid(this.components);
            this.SuspendLayout();
            // 
            // clientPropGrid
            // 
            this.clientPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPropGrid.Location = new System.Drawing.Point(0, 0);
            this.clientPropGrid.Name = "clientPropGrid";
            this.clientPropGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.clientPropGrid.Size = new System.Drawing.Size(708, 450);
            this.clientPropGrid.TabIndex = 0;
            // 
            // NewClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.clientPropGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Client";
            this.Load += new System.EventHandler(this.NewClient_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SurveyManager.utility.CustomControls.CPropertyGrid clientPropGrid;
    }
}