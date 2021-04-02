using ComponentFactory.Krypton.Toolkit;
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

namespace SurveyManager.forms.databaseMenu
{
    public partial class DBConnection : KryptonForm
    {
        public DBConnection()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (RuntimeVars.Instance.NumberOfDBConnectionFormsOpen > 0)
                RuntimeVars.Instance.NumberOfDBConnectionFormsOpen -= 1;

            base.OnFormClosed(e);
        }
    }
}
