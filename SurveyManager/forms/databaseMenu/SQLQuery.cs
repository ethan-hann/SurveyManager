using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.databaseMenu
{
    public partial class SQLQuery : KryptonForm
    {
        public EventHandler StatusUpdate;

        public SQLQuery()
        {
            InitializeComponent();
        }

        private void SQLQuery_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.sql_16x16.GetHicon());
        }

        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = Database.ExecuteFilter(txtQuery.Text);
            resultsGrid.DataSource = dt;
            resultsGrid.Update();

            if (dt.Columns.Contains("MySQL Error"))
                StatusUpdate?.Invoke(this, new StatusArgs("An error has occurred while executing a query. Please check you SQL syntax."));
            else
                StatusUpdate?.Invoke(this, new StatusArgs($"Query execution successful. {dt.Rows.Count} rows returned."));
        }
    }
}
