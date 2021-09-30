using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// This class represents a Title Company object. A title company is associated with a <see cref="SurveyJob.Survey"/>.
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class TitleCompany : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// The full name of the title company.
        /// </summary>
        [Category("Company Information")]
        [Description("The full name of the Title Company.")]
        [Browsable(true)]
        [DisplayName("Company Name")]
        public string Name { get; set; } = "N/A";

        /// <summary>
        /// The full name of the associate (point of contact) for the title company.
        /// </summary>
        [Category("Company Information")]
        [Description("The full name of the associate at the title company.")]
        [Browsable(true)]
        [DisplayName("Associate's Name")]
        public string AssociateName { get; set; } = "N/A";

        /// <summary>
        /// The email address for the associated (point of contact) for the title company.
        /// </summary>
        [Category("Company Information")]
        [Description("The email address of the associate at the title company.")]
        [Browsable(true)]
        [DisplayName("Associate's Email")]
        public string AssociateEmail { get; set; } = "N/A";

        /// <summary>
        /// The phone number for the title company's office.
        /// </summary>
        [Category("Company Information")]
        [Description("The phone number for the title company's office.")]
        [Browsable(true)]
        [DisplayName("Office Number")]
        public string OfficeNumber { get; set; } = "N/A";

        /// <summary>
        /// Get a value indiciating if this is a valid TitleCompany.
        /// <para>A valid TitleCompany is one whose name, associate's name, associate's email, and office phone number is not "N/A" and is valid.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidCompany
        {
            get
            {
                return Validator.TitleCompany(this).Count == 0;
            }
        }

        public List<IDatabaseWrapper> AssociatedObjects { get { return new List<IDatabaseWrapper>(); } }

        public TitleCompany() { }

        public TitleCompany(int iD, string name, string associateName, string associateEmail, string officeNumber)
        {
            ID = iD;
            Name = name;
            AssociateName = associateName;
            AssociateEmail = associateEmail;
            OfficeNumber = officeNumber;
        }

        public TitleCompany(string name, string associateName, string associateEmail, string officeNumber)
        {
            Name = name;
            AssociateName = associateName;
            AssociateEmail = associateEmail;
            OfficeNumber = officeNumber;
        }

        public override string ToString()
        {
            if (IsValidCompany)
                return Name;
            else
                return "Invalid Title Company (...)";
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidCompany)
            {
                if (ID == 0)
                {
                    ID = Database.InsertTitleCompany(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.TitleCompanyInsert;
                }
                else
                {
                    e = Database.UpdateTitleCompany(this) ? DatabaseError.NoError : DatabaseError.TitleCompanyUpdate;
                }
                return e;
            }
            return DatabaseError.TitleCompanyIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteTitleCompany(this) ? DatabaseError.NoError : DatabaseError.TitleCompanyDelete;
        }
    }
}
