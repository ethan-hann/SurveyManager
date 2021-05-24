using ComponentFactory.Krypton.Navigator;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.CustomColumns;
using MimeKit;
using SurveyManager.Properties;
using SurveyManager.utility;
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

namespace SurveyManager.forms.userControls
{
    public partial class ViewEmailListCtl : UserControl
    {
        private List<IEmailMessageControl> messages;
        private List<OutlookGridRow> rows;

        public EventHandler StatusUpdate;


        public ViewEmailListCtl(List<IEmailMessageControl> messages)
        {
            InitializeComponent();

            this.messages = messages;
        }

        private void ViewEmailListCtl_Load(object sender, EventArgs e)
        {
            headerGroup.ValuesPrimary.Description = $"1 - 50 of {messages.Count}";
            emailGrid.RegisterGroupBoxEvents();
            LoadData();
        }

        private void btnMoreOptions_Click(object sender, EventArgs e)
        {
            moreOptionsContext.Show(btnMoreOptions);
        }

        private void LoadData()
        {
            if (!loadMailBGWorker.IsBusy)
            {
                StatusUpdate?.Invoke(this, new StatusArgs("Loading emails..."));
                loadMailBGWorker.RunWorkerAsync();
            }
        }

        private void loadMailBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OutlookGridRow row;
            rows = new List<OutlookGridRow>();

            int i = 0;
            foreach (MimeMessage msg in messages)
            {
                row = new OutlookGridRow();
                row.CreateCells(emailGrid, new object[] {
                    new KryptonDataGridViewTextAndImageCell()
                    {
                        Image = Resources.view_16x16,
                        Value = "Unread",
                        ValueType = typeof(string)
                    },
                    msg.From.Mailboxes.First().Name,
                    msg.Subject,
                    msg.Date.DateTime.ToShortDateString()
                });

                row.Tag = msg;
                rows.Add(row);
                loadMailBGWorker.ReportProgress(i, msg);
                i++;
            }
        }

        private void loadMailBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusUpdate?.Invoke(this, new StatusArgs($"Retrieving message {e.ProgressPercentage} of {messages.Count}"));
            emailGrid.SuspendLayout();
            emailGrid.ClearInternalRows();
            emailGrid.ResumeLayout();
            emailGrid.AssignRows(rows);
            emailGrid.ForceRefreshGroupBox();
            emailGrid.Fill();
        }

        private void loadMailBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusUpdate?.Invoke(this, new StatusArgs($"Mailbox up-to-date!"));
            emailGrid.SuspendLayout();
            emailGrid.ClearInternalRows();
            emailGrid.ResumeLayout();
            emailGrid.AssignRows(rows);
            emailGrid.ForceRefreshGroupBox();
            emailGrid.Fill();
        }

        private void emailGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MimeMessage msg = emailGrid.Rows[e.RowIndex].Tag as MimeMessage;
                if (msg != null)
                {
                    ViewMessageCtl view = new ViewMessageCtl(msg, msg.GetHashCode());
                    KryptonPage floatingMessage = new KryptonPage()
                    {
                        Text = msg.Subject,
                        UniqueName = msg.Subject,
                        TextTitle = msg.Subject
                    };
                    view.Dock = DockStyle.Fill;
                    floatingMessage.Controls.Add(view);
                    if (!RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.ContainsPage(floatingMessage))
                    {
                        RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.AddFloatingWindow("Floating", new KryptonPage[] { floatingMessage });
                    }
                    else
                    {
                        RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.RemovePage(floatingMessage, true);
                        RuntimeVars.Instance.MainForm.DockingWorkspace.DockingManager.AddFloatingWindow("Floating", new KryptonPage[] { floatingMessage });
                    }
                }
            }
        }
    }
}
