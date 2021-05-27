using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Data;
using System.Drawing;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu
{
    public partial class SearchResults : KryptonForm
    {
        private DataTable results;
        private EntityTypes typeOfData;

        public EventHandler ObjectSelected;
        public EventHandler StatusUpdate;

        public SearchResults(DataTable results, EntityTypes typeOfData)
        {
            InitializeComponent();

            this.results = results;
            this.typeOfData = typeOfData;
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {
            propGrid.GetAcceptButton().Text = $"Select {typeOfData}";
            propGrid.GetClearButton().Visible = false;
            propGrid.GetAcceptButton().Click += SelectObject;

            lbObjects.DisplayMember = "ToString";

            switch (typeOfData)
            {
                case EntityTypes.Client:
                {
                    Text = "Client Results";
                    Icon = Icon.FromHandle(Resources.client_16x16.GetHicon());
                    break;
                }
                case EntityTypes.Realtor:
                {
                    Text = "Realtor Results";
                    Icon = Icon.FromHandle(Resources.realtor_16x16.GetHicon());
                    break;
                }
                case EntityTypes.TitleCompany:
                {
                    Text = "Title Company Results";
                    Icon = Icon.FromHandle(Resources.title_company_16x16.GetHicon());
                    break;
                }
            }

            PopulateListBox();
        }

        private void SelectObject(object sender, EventArgs e)
        {
            IDatabaseWrapper obj = propGrid.SelectedObject as IDatabaseWrapper;
            if (obj != null)
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"{typeOfData} {obj} selected."));
                ObjectSelected?.Invoke(this, new DBObjectArgs(obj, typeOfData));
                Close();
            }
        }

        private void PopulateListBox()
        {
            switch (typeOfData)
            {
                case EntityTypes.Client:
                {
                    PopulateClients();
                    break;
                }
                case EntityTypes.Realtor:
                {
                    PopulateRealtors();
                    break;
                }
                case EntityTypes.TitleCompany:
                {
                    PopulateTitleCompanies();
                    break;
                }
                default:
                {
                    break;
                }
            }

            if (lbObjects.Items.Count > 0)
            {
                lbObjects.SelectedIndex = 0;
                propGrid.SelectedObject = lbObjects.Items[0];
            }
        }

        private void PopulateClients()
        {
            foreach (DataRow row in results.Rows)
            {
                lbObjects.Items.Add(ProcessDataTable.GetClient(row));
            }
        }

        private void PopulateRealtors()
        {
            foreach (DataRow row in results.Rows)
            {
                lbObjects.Items.Add(ProcessDataTable.GetRealtor(row));
            }
        }

        private void PopulateTitleCompanies()
        {
            foreach (DataRow row in results.Rows)
            {
                lbObjects.Items.Add(ProcessDataTable.GetTitleCompany(row));
            }
        }

        private void lbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex >= 0)
                propGrid.SelectedObject = lbObjects.Items[lbObjects.SelectedIndex];
        }
    }
}
