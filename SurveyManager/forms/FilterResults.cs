using ComponentFactory.Krypton.Toolkit;
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

namespace SurveyManager.forms
{
    public partial class FilterResults : KryptonForm
    {
        private DataTable results;
        private Type resultDataType;

        public FilterResults(DataTable filterResults, Type typeOfData, string title = "")
        {
            InitializeComponent();

            results = filterResults;
            resultDataType = typeOfData;

            Text = title.Equals("") ? "Search Results" : title;
        }

        private void FilterResults_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.filter_16x16.GetHicon());

            foreach (DataRow r in results.Rows)
            {
                lbResults.Items.Add(r);
            }
        }

        private void lbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultPropertyGrid.SelectedObject = lbResults.SelectedItem;
        }
    }
}
