using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
using SurveyManager.Properties;
using System;
using System.Collections;
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
        private object[] results;
        private Type resultDataType = null;

        public FilterResults(object[] results, string title = "")
        {
            InitializeComponent();

            this.results = results;

            Text = title.Equals("") ? "Search Results" : title;
        }

        private void FilterResults_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.filter_16x16.GetHicon());

            foreach (object o in results)
            {
                lbResults.Items.Add(o);
            }
        }

        private void lbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultPropertyGrid.SelectedObject = lbResults.SelectedItem;
        }
    }
}
