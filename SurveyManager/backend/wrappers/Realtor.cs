using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Realtor : ExpandableObjectConverter, DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Realtor Information")]
        [Description("The full name of the realtor.")]
        [Browsable(true)]
        [DisplayName("Realtor Name")]
        public string Name { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The realtor's company's name.")]
        [Browsable(true)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The email address of the realtor.")]
        [Browsable(true)]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The phone number for the realtor.")]
        [Browsable(true)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The fax number, if any, of the realtor.")]
        [Browsable(true)]
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; } = "N/A";

        /// <summary>
        /// Get a value representing whether this Realtor is valid or not.
        /// <para>A valid Realtor is one whose name and email is not equal to N/A and also not an empty string.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidRealtor
        {
            get
            {
                return (!Name.Equals("N/A") && Name.Length > 0) && 
                (!PhoneNumber.Equals("N/A") && PhoneNumber.Length > 0) &&
                (!CompanyName.Equals("N/A") && CompanyName.Length > 0);
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

        public Enums.DatabaseError Delete()
        {
            return Database.DeleteRealtor(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.RealtorDelete;
        }

        public Enums.DatabaseError Insert()
        {
            if (IsValidRealtor)
                return Database.InsertRealtor(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.RealtorInsert;
            else
                return Enums.DatabaseError.RealtorIncomplete;
        }

        public Enums.DatabaseError Update()
        {
            if (IsValidRealtor)
                return Database.UpdateRealtor(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.RealtorUpdate;
            else
                return Enums.DatabaseError.RealtorIncomplete;
        }

        public override string ToString()
        {
            if (IsValidRealtor)
                return $"{Name} with {CompanyName}";
            else
                return "(...)";
        }
    }
}
