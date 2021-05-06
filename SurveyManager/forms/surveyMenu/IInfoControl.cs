using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.forms.surveyMenu
{
    public interface IInfoControl
    {
        public bool SaveInfo();
        public bool IsEdited { get; set; }
    }
}
