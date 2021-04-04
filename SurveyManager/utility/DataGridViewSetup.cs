﻿using ComponentFactory.Krypton.Toolkit;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.utility
{
    public class DataGridViewSetup
    {
        public static void SetupDGV(KryptonOutlookGrid grid, EntityTypes typeOfData)
        {
            grid.ClearEverything();
            if (grid.GroupBox != null)
            {
                grid.GroupBox.Visible = true;
                grid.HideColumnOnGrouping = false;
            }

            grid.FillMode = FillMode.GROUPSANDNODES;
            grid.ShowLines = true;

            List<DataGridViewColumn> columnsToAdd = new List<DataGridViewColumn>();
            switch (typeOfData)
            {
                case EntityTypes.Client:
                {
                    DataGridViewColumn clientIDColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Client ID",
                        Name = "clientIDColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(clientIDColumn);
                    DataGridViewColumn clientNameColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Client Name",
                        Name = "clientNameColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(clientNameColumn);
                    grid.Columns.AddRange(columnsToAdd.ToArray());

                    grid.AddInternalColumn(clientIDColumn, new OutlookGridDefaultGroup() { OneItemText = "1 client", XXXItemsText = " clients" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(clientNameColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 client", XXXItemsText = " clients" }, SortOrder.None, -1, -1);
                    break;
                }
            }
        }
    }
}
