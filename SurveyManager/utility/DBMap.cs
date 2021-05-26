namespace SurveyManager.utility
{
    /// <summary>
    /// Maps an internal database column to its external display member.
    /// </summary>
    public class DBMap
    {
        /// <summary>
        /// The column name as it appears in the database.
        /// </summary>
        public string InternalField { get; set; }
        /// <summary>
        /// The display name that should appear in things like FilterDialogs.
        /// </summary>
        public string DisplayField { get; set; }

        /// <summary>
        /// Create a new <see cref="DBMap"/> object with the required information.
        /// </summary>
        /// <param name="internalField">The column name as it appears in the database.</param>
        /// <param name="displayField">The display name that should appear in things like FilterDialogs.</param>
        public DBMap(string internalField, string displayField)
        {
            InternalField = internalField;
            DisplayField = displayField;
        }

        /// <summary>
        /// Override for <see cref="object.ToString()"/> that returns this class's <see cref="DisplayField"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DisplayField;
        }
    }
}
