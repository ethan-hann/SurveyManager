using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.utility;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.databaseMenu
{
    public partial class DBConnection : KryptonForm
    {
        private int errorCode;
        private bool isConnected;

        /// <summary>
        /// When this event is fired, a <see cref="DBArgs"/> object that represents the error code of the DBConnection attempt, is returned.
        /// </summary>
        public event EventHandler DatabaseConnectFinished;

        public DBConnection()
        {
            InitializeComponent();

            btnTestConnection.Click += TestConnection;
            btnFinish.Click += Finish;
        }

        private void DBConnection_Load(object sender, EventArgs e)
        {
            txtServer.Text = Database.Server;
            txtPort.Text = Database.Port;
            txtDB.Text = Database.DB;
            txtUsername.Text = Database.Username;
            txtPassword.Text = Database.Password;

            tlpStatus.Visible = false;
            progressBarLoad.Value = 0;
        }

        private void TestConnection(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                progressBarLoad.Value = 0;
                tlpStatus.Visible = true;
                progressBarLoad.Visible = true;
                bgWorker.RunWorkerAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Database.Server = txtServer.Text;
            txtStatus.Text = "Checking Server...";
            bgWorker.ReportProgress(10);
            Thread.Sleep(500);

            Database.Port = txtPort.Text;
            txtStatus.Text = "Checking Port...";
            bgWorker.ReportProgress(20);
            Thread.Sleep(500);

            Database.DB = txtDB.Text;
            txtStatus.Text = "Checking Database...";
            bgWorker.ReportProgress(30);
            Thread.Sleep(500);

            Database.Username = txtUsername.Text;
            txtStatus.Text = "Checking Username...";
            bgWorker.ReportProgress(40);
            Thread.Sleep(500);

            Database.Password = txtPassword.Text;
            txtStatus.Text = "Checking Password...";
            bgWorker.ReportProgress(50);
            Thread.Sleep(500);

            Database.SaveConnectionString();
            txtStatus.Text = "Checking Connection.";
            bgWorker.ReportProgress(60);
            Thread.Sleep(500);

            txtStatus.Text = "Checking Connection..";
            bgWorker.ReportProgress(70);
            Thread.Sleep(500);

            txtStatus.Text = "Checking Connection...";
            bgWorker.ReportProgress(80);
            Thread.Sleep(500);

            errorCode = Database.CheckConnection();

            txtStatus.Text = "Checking Connection.";
            bgWorker.ReportProgress(90);
            Thread.Sleep(500);

            txtStatus.Text = "Checking Connection..";
            bgWorker.ReportProgress(100);
            Thread.Sleep(500);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarLoad.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isConnected = errorCode == -1;

            if (isConnected)
            {
                progressBarLoad.Visible = false;
                txtStatus.Text = "Connected!";
                btnFinish.Visible = true;
                RuntimeVars.Instance.DatabaseConnected = true;
            }
            else
            {
                txtStatus.Text = "Not Connected to Server!";
                btnFinish.Visible = false;
                RuntimeVars.Instance.DatabaseConnected = false;
            }
        }

        private void Finish(object sender, EventArgs e)
        {
            DatabaseConnectFinished?.Invoke(this, new DBArgs(errorCode));

            if (isConnected)
            {
                Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (RuntimeVars.Instance.NumberOfDBConnectionFormsOpen > 0)
                RuntimeVars.Instance.NumberOfDBConnectionFormsOpen -= 1;

            base.OnFormClosed(e);
        }
    }
}
