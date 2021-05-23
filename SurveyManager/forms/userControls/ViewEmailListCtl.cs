using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyManager.forms.userControls
{
    public partial class ViewEmailListCtl : UserControl
    {
        public ViewEmailListCtl()
        {
            InitializeComponent();
        }

        private void btnMoreOptions_Click(object sender, EventArgs e)
        {
            moreOptionsContext.Show(btnMoreOptions);
        }
    }
}
