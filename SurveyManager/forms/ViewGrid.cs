using ComponentFactory.Krypton.Toolkit;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
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
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms
{
    public partial class ViewGrid : KryptonForm
    {
        private EntityTypes typeOfData;
        private DataTable lastFilterResults;
        private List<OutlookGridRow> rows;

        public EventHandler StatusUpdate;

        public ViewGrid(EntityTypes typeToDisplay, Icon iconToDisplay, string titleText = "")
        {
            InitializeComponent();

            Icon = iconToDisplay;
            if (titleText.Equals(""))
                Text = "View Objects";
            else
                Text = titleText;

            typeOfData = typeToDisplay;
        }

        private void ViewGrid_Load(object sender, EventArgs e)
        {
            propGrid.GetAcceptButton().Click += SaveData;
            propGrid.GetAcceptButton().ToolTipText = "Save the object's properties to the database.";

            dataGrid.RegisterGroupBoxEvents();
            DataGridViewSetup.SetupDGV(dataGrid, typeOfData);
            LoadData();
        }

        private void LoadData()
        {
            StatusUpdate?.Invoke(this, new StatusArgs($"Loading {typeOfData}s..."));
            loadProgressBar.Value = 0;
            loadProgressBar.Visible = true;
            bgWorker.RunWorkerAsync();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lastFilterResults = null;
            LoadData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ArrayList columns;
            AdvancedFilter filter = null;

            switch (typeOfData)
            {
                case EntityTypes.Client:
                {
                    columns = new ArrayList
                    {
                        new DBMap("name", "Name"),
                        new DBMap("phone_number", "Phone #"),
                        new DBMap("email_address", "Email"),
                        new DBMap("fax_number", "Fax #")
                    };

                    filter = new AdvancedFilter("Client", columns, "Find Clients", "", Icon.FromHandle(Resources.client_16x16.GetHicon()));
                    break;
                }
                case EntityTypes.Realtor:
                {
                    columns = new ArrayList
                    {
                        new DBMap("name", "Name"),
                        new DBMap("company_name", "Company Name"),
                        new DBMap("phone_number", "Phone #"),
                        new DBMap("email_address", "Email"),
                        new DBMap("fax_number", "Fax #")
                    };

                    filter = new AdvancedFilter("Realtor", columns, "Find Realtors", "", Icon.FromHandle(Resources.realtor_16x16.GetHicon()));
                    break;
                }
                case EntityTypes.TitleCompany:
                {
                    columns = new ArrayList
                    {
                        new DBMap("name", "Name"),
                        new DBMap("associate_name", "Associate's Name"),
                        new DBMap("associate_email", "Associate's Email"),
                        new DBMap("office_number", "Office #")
                    };

                    filter = new AdvancedFilter("TitleCompany", columns, "Find Title Companies", "", Icon.FromHandle(Resources.title_company_16x16.GetHicon()));
                    break;
                }
                case EntityTypes.Survey:
                {
                    columns = new ArrayList
                    {
                        new DBMap("job_number", "Job #"),
                        new DBMap("client_id", "Client ID"),
                        new DBMap("description", "Description"),
                        new DBMap("subdivision", "Subdivision"),
                        new DBMap("lot", "Lot #"),
                        new DBMap("block", "Block #"),
                        new DBMap("section", "Section #"),
                        new DBMap("county_id", "County ID"),
                        new DBMap("acres", "# of Acres"),
                        new DBMap("realtor_id", "Realtor ID"),
                        new DBMap("title_company_id", "Title Company ID"),
                    };

                    filter = new AdvancedFilter("Survey", columns, "Find Surveys", "", Icon.FromHandle(Resources.surveying_16x16.GetHicon()));
                    break;
                }
            }

            if (filter != null)
            {
                filter.FilterDone += ProcessSearch;
                filter.Show();
            }
        }

        private void ProcessSearch(object sender, EventArgs e)
        {
            if (e is FilterDoneEventArgs args)
            {
                lastFilterResults = args.Results;
                LoadData();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (typeOfData)
            {
                case EntityTypes.Client:
                {
                    PopulateClientGrid(LoadClients());
                    break;
                }
                case EntityTypes.Realtor:
                {
                    PopulateRealtorGrid(LoadRealtors());
                    break;
                }
                case EntityTypes.TitleCompany:
                {
                    PopulateTitleCompanyGrid(LoadTitleCompanies());
                    break;
                }
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadProgressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Disposing && !IsDisposed)
            {
                if (typeOfData == EntityTypes.TitleCompany)
                    StatusUpdate?.Invoke(this, new StatusArgs($"Title Companies loaded."));
                else
                    StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData}s loaded."));

                dataGrid.SuspendLayout();
                dataGrid.ClearInternalRows();
                dataGrid.ResumeLayout();
                dataGrid.AssignRows(rows);
                dataGrid.ForceRefreshGroupBox();
                dataGrid.Fill();

                if (dataGrid.Rows.Count > 0)
                {
                    DataGridViewRow r = dataGrid.Rows[0];
                    propGrid.SelectedObject = r.Tag;
                }

                loadProgressBar.Visible = false;
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData} loading cancelled."));
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            DatabaseWrapper obj = (DatabaseWrapper)propGrid.SelectedObject;
            DatabaseError error = obj.Update();
            switch (error)
            {
                case DatabaseError.NoError:
                    StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData}, {obj}, updated successfully!"));
                    break;
                default:
                    CMessageBox.Show("Object could not be updated; check your input and try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    break;
            }
        }

        #region Client
        private List<Client> LoadClients()
        {
            List<Client> clients = new List<Client>();
            if (lastFilterResults == null)
            {
                clients = Database.GetClients();
            }
            else
            { 
                foreach (DataRow dataRow in lastFilterResults.Rows)
                {
                    clients.Add(ProcessDataTable.GetClient(dataRow));
                }
                lastFilterResults = null;
            }
            return clients;
        }

        private void PopulateClientGrid(List<Client> clients)
        {
            OutlookGridRow row;
            rows = new List<OutlookGridRow>();

            foreach (Client c in clients)
            {
                row = new OutlookGridRow();
                row.CreateCells(dataGrid, new object[] {
                    c.ID,
                    c.Name
                });
                row.Tag = c;
                rows.Add(row);
            }
        }
        #endregion

        #region Realtor
        private List<Realtor> LoadRealtors()
        {
            List<Realtor> realtors = new List<Realtor>();
            if (lastFilterResults == null)
            {
                realtors = Database.GetRealtors();
            }
            else
            {
                foreach (DataRow dataRow in lastFilterResults.Rows)
                {
                    realtors.Add(ProcessDataTable.GetRealtor(dataRow));
                }
                lastFilterResults = null;
            }
            return realtors;
        }

        private void PopulateRealtorGrid(List<Realtor> realtors)
        {
            OutlookGridRow row;
            rows = new List<OutlookGridRow>();

            foreach (Realtor r in realtors)
            {
                row = new OutlookGridRow();
                row.CreateCells(dataGrid, new object[] {
                    r.ID,
                    r.Name
                });
                row.Tag = r;
                rows.Add(row);
            }
        }
        #endregion

        #region Title Company
        private List<TitleCompany> LoadTitleCompanies()
        {
            List<TitleCompany> companies = new List<TitleCompany>();
            if (lastFilterResults == null)
            {
                companies = Database.GetTitleCompanies();
            }
            else
            {
                foreach (DataRow dataRow in lastFilterResults.Rows)
                {
                    companies.Add(ProcessDataTable.GetTitleCompany(dataRow));
                }
                lastFilterResults = null;
            }
            return companies;
        }

        private void PopulateTitleCompanyGrid(List<TitleCompany> companies)
        {
            OutlookGridRow row;
            rows = new List<OutlookGridRow>();

            foreach (TitleCompany c in companies)
            {
                row = new OutlookGridRow();
                row.CreateCells(dataGrid, new object[] {
                    c.ID,
                    c.Name
                });
                row.Tag = c;
                rows.Add(row);
            }
        }
        #endregion

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dataGrid.Rows[e.RowIndex];
                propGrid.SelectedObject = r.Tag;
            }
        }
    }
}
