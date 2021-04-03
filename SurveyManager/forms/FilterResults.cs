﻿using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
using SurveyManager.Properties;
using SurveyManager.utility.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace SurveyManager.forms
{
    public partial class ViewObjects : KryptonForm
    {
        private object[] results;
        private DataTable tableResults;
        private string displayMember;
        private string rowFilterColumn;

        public ViewObjects(DataTable table, object[] objects, string dataDisplayMember, string rowFilterColumn, string title = "")
        {
            InitializeComponent();

            results = objects;
            tableResults = table;
            displayMember = dataDisplayMember;
            this.rowFilterColumn = rowFilterColumn;

            Text = title.Equals("") ? "View Objects" : title;
        }

        private void FilterResults_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.filter_16x16.GetHicon());

            lbResults.DataSource = tableResults;
            lbResults.DisplayMember = displayMember;

            btnSaveChanges.Click += SaveClick;
            btnClearChanges.Click += ClearClick;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tableResults.DefaultView;

            dv.RowFilter = $"{rowFilterColumn} LIKE '%{txtSearch.Text}%'";
        }

        private void ClearClick(object sender, EventArgs e)
        {
            
        }

        private void SaveClick(object sender, EventArgs e)
        {
            
        }

        private void lbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbResults.SelectedIndex > -1)
                resultPropertyGrid.SelectedObject = results[lbResults.SelectedIndex];
            else
                resultPropertyGrid.SelectedObject = null;
        }
    }
}
