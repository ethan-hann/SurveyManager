using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using static SurveyManager.utility.Enums;
using SurveyManager.backend.wrappers;
using System;
using SurveyManager.backend.wrappers.SurveyJob;

namespace SurveyManager.utility
{
    /// <summary>
    /// This class that handles various RegEx validation and general format validation.
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
        /// <returns>A list of <see cref="ValidatorError"/>s.</returns>
        public static List<ValidatorError> Email(string emailAddress)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (emailAddress.Length <= 0)
                e.Add(ValidatorError.NoLengthEmailAddress);
            if (!Regex.IsMatch(emailAddress, emailRegExPattern))
                e.Add(ValidatorError.InvalidEmailAddress);
            if (emailAddress.ToLower().Equals("n/a"))
                e.Add(ValidatorError.EmailNA);

            if (emailAddress.ToLower().Equals("do not have info"))
                e.Clear();

            return e;
        }

        /// <summary>
        /// Validates a phone number's format and content. A valid phone number is:
        /// <list type="bullet">
        ///     <item>not empty</item>
        ///     <item>not equal to n/a</item>
        ///     <item>after characters are stripped away, either 10 or 7 digits</item>
        /// </list>
        /// Examples:
        /// <list type="number">
        ///         <item>281-555-5214</item>
        ///         <item>555-5214</item>
        ///         <item>2815555214</item>
        ///         <item>5555214</item>
        ///     </list>
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>A list of <see cref="ValidatorError"/>s.</returns>
        public static List<ValidatorError> PhoneNumber(string phoneNumber)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (phoneNumber.Length <= 0)
                e.Add(ValidatorError.NoLengthPhoneNumber);
            if (phoneNumber.ToLower().Equals("n/a"))
                e.Add(ValidatorError.PhoneNumberNA);

            string newPhone = new string(phoneNumber.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
            if (newPhone.Length != 0)
                e.Add(ValidatorError.IncompletePhoneNumber);

            if (phoneNumber.ToLower().Equals("do not have info"))
                e.Clear();

            return e;
        }

        /// <summary>
        /// Validates a generic name. Ensures the name is not empty and not equal to n/a.
        /// </summary>
        /// <param name="name">The name to verify.</param>
        /// <returns>A list of <see cref="ValidatorError"/>s.</returns>
        public static List<ValidatorError> Name(string name)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (name.Length <= 0)
                e.Add(ValidatorError.NoLengthName);
            if (name.ToLower().Equals("n/a"))
                e.Add(ValidatorError.NameNA);

            if (name.ToLower().Equals("do not have info"))
                e.Clear();

            return e;
        }

        /// <summary>
        /// Validates a company's name. Ensures the name is not empty and not equal to n/a.
        /// </summary>
        /// <param name="name">The company name to verify.</param>
        /// <returns>A list of <see cref="ValidatorError"/>s.</returns>
        public static List<ValidatorError> CompanyName(string name)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (name.Length <= 0)
                e.Add(ValidatorError.NoLengthCompanyName);
            if (name.ToLower().Equals("n/a"))
                e.Add(ValidatorError.CompanyNameNA);

            if (name.ToLower().Equals("do not have info"))
                e.Clear();

            return e;
        }

        /// <summary>
        /// Validates a title company's associate's name. Ensures the name is not empty and not equal to n/a.
        /// </summary>
        /// <param name="name">The associate's name to verify.</param>
        /// <returns>A list of <see cref="ValidatorError"/>s.</returns>
        public static List<ValidatorError> AssociateName(string name)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (name.Length <= 0)
                e.Add(ValidatorError.NoLengthAssociateName);
            if (name.ToLower().Equals("n/a"))
                e.Add(ValidatorError.AssociateNameNA);

            if (name.ToLower().Equals("do not have info"))
                e.Clear();

            return e;
        }

        public static List<ValidatorError> Address(Address a)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if ((a.Street == null || a.Street.Equals(string.Empty)) ||
                (a.City == null || a.City.Equals(string.Empty)) ||
                (a.ZipCode == null || a.ZipCode.Equals(string.Empty)))
            {
                e.Add(ValidatorError.AddressIncomplete);
                return e;
            }

            if (a.Street.ToLower().Equals("n/a"))
                e.Add(ValidatorError.StreetNA);
            if (a.City.ToLower().Equals("n/a"))
                e.Add(ValidatorError.CityNA);

            if (a.Street.Length <= 0 || a.Street.Equals(string.Empty))
                e.Add(ValidatorError.StreetEmpty);
            if (a.City.Length <= 0 || a.City.Equals(string.Empty))
                e.Add(ValidatorError.CityEmpty);
            if (a.ZipCode.Length <= 0 || a.ZipCode.Equals(string.Empty))
                e.Add(ValidatorError.ZipCodeEmpty);

            return e;
        }

        public static List<ValidatorError> File(CFile f)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (f.Contents == null || f.Contents.Length <= 0)
                e.Add(ValidatorError.NoContentsFile);

            if (f.Extension == FileExtension.NONE)
                e.Add(ValidatorError.FileExtensionInvalid);

            if (f.FileName.Length <= 0)
                e.Add(ValidatorError.NoFileNameFile);
            if (f.FileName.ToLower().Equals("n/a"))
                e.Add(ValidatorError.FileNameNA);

            return e;
        }

        public static List<ValidatorError> Information(string jobNumber, string abstractNum, string surveyName, double acres)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (jobNumber.Length <= 0)
                e.Add(ValidatorError.JobNumberEmpty);
            if (jobNumber.ToLower().Equals("n/a"))
                e.Add(ValidatorError.JobNumberNA);

            if (abstractNum.Length <= 0)
                e.Add(ValidatorError.AbstractEmpty);
            if (abstractNum.ToLower().Equals("n/a"))
                e.Add(ValidatorError.AbstractNA);

            if (surveyName.Length <= 0)
                e.Add(ValidatorError.SurveyEmpty);
            if (surveyName.ToLower().Equals("n/a"))
                e.Add(ValidatorError.SurveyNA);

            if (acres.ToString().Length <= 0)
                e.Add(ValidatorError.NumberOfAcresEmpty);
            if (acres < 0)
                e.Add(ValidatorError.NumberOfAcresNegative);

            return e;
        }

        public static List<ValidatorError> Description(string description)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (description.Length <= 0)
                e.Add(ValidatorError.DescriptionEmpty);
            if (description.ToLower().Equals("n/a"))
                e.Add(ValidatorError.DescriptionNA);

            return e;
        }

        public static List<ValidatorError> Subdivision(string subName, string block, string lot, string section)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (subName.Length <= 0)
                e.Add(ValidatorError.SubdivisionNameEmpty);
            if (block.Length <= 0)
                e.Add(ValidatorError.SubdivisionBlockEmpty);
            if (lot.Length <= 0)
                e.Add(ValidatorError.SubdivisionLotEmpty);
            if (section.Length <= 0)
                e.Add(ValidatorError.SubdivisionSectionEmpty);

            return e;
        }

        public static List<ValidatorError> Client(Client c)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            e.AddRange(Name(c.Name));
            e.AddRange(PhoneNumber(c.PhoneNumber));
            e.AddRange(Address(c.ClientAddress));

            return e;
        }

        public static List<ValidatorError> County(County c)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (c == null)
            {
                e.Add(ValidatorError.InvalidCounty);
                return e;
            }

            if (c.CountyName.ToLower().Equals("n/a"))
                e.Add(ValidatorError.CountyNA);

            return e;
        }

        public static List<ValidatorError> Realtor(Realtor r)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            e.AddRange(Name(r.Name));
            e.AddRange(PhoneNumber(r.PhoneNumber));
            e.AddRange(Email(r.Email));
            e.AddRange(CompanyName(r.CompanyName));

            return e;
        }

        public static List<ValidatorError> TitleCompany(TitleCompany t)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            e.AddRange(Name(t.Name));
            e.AddRange(PhoneNumber(t.OfficeNumber));
            e.AddRange(Email(t.AssociateEmail));
            e.AddRange(AssociateName(t.AssociateName));

            return e;
        }

        public static List<ValidatorError> Survey(Survey s)
        {
            List<ValidatorError> e = new List<ValidatorError>();

            if (s.Client == null || Client(s.Client).Count != 0)
                e.Add(ValidatorError.InvalidClient);
            if (s.County == null || County(s.County).Count != 0)
                e.Add(ValidatorError.InvalidCounty);

            e.AddRange(Information(s.JobNumber, s.AbstractNumber, s.SurveyName, s.Acres));

            return e;
        }

    }
}
