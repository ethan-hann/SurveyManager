namespace SurveyManager.forms.surveyMenu.basicInfo
{
    public interface IInfoControl
    {
        public bool SaveInfo();
        public bool IsEdited { get; set; }
    }
}
