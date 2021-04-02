using ComponentFactory.Krypton.Toolkit;
using SurveyManager.forms.clientMenu;
using SurveyManager.forms.databaseMenu;
using SurveyManager.forms.dialogs;
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

namespace SurveyManager
{
    public partial class MainForm : KryptonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatusDate.Text = DateTime.Now.ToString();

            clockTimer.Start();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblStatusDate.Text = DateTime.Now.ToString();
        }

        #region File Menu
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Survey Menu
        #endregion

        #region Client Menu
        private void newClientBtn_Click(object sender, EventArgs e)
        {
            NewClient ncForm = new NewClient();
            ncForm.MdiParent = this;
            ncForm.Show();
        }
        #endregion

        #region Realtor Menu
        #endregion

        #region Title Company Menu
        #endregion

        #region Database Menu
        private void dbConnectionBtn_Click(object sender, EventArgs e)
        {
            if (RuntimeVars.Instance.NumberOfDBConnectionFormsOpen == 0)
            {
                DBConnection dbForm = new DBConnection();
                dbForm.MdiParent = this;
                RuntimeVars.Instance.NumberOfDBConnectionFormsOpen++;
                dbForm.Show();
            }
            else
            {
                CMessageBox.Show("Only 1 connection window can be opened at a time!", "Error", MessageBoxButtons.OK, Resources.error_64x64);
            }
            
        }
        #endregion
    }
}
