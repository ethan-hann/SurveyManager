using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SurveyManager.forms.surveyMenu
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class UploadFileEditor : UITypeEditor
    {
        public UploadFileEditor() 
        {
            
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc =
                (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc == null)
            {
                return null;
            }

            // Displays a file upload dialog
            UploadFile form = new UploadFile();
            if (edSvc.ShowDialog(form) == System.Windows.Forms.DialogResult.OK)
            {
                return form.GetFiles();
            }

            // If OK was not pressed, return the original value
            return value;
        }
    }
}
