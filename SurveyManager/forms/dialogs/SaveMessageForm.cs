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

namespace SurveyManager.forms.dialogs
{
    internal partial class SaveMessageForm : KryptonForm
    {
        internal SaveMessageForm() => InitializeComponent();

        private void btnYes_Click(object sender, EventArgs e) =>
            DialogResult = DialogResult.Yes;

        private void btnNo_Click(object sender, EventArgs e) =>
            DialogResult = DialogResult.No;

        private void btnCancel_Click(object sender, EventArgs e) =>
            DialogResult = DialogResult.Cancel;

        private void btnOK_Click(object sender, EventArgs e) =>
            DialogResult = DialogResult.OK;
    }
}
