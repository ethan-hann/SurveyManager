using ComponentFactory.Krypton.Navigator;
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
            pgOne.Tag = false;

            SqlControl.QueryRan += UpdateTabName;
        }

        private void UpdateTabName(object sender, EventArgs e)
        {
            if (e is QueryRanArgs args)
            {
                //If the page's title has not been manually changed by the user, change it to the table name.
                if (!(bool)navigator.SelectedPage.Tag)
                    navigator.SelectedPage.Text = args.TableName;
            }
        }

        private void btnAddNewPage_Click(object sender, EventArgs e)
        {
            InsertNewPage();
        }

        private void InsertNewPage()
        {
            KryptonPage newPage = new KryptonPage
            {
                Text = $"Query {navigator.Pages.Count}"
            };
            newPage.Controls.Add(new SqlControl()
            {
                Dock = DockStyle.Fill
            });

            ButtonSpecAny newButton = new ButtonSpecAny()
            {
                Image = Resources.add_16x16,
            };
            newButton.Click += NewPageClick;
            newPage.ButtonSpecs.Add(newButton);
            newPage.KryptonContextMenu = rightClickContext;
            newPage.Tag = false;

            navigator.Pages.Insert(navigator.Pages.Count, newPage);
            navigator.SelectedPage = newPage;

            //Remove add button from the previous page.
            navigator.Pages[navigator.Pages.Count - 2].ButtonSpecs.Clear();

            if (navigator.Pages.Count == 2)
                navigator.Button.CloseButtonDisplay = ButtonDisplay.ShowEnabled;
        }

        private void NewPageClick(object sender, EventArgs e)
        {
            InsertNewPage();
        }

        private void navigator_CloseAction(object sender, CloseActionEventArgs e)
        {
            ButtonSpecAny newButton = new ButtonSpecAny()
            {
                Image = Resources.add_16x16,
            };
            newButton.Click += NewPageClick;

            if (e.Index == 1)
            {
                navigator.Button.CloseButtonDisplay = ButtonDisplay.Hide;
                pgOne.ButtonSpecs.Add(newButton);
            }
            else
            {
                navigator.Pages[e.Index - 1].ButtonSpecs.Add(newButton);
            }
        }
        private void rightClickContext_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                string newText = KryptonInputBox.Show("Enter tab name:");
                navigator.SelectedPage.Text = newText;
                navigator.SelectedPage.Tag = true;
            }
        }
    }
}
