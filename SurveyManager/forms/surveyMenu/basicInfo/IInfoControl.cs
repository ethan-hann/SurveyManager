using System.Collections.Generic;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu.basicInfo
{
    public interface IInfoControl
    {
        public List<ValidatorError> SaveInfo();
        public bool IsEdited { get; set; }
    }
}
