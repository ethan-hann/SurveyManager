using ComponentFactory.Krypton.Toolkit;
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

                case EntityTypes.Realtor:
                {
                    DataGridViewColumn realtorIDColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Realtor ID",
                        Name = "realtorIDColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(realtorIDColumn);
                    DataGridViewColumn realtorNameColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Realtor Name",
                        Name = "realtorNameColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(realtorNameColumn);
                    grid.Columns.AddRange(columnsToAdd.ToArray());

                    grid.AddInternalColumn(realtorIDColumn, new OutlookGridDefaultGroup() { OneItemText = "1 realtor", XXXItemsText = " realtors" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(realtorNameColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 realtor", XXXItemsText = " realtors" }, SortOrder.None, -1, -1);
                    break;
                }

                case EntityTypes.TitleCompany:
                {
                    DataGridViewColumn companyIDColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Company ID",
                        Name = "companyIDColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(companyIDColumn);
                    DataGridViewColumn companyNameColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Company Name",
                        Name = "companyNameColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(companyNameColumn);
                    grid.Columns.AddRange(columnsToAdd.ToArray());

                    grid.AddInternalColumn(companyIDColumn, new OutlookGridDefaultGroup() { OneItemText = "1 title company", XXXItemsText = " title companies" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(companyNameColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 title company", XXXItemsText = " title companies" }, SortOrder.None, -1, -1);
                    break;
                }

                case EntityTypes.Rate:
                {
                    DataGridViewColumn rateIdColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Rate ID",
                        Name = "rateIdColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(rateIdColumn);
                    DataGridViewColumn rateDescriptionColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Description",
                        Name = "rateDescriptionColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(rateDescriptionColumn);
                    DataGridViewColumn rateAmountColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Amount",
                        Name = "rateAmountColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(rateAmountColumn);
                    DataGridViewColumn rateCountyColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Associated County",
                        Name = "rateCountyColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(rateCountyColumn);
                    grid.Columns.AddRange(columnsToAdd.ToArray());

                    grid.AddInternalColumn(rateIdColumn, new OutlookGridDefaultGroup() { OneItemText = "1 rate", XXXItemsText = " rates" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(rateDescriptionColumn, new OutlookGridAlphabeticGroup() { OneItemText = "rate", XXXItemsText = " rates" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(rateAmountColumn, new OutlookGridAlphabeticGroup() { OneItemText = "rate", XXXItemsText = " rates" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(rateCountyColumn, new OutlookGridAlphabeticGroup() { OneItemText = "rate", XXXItemsText = " rates" }, SortOrder.None, -1, -1);
                    break;
                }

                case EntityTypes.Survey:
                {
                    DataGridViewColumn surveyIDColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Survey ID",
                        Name = "surveyIDColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(surveyIDColumn);
                    DataGridViewColumn jobNumberColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Job Number",
                        Name = "jobNumberColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(jobNumberColumn);
                    DataGridViewColumn abstractNumberColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "Abstract",
                        Name = "abstractNumberColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(abstractNumberColumn);
                    DataGridViewColumn acresColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "# of Acres",
                        Name = "acresColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(acresColumn);
                    DataGridViewColumn countyColumn = new KryptonDataGridViewTextBoxColumn
                    {
                        HeaderText = "County",
                        Name = "countyColumn",
                        SortMode = DataGridViewColumnSortMode.Programmatic,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    columnsToAdd.Add(countyColumn);

                    grid.Columns.AddRange(columnsToAdd.ToArray());

                    grid.AddInternalColumn(surveyIDColumn, new OutlookGridDefaultGroup() { OneItemText = "1 survey", XXXItemsText = " surveys" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(jobNumberColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 survey", XXXItemsText = " surveys" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(abstractNumberColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 survey", XXXItemsText = " surveys" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(acresColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 survey", XXXItemsText = " surveys" }, SortOrder.None, -1, -1);
                    grid.AddInternalColumn(countyColumn, new OutlookGridAlphabeticGroup() { OneItemText = "1 survey", XXXItemsText = " surveys" }, SortOrder.None, -1, -1);
                    break;
                }
            }
        }
    }
}
