using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.Properties;
using SurveyManager.utility;
using SurveyManager.utility.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.dialogs
{
    /// <summary>
    /// This is an advanced filter dialog that makes use of the classes in the <see cref="utility.Filtering"/> namespace.
    /// <para>
    /// To filter, a user adds a row to the <see cref="DataGridView"/> by using the combo boxes and text input, along with a drop-down button with two <see cref="BooleanOps"/> (AND, OR).
    /// </para>
    /// <para>
    /// To use this dialog, an <see cref="ArrayList"/> of columns of type <see cref="DBMap"/> must be provided to populate the combo boxes. The table name in the actual database must also be
    /// provided for use in creating the final query string.
    /// </para>
    /// </summary>
    public partial class AdvancedFilter : KryptonForm
    {
        private ArrayList filters = new ArrayList();
        private string whereClause;
        private readonly string optionalClause;
        private string query;
        private readonly string tableName;
        private List<SqlOperators> originalOperators = new List<SqlOperators>((SqlOperators[])Enum.GetValues(typeof(SqlOperators)));
        private List<SqlOperators> likeOperatorOnly = new List<SqlOperators>
        {
            SqlOperators.Like
        };

        private int selectedOperationIndex = 0;

        /// <summary>
        /// Occurs whenever the filtering is done.
        /// </summary>
        public EventHandler FilterDone;

        /// <summary>
        /// Create a new <see cref="AdvancedFilter"/> dialog with the specified table name, columns, and optional title.
        /// </summary>
        /// <param name="tableName">The table name in the backing database.</param>
        /// <param name="columns">The column options available for the user to select from. This <see cref="ArrayList"/> must contain items of type <see cref="DBMap"/>.</param>
        /// <param name="title">The optional title displayed in the titlebar of this dialog.</param>
        /// <param name="additionalColumnFilter">The optional, additional filter to search by. Example: <c>company_id=1</c></param>
        public AdvancedFilter(string tableName, ArrayList columns, string title = "", string additionalColumnFilter = "", Icon windowIcon = null)
        {
            InitializeComponent();
            if (title.Equals(""))
            {
                Text = "Filter";
            }
            else
            {
                Text = title;
            }

            if (additionalColumnFilter.Equals(""))
            {
                optionalClause = "";
            }
            else
            {
                optionalClause = additionalColumnFilter;
            }

            this.tableName = tableName;

            //Event handlers
            btnAddFilter.Click += AddFilterToGrid;
            andContextItem.Click += AddAndOperation;
            orContextItem.Click += AddOrOperation;

            cmbColumns.DataSource = columns; //Column options for the user to select
            cmbChoices.DataSource = originalOperators;

            cmbColumns.SelectedIndex = 0;
            cmbChoices.SelectedIndex = 0;

            if (windowIcon == null)
                Icon = Icon.FromHandle(Resources.filter_16x16.GetHicon());
            else
                Icon = windowIcon;
        }

        private void AddFilterToGrid(object sender, EventArgs e)
        {
            DBMap column = (DBMap)cmbColumns.SelectedItem;
            SqlOperators operation = (SqlOperators)Enum.Parse(typeof(SqlOperators), cmbChoices.SelectedItem.ToString());
            string value = txtSearch1.Text;

            if (dgvFilters.Rows.Count >= 1)
            {
                dgvFilters.Rows.Add(column, operation.ToString(), value, BooleanOps.AND);
            }
            else
            {
                dgvFilters.Rows.Add(column, operation.ToString(), value);
            }
        }

        private void AddAndOperation(object sender, EventArgs e)
        {
            DBMap column = (DBMap)cmbColumns.SelectedItem;
            SqlOperators operation = (SqlOperators)Enum.Parse(typeof(SqlOperators), cmbChoices.SelectedItem.ToString());
            string value = txtSearch1.Text;

            if (dgvFilters.Rows.Count >= 1)
            {
                dgvFilters.Rows.Add(column, operation.ToString(), value, BooleanOps.AND);
            }
            else
            {
                dgvFilters.Rows.Add(column, operation.ToString(), value);
            }
        }

        private void AddOrOperation(object sender, EventArgs e)
        {
            DBMap column = (DBMap)cmbColumns.SelectedItem;
            SqlOperators operation = (SqlOperators)Enum.Parse(typeof(SqlOperators), cmbChoices.SelectedItem.ToString());
            string value = txtSearch1.Text;

            if (dgvFilters.Rows.Count >= 1)
            {
                dgvFilters.Rows.Add(column, operation, value, BooleanOps.OR);
            }
            else
            {
                dgvFilters.Rows.Add(column, operation, value);
            }
        }

        private string BuildFilter()
        {
            string fieldName = ((DBMap)dgvFilters.Rows[0].Cells["columnDBColumn"].Value).InternalField;
            string searchText = (string)dgvFilters.Rows[0].Cells["columnCriteria"].Value;
            SqlOperators operation = (SqlOperators)Enum.Parse(typeof(SqlOperators), (string)dgvFilters.Rows[0].Cells["columnOption"].Value);

            if (tableName.Equals("Survey"))
            {
                if (fieldName.Equals("county_id"))
                {
                    int countyID = RuntimeVars.Instance.Counties.Find(c => c.CountyName.ToLower().Contains(searchText.ToLower())).ID;
                    searchText = countyID.ToString();
                    operation = SqlOperators.Like;
                }
            }

            //Always add the first row to the filter list.
            filters = new ArrayList
            {
                new Filter(fieldName, operation, searchText)
            };

            //If there are more rows, continue adding filters that build on each other.
            if (dgvFilters.Rows.Count > 1)
            {
                for (int i = 1; i < dgvFilters.Rows.Count; i++)
                {
                    DataGridViewRow currentRow = dgvFilters.Rows[i];

                    fieldName = ((DBMap)currentRow.Cells["columnDBColumn"].Value).InternalField;
                    searchText = (string)currentRow.Cells["columnCriteria"].Value;
                    operation = (SqlOperators)Enum.Parse(typeof(SqlOperators), (string)currentRow.Cells["columnOption"].Value);

                    if (tableName.Equals("Survey"))
                    {
                        if (fieldName.Equals("county_id"))
                        {
                            int countyID = RuntimeVars.Instance.Counties.Find(c => c.CountyName.ToLower().Contains(searchText.ToLower())).ID;
                            searchText = countyID.ToString();
                            operation = SqlOperators.Like;
                        }
                    }

                    Filter f = new Filter(fieldName, operation, searchText);

                    BooleanOps op = (BooleanOps)currentRow.Cells["columnBoolean"].Value;
                    switch (op)
                    {
                        case BooleanOps.AND:
                        filters.Add(new ANDFilter((IFilter)filters[i - 1], f));
                        break;
                        case BooleanOps.OR:
                        filters.Add(new ORFilter((IFilter)filters[i - 1], f));
                        break;
                    }
                }
            }

            //Return the final filter string in the FilterExpressionList.
            return ((IFilter)filters[filters.Count - 1]).FilterString;
        }

        private string BuildFilterNoRows()
        {
            string fieldName = ((DBMap)cmbColumns.SelectedItem).InternalField;
            string searchText = txtSearch1.Text;
            SqlOperators operation = (SqlOperators)Enum.Parse(typeof(SqlOperators), cmbChoices.SelectedItem.ToString(), false);

            if (tableName.Equals("Survey"))
            {
                if (fieldName.Equals("county_id"))
                {
                    int countyID = RuntimeVars.Instance.Counties.Find(c => c.CountyName.ToLower().Contains(searchText.ToLower())).ID;
                    searchText = countyID.ToString();
                    operation = SqlOperators.Like;
                }
            }

            filters = new ArrayList
            {
                new Filter(fieldName, operation, searchText)
            };

            return ((IFilter)filters[0]).FilterString;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //If grid contains rows, build normal filter string
            if (dgvFilters.Rows.Count >= 1)
            {
                whereClause = BuildFilter();
            }

            //Otherwise, just use the values in the combo boxes and text box to build the filter
            else if (!txtSearch1.Text.Equals(string.Empty) || !txtSearch1.Text.Equals("Search Text Here..."))
            {
                whereClause = BuildFilterNoRows();
            }

            if (optionalClause.Equals(""))
            {
                query = $"SELECT * FROM {tableName} WHERE {whereClause};";
            }
            else
            {
                query = $"SELECT * FROM {tableName} WHERE {optionalClause} AND {whereClause};";
            }

            FilterDoneEventArgs args = new FilterDoneEventArgs(Database.ExecuteFilter(query), query);

            if (args.Results == null || args.Results.Rows.Count <= 0)
            {
                CMessageBox.Show("No records found with that filter.\nTry to refine it.", "No Records", MessageBoxButtons.OK, Resources.warning_64x64);
            }
            else
            {
                FilterDone?.Invoke(this, args);
                Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvFilters.Rows.Clear();
            whereClause = "";
            query = "";
        }

        private void txtSearch1_Enter(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Equals("Search Text Here..."))
            {
                txtSearch1.Text = "";
                txtSearch1.ForeColor = RuntimeVars.Instance.MainForm.GetPalette().GetContentShortTextColor1(PaletteContentStyle.InputControlCustom1, PaletteState.Normal);
            }
        }

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Length == 0)
            {
                txtSearch1.Text = "Search Text Here...";
                txtSearch1.ForeColor = SystemColors.GrayText;
            }
        }

        private void AdvancedFilter_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "file://..\\Help\\index.chm", HelpNavigator.Topic, "advanced_filter.html");
            hlpevent.Handled = true;
        }

        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoices.DataSource != likeOperatorOnly)
                selectedOperationIndex = cmbChoices.SelectedIndex;

            if (((DBMap)cmbColumns.SelectedItem).InternalField.Equals("county_id"))
            {
                cmbChoices.DataSource = likeOperatorOnly;
                cmbChoices.SelectedIndex = 0;
            }
            else
            {
                cmbChoices.DataSource = originalOperators;
                cmbChoices.SelectedIndex = selectedOperationIndex;
            }
        }
    }
}
