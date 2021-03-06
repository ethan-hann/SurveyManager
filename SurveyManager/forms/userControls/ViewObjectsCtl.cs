using ComponentFactory.Krypton.Navigator;
using Ionic.Zip;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.forms.surveyMenu;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.userControls
{
    public partial class ViewObjectsCtl : UserControl
    {
        private EntityTypes typeOfData;
        private DataTable lastFilterResults;
        private List<OutlookGridRow> rows;
        private FilterDoneEventArgs currentFilterArgs;

        public EventHandler StatusUpdate;

        public ViewObjectsCtl(EntityTypes typeToDisplay, FilterDoneEventArgs args = null)
        {
            InitializeComponent();

            typeOfData = typeToDisplay;

            if (args != null)
            {
                lastFilterResults = args.Results;
                currentFilterArgs = args;
            }
        }

        private void ViewObjects_Load(object sender, EventArgs e)
        {
            propGrid.GetAcceptButton().Click += SaveData;
            propGrid.GetAcceptButton().ToolTipText = "Save the object's properties to the database.";
            propGrid.GetClearButton().Visible = false;
            if (typeOfData == EntityTypes.Survey)
            {
                propGrid.GetUploadFilesButton().Click += UploadFiles;
                propGrid.GetDownloadFilesButton().Click += DownloadFiles;
                propGrid.GetOpenJobButton().Click += OpenJob;
                propGrid.GetUploadFilesButton().Visible = true;
                propGrid.GetDownloadFilesButton().Visible = true;
                propGrid.GetOpenJobButton().Visible = true;
            }

            dataGrid.RegisterGroupBoxEvents();
            DataGridViewSetup.SetupDGV(dataGrid, typeOfData);
            LoadData();
        }

        private void OpenJob(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 1)
            {
                if (dataGrid.SelectedRows[0].Tag != null)
                {
                    if (JobHandler.Instance.OpenJob(dataGrid.SelectedRows[0].Tag as Survey))
                    {
                        RuntimeVars.Instance.MainForm.ChangeTitleText("[JOB# " + (dataGrid.SelectedRows[0].Tag as Survey).JobNumber + "]");
                        JobHandler.Instance.AddSurveyToRecentJobs();
                    }
                }
            }
        }

        private void DownloadFiles(object sender, EventArgs e)
        {
            if (typeOfData != EntityTypes.Survey)
                return;

            if (!(propGrid.SelectedObject as Survey).HasFiles)
            {
                CMessageBox.Show("No files associated with this survey.", "Nothing to Download", MessageBoxButtons.OK, Resources.warning_64x64);
                return;
            }

            using (ZipFile zip = new ZipFile())
            {
                foreach (CFile file in (propGrid.SelectedObject as Survey).Files)
                {
                    zip.AddEntry(file.FullFileName, new MemoryStream(file.Contents));
                }

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    zip.Save(saveDialog.FileName);
                }
            }
        }

        private void UploadFiles(object sender, EventArgs e)
        {
            if (typeOfData != EntityTypes.Survey)
                return;

            UploadFile uploadDialog = new UploadFile((propGrid.SelectedObject as Survey).Files);
            uploadDialog.StatusUpdate += RuntimeVars.Instance.MainForm.ChangeStatusText;
            uploadDialog.FileUploadDone += SetFiles;

            uploadDialog.Show();
        }

        private void SetFiles(object sender, EventArgs e)
        {
            if (e is FileUploadDoneArgs args)
            {
                (propGrid.SelectedObject as Survey).ClearFiles();
                (propGrid.SelectedObject as Survey).AddFiles(args.Files);
                propGrid.Update();
            }
        }

        private void UpdateTabName(string newTitle)
        {
            KryptonPage parentPage = Parent as KryptonPage;
            if (parentPage != null)
            {
                parentPage.Text = newTitle;
                parentPage.TextTitle = parentPage.Text;
                parentPage.Invalidate();
                parentPage.Update();
            }
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
                case EntityTypes.Rate:
                {
                    columns = new ArrayList
                    {
                        new DBMap("description", "Description"),
                        new DBMap("amount", "Amount"),
                        new DBMap("time_unit", "Time Unit")
                    };

                    filter = new AdvancedFilter("Rates", columns, "Find Rates");
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
                        new DBMap("county_id", "County"),
                        new DBMap("acres", "Acres"),
                        new DBMap("realtor_id", "Realtor ID"),
                        new DBMap("title_company_id", "Title Company ID")
                    }; //TODO: combine all tables to search for surveys!

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
                currentFilterArgs = args;
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
                case EntityTypes.Rate:
                {
                    PopulateRateGrid(LoadRates());
                    break;
                }
                case EntityTypes.Survey:
                {
                    PopulateSurveyGrid(LoadSurveys());
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
                if (lastFilterResults != null)
                {
                    int rowCount = currentFilterArgs.Results.Rows.Count;
                    if (typeOfData == EntityTypes.TitleCompany)
                    {
                        UpdateTabName("Title Companies" + $" [Filtered: {(rowCount > 1 ? $"{rowCount} rows" : $"{rowCount} row")}]");
                        StatusUpdate?.Invoke(this, new StatusArgs($"Found {currentFilterArgs.Results.Rows.Count} title companies " + "matching search criteria: " + currentFilterArgs.Query));
                    }
                    else
                    {
                        UpdateTabName(typeOfData.ToString() + $" [Filtered: {(rowCount > 1 ? $"{rowCount} rows" : $"{rowCount} row")}]");
                        StatusUpdate?.Invoke(this, new StatusArgs($"Found {currentFilterArgs.Results.Rows.Count} {typeOfData}s " + "matching search criteria: " + currentFilterArgs.Query));
                    }
                }
                else
                {
                    if (typeOfData == EntityTypes.TitleCompany)
                    {
                        UpdateTabName("Title Companies");
                        StatusUpdate?.Invoke(this, new StatusArgs($"Title Companies loaded."));
                    }
                    else
                    {
                        UpdateTabName(typeOfData.ToString() + "s");
                        StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData}s loaded."));
                    }
                }

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
                    propGrid.Invalidate();
                    propGrid.Update();
                }

                loadProgressBar.Visible = false;
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData} loading cancelled."));
            }
        }

        DatabaseWrapper objToDelete;

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 1)
            {
                string confirmText = "The following is what will be deleted based on the type of object the grid is displaying:\n" +
                "Surveys       ->\tdelete the survey record, all associated files, and all associated billing line items.\n\n" +
                "Clients       ->\tdelete the client record and the associated address record; can only delete if the client is not referenced anywhere else.\n\n" +
                "Realtors      ->\tdelete the realtor record only; can only delete if the realtor is not referenced anywhere else.\n\n" +
                "Title Company ->\tdelete the title company record only; can only delete if the title company is not referenced anywhere else.\n\n";

                DialogResult confirm = CRichMsgBox.Show("Are you sure you want to delete this record?\nTHIS IS A DESTRUCTIVE OPERATION AND CANNOT BE REVERSED!", "Confirm", confirmText, MessageBoxButtons.YesNo, Resources.warning_64x64);
                if (confirm == DialogResult.Yes)
                {
                    objToDelete = dataGrid.SelectedRows[0].Tag as DatabaseWrapper;
                    StatusUpdate?.Invoke(this, new StatusArgs($"Attempting to delete {typeOfData} {objToDelete}..."));
                    loadProgressBar.Value = 0;
                    loadProgressBar.Visible = true;
                    deleteBgWorker.RunWorkerAsync();
                }
                else
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Canceled deletion of {typeOfData} {objToDelete}..."));
                }
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs("No row selected; nothing to delete."));
            }
        }

        DatabaseError deleteError;
        private void deleteBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            deleteError = objToDelete.Delete();

        }

        private void deleteBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadProgressBar.Value = e.ProgressPercentage;
        }

        private void deleteBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Disposing && !IsDisposed)
            {
                if (deleteError == DatabaseError.NoError)
                {
                    LoadData();
                    return;
                }
                else
                {
                    CMessageBox.Show("This object can not be deleted. Most likely it is referenced elsewhere or the database connection was interupted.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    loadProgressBar.Visible = false;
                    StatusUpdate?.Invoke(this, new StatusArgs($"Could not perform deletion on {typeOfData} {objToDelete}."));
                    return;
                }
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData} deletion canceled."));
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            if (propGrid.SelectedObject == null)
                return;

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

        #region Rates
        private List<Rate> LoadRates()
        {
            List<Rate> rates = new List<Rate>();
            if (lastFilterResults == null)
            {
                rates = Database.GetRates();
            }
            else
            {
                foreach (DataRow dataRow in lastFilterResults.Rows)
                {
                    rates.Add(ProcessDataTable.GetRate(dataRow));
                }
            }
            return rates;
        }

        private void PopulateRateGrid(List<Rate> rates)
        {
            OutlookGridRow row;
            rows = new List<OutlookGridRow>();

            foreach (Rate r in rates)
            {
                row = new OutlookGridRow();
                row.CreateCells(dataGrid, new object[] {
                    r.ID,
                    r.Description,
                    $"{r.Amount.ToString("C2")} / {r.TimeUnit}"
                });
                row.Tag = r;
                rows.Add(row);
            }
        }
        #endregion

        #region Survey
        private List<Survey> LoadSurveys()
        {
            List<Survey> surveys = new List<Survey>();
            if (lastFilterResults == null)
            {
                surveys = Database.GetSurveys();
            }
            else
            {
                foreach (DataRow dataRow in lastFilterResults.Rows)
                {
                    surveys.Add(ProcessDataTable.GetSurvey(dataRow));
                }
            }
            return surveys;
        }

        private void PopulateSurveyGrid(List<Survey> surveys)
        {
            OutlookGridRow row;
            rows = new List<OutlookGridRow>();

            foreach (Survey c in surveys)
            {
                row = new OutlookGridRow();
                row.CreateCells(dataGrid, new object[] {
                    c.ID,
                    c.JobNumber,
                    c.AbstractNumber,
                    c.Acres,
                    c.County.CountyName,
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
