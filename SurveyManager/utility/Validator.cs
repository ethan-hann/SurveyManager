using System.Text.RegularExpressions;

namespace SurveyManager.utility
{
    /// <summary>
    /// Class that handles various RegEx validation.
    /// </summary>
    public class Validator
    {
        private static readonly string emailRegExPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        /// <summary>
        /// Validates an e-mail address against an email regular expression pattern.
        /// </summary>
        /// <param name="emailAddress">The email address to validate.</param>
        /// <returns><c>True</c> if the email is valid; <c>False</c> otherwise.</returns>
        public static bool ValidateEmail(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, emailRegExPattern);
        }
    }
}
