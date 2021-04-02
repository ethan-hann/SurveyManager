using ComponentFactory.Krypton.Toolkit;
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

        }

        #region Survey Menu
        #endregion

        #region Client Menu
        #endregion

        #region Realtor Menu
        #endregion

        #region Title Company Menu

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newClientBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
