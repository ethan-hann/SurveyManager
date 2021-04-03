
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
            this.lbResults = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.resultPropertyGrid = new SurveyManager.utility.CustomControls.CPropertyGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSaveChanges = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnClearChanges = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbResults
            // 
            this.lbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResults.Location = new System.Drawing.Point(3, 38);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(267, 555);
            this.lbResults.TabIndex = 0;
            this.lbResults.SelectedIndexChanged += new System.EventHandler(this.lbResults_SelectedIndexChanged);
            // 
            // resultPropertyGrid
            // 
            this.resultPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPropertyGrid.Location = new System.Drawing.Point(276, 3);
            this.resultPropertyGrid.Name = "resultPropertyGrid";
            this.tableLayoutPanel1.SetRowSpan(this.resultPropertyGrid, 2);
            this.resultPropertyGrid.Size = new System.Drawing.Size(544, 590);
            this.resultPropertyGrid.TabIndex = 1;
            this.resultPropertyGrid.ToolbarVisible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.flowLayoutPanel1.Controls.Add(this.lblSearch);
            this.flowLayoutPanel1.Controls.Add(this.txtSearch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(3, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(49, 20);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Values.Text = "Search: ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(58, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(204, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Image = global::SurveyManager.Properties.Resources.success_16x16;
            this.btnSaveChanges.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.ToolTipBody = "Save any changes made in the properties to the database.";
            this.btnSaveChanges.ToolTipTitle = "Save Changes";
            this.btnSaveChanges.UniqueName = "A39BF84E9C2D4943E3BD43647E911278";
            // 
            // btnClearChanges
            // 
            this.btnClearChanges.Image = global::SurveyManager.Properties.Resources.error_16x16;
            this.btnClearChanges.Text = "Clear Changes";
            this.btnClearChanges.ToolTipBody = "Clears any changes made to the properties and reverts them back to values from th" +
    "e database.";
            this.btnClearChanges.ToolTipTitle = "Clear Changes";
            this.btnClearChanges.UniqueName = "34B9BF03FD45411FDAB34DCCC069A507";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.17133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.82867F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultPropertyGrid, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbResults, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.040268F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.95973F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(823, 596);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ViewObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSaveChanges,
            this.btnClearChanges});
            this.ClientSize = new System.Drawing.Size(823, 596);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewObjects";
            this.ShowInTaskbar = false;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.FilterResults_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbResults;
        private SurveyManager.utility.CustomControls.CPropertyGrid resultPropertyGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSaveChanges;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnClearChanges;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}