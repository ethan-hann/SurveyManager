using SurveyManager.utility;
using System;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// This class represents a Realtor object. A realtor is associated with a <see cref="SurveyJob.Survey"/>.
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Realtor : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// The full name of the realtor.
        /// </summary>
        [Category("Realtor Information")]
        [Description("The full name of the realtor.")]
        [Browsable(true)]
        [DisplayName("Realtor Name")]
        public string Name { get; set; } = "N/A";

        /// <summary>
        /// The company name where the realtor works.
        /// </summary>
        [Category("Realtor Information")]
        [Description("The realtor's company's name.")]
        [Browsable(true)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; } = "N/A";

        /// <summary>
        /// The email address for the realtor.
        /// </summary>
        [Category("Realtor Information")]
        [Description("The email address for the realtor.")]
        [Browsable(true)]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "N/A";

        /// <summary>
        /// The phone number for the realtor.
        /// </summary>
        [Category("Realtor Information")]
        [Description("The phone number for the realtor.")]
        [Browsable(true)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = "N/A";

        /// <summary>
        /// The fax number, if any, for the realtor.
        /// </summary>
        [Category("Realtor Information")]
        [Description("The fax number, if any, for the realtor.")]
        [Browsable(true)]
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; } = "N/A";

        /// <summary>
        /// Get a value representing whether this Realtor is valid or not.
        /// <para>A valid Realtor is one whose name, email, and company name is not equal to "N/A" or empty and valid and whose phone number is 10 or 7 characters and not "N/A".</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidRealtor
        {
            get
            {
                return (!Name.ToLower().Equals("n/a") && Name.Length > 0) &&
                ((PhoneNumber.Length == 10 || PhoneNumber.Length == 7) && !PhoneNumber.ToLower().Equals("n/a")) &&
                (!Email.ToLower().Equals("n/a") && Validator.ValidateEmail(Email)) &&
                (!CompanyName.ToLower().Equals("n/a") && CompanyName.Length > 0);
            }
        }

        public Realtor() { }

        public Realtor(int iD, string name, string companyName, string email, string phoneNumber, string faxNumber)
        {
            ID = iD;
            Name = name;
            CompanyName = companyName;
            Email = email;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
        }

        public Realtor(string name, string companyName, string email, string phoneNumber, string faxNumber)
        {
            Name = name;
            CompanyName = companyName;
            Email = email;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
        }

        public override string ToString()
        {
            if (IsValidRealtor)
                return $"{Name} with {CompanyName}";
            else
                return "Invalid Realtor (...)";
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidRealtor)
            {
                if (ID == 0)
                {
                    ID = Database.InsertRealtor(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.RealtorInsert;
                }
                else
                {
                    e = Database.UpdateRealtor(this) ? DatabaseError.NoError : DatabaseError.RealtorUpdate;
                }
                return e;
            }
            return DatabaseError.RealtorIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteRealtor(this) ? DatabaseError.NoError : DatabaseError.RealtorDelete;
        }
    }
}
