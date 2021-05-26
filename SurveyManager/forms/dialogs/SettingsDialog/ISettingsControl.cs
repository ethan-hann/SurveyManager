using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.dialogs.SettingsDialog
{
    /// <summary>
    /// Interface that is implemented by any user control that is considered to be a Settings screen.
    /// </summary>
    public interface ISettingsControl
    {
        public delegate void ChangeStatusText(StatusArgs args);

        public event ChangeStatusText HelpTextChanged;
        /// <summary>
        /// The method that should be implemented to define how to save the control's settings.
        /// </summary>
        public void SaveSettings();

        /// <summary>
        /// The method that should be implemented to define how to reset the control's settings to defaults.
        /// </summary>
        public void ToDefaults();

        /// <summary>
        /// The unique name for this setting control.
        /// </summary>
        public string UniqueName { get; }

        /// <summary>
        /// Indicates if the control's settings have been unchanged and thus do not need saving.
        /// </summary>
        public bool Unchanged { get; set; }
    }
}
