using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace SurveyManager.forms.dialogs
{
    public partial class DeleteMessageForm : KryptonForm
    {
        internal DeleteMessageForm() => InitializeComponent();

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
