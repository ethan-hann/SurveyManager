namespace SurveyManager.forms.surveyMenu
{
    public interface IInfoControl
    {
        public bool SaveInfo();
        public bool IsEdited { get; set; }
    }
}
