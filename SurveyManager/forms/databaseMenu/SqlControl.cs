using SurveyManager.backend;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.databaseMenu
{
    public partial class SqlControl : UserControl
    {
        public EventHandler StatusUpdate;

        public EventHandler QueryRan;

        public SqlControl()
        {
            InitializeComponent();
        }

        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = Database.ExecuteFilter(txtQuery.Text);
            resultsGrid.DataSource = dt;
            resultsGrid.Update();

            if (dt.Columns.Contains("MySQL Error"))
                StatusUpdate?.Invoke(this, new StatusArgs("An error has occurred while executing a query. Please check you SQL syntax."));
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"Query execution successful. {dt.Rows.Count} rows returned."));
                QueryRan?.Invoke(this, new QueryRanArgs(dt.TableName));
            }
        }

        private void btnSqlHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.learnsqlonline.org/");
        }
    }
}
