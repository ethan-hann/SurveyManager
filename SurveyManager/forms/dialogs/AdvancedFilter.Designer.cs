
using SurveyManager.utility;

namespace SurveyManager.forms.dialogs
{
    partial class AdvancedFilter
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbColumns = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dBMapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbChoices = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtSearch1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnAddFilter = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.booleanOptions = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.andContextItem = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.orContextItem = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.dgvFilters = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.columnDBColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBoolean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.boolContext = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.dgvFilters);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 397);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cmbColumns);
            this.flowLayoutPanel2.Controls.Add(this.cmbChoices);
            this.flowLayoutPanel2.Controls.Add(this.txtSearch1);
            this.flowLayoutPanel2.Controls.Add(this.btnAddFilter);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(772, 41);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // cmbColumns
            // 
            this.cmbColumns.DataSource = this.dBMapBindingSource;
            this.cmbColumns.DisplayMember = "DisplayField";
            this.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumns.DropDownWidth = 143;
            this.cmbColumns.Location = new System.Drawing.Point(3, 3);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(143, 21);
            this.cmbColumns.TabIndex = 0;
            this.cmbColumns.ValueMember = "InternalField";
            this.cmbColumns.SelectedIndexChanged += new System.EventHandler(this.cmbColumns_SelectedIndexChanged);
            // 
            // dBMapBindingSource
            // 
            this.dBMapBindingSource.DataSource = typeof(SurveyManager.utility.DBMap);
            // 
            // cmbChoices
            // 
            this.cmbChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChoices.DropDownWidth = 143;
            this.cmbChoices.Items.AddRange(new object[] {
            "StartsLike",
            "EndsLike",
            "Like",
            "NotLike",
            "Equals",
            "LessOrEqual",
            "GreaterOrEqual",
            "NotEqual",
            "Greater",
            "Less"});
            this.cmbChoices.Location = new System.Drawing.Point(152, 3);
            this.cmbChoices.Name = "cmbChoices";
            this.cmbChoices.Size = new System.Drawing.Size(143, 21);
            this.cmbChoices.TabIndex = 1;
            // 
            // txtSearch1
            // 
            this.txtSearch1.Location = new System.Drawing.Point(301, 3);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(307, 23);
            this.txtSearch1.TabIndex = 2;
            this.txtSearch1.Text = "Search Text Here...";
            this.txtSearch1.Enter += new System.EventHandler(this.txtSearch1_Enter);
            this.txtSearch1.Leave += new System.EventHandler(this.txtSearch1_Leave);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.KryptonContextMenu = this.booleanOptions;
            this.btnAddFilter.Location = new System.Drawing.Point(614, 3);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(148, 25);
            this.btnAddFilter.TabIndex = 3;
            this.btnAddFilter.Values.Text = "Add Filter";
            // 
            // booleanOptions
            // 
            this.booleanOptions.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems1});
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.andContextItem,
            this.orContextItem});
            // 
            // andContextItem
            // 
            this.andContextItem.Text = "And";
            // 
            // orContextItem
            // 
            this.orContextItem.Text = "Or";
            // 
            // dgvFilters
            // 
            this.dgvFilters.AllowUserToAddRows = false;
            this.dgvFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDBColumn,
            this.columnOption,
            this.columnCriteria,
            this.columnBoolean});
            this.dgvFilters.Location = new System.Drawing.Point(3, 50);
            this.dgvFilters.Name = "dgvFilters";
            this.dgvFilters.Size = new System.Drawing.Size(762, 283);
            this.dgvFilters.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvFilters.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvFilters.TabIndex = 1;
            // 
            // columnDBColumn
            // 
            this.columnDBColumn.HeaderText = "Column";
            this.columnDBColumn.Name = "columnDBColumn";
            this.columnDBColumn.ReadOnly = true;
            this.columnDBColumn.ToolTipText = "The column in the database to search";
            this.columnDBColumn.Width = 180;
            // 
            // columnOption
            // 
            this.columnOption.HeaderText = "Operation";
            this.columnOption.Name = "columnOption";
            this.columnOption.ReadOnly = true;
            this.columnOption.ToolTipText = "The operation to apply on the search text";
            this.columnOption.Width = 181;
            // 
            // columnCriteria
            // 
            this.columnCriteria.HeaderText = "Text";
            this.columnCriteria.Name = "columnCriteria";
            this.columnCriteria.ToolTipText = "The text to search the Column for using the specified operation.";
            this.columnCriteria.Width = 180;
            // 
            // columnBoolean
            // 
            this.columnBoolean.HeaderText = "Boolean";
            this.columnBoolean.Name = "columnBoolean";
            this.columnBoolean.ReadOnly = true;
            this.columnBoolean.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnBoolean.Width = 180;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 339);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 46);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new System.Drawing.Point(617, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 36);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Values.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Location = new System.Drawing.Point(480, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 36);
            this.btnClear.TabIndex = 0;
            this.btnClear.Values.Text = "Clear Filter";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // boolContext
            // 
            this.boolContext.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems2});
            // 
            // kryptonContextMenuItems2
            // 
            this.kryptonContextMenuItems2.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1,
            this.kryptonContextMenuItem2});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "And";
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.Text = "Or";
            // 
            // AdvancedFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 397);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedFilter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.AdvancedFilter_HelpRequested);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvFilters;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbColumns;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbChoices;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch1;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton btnAddFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu booleanOptions;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem andContextItem;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem orContextItem;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClear;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu boolContext;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
        private System.Windows.Forms.BindingSource dBMapBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDBColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBoolean;
    }
}