using System;
using System.ComponentModel;

namespace SurveyManager.utility.Licensing
{
    /// <summary>
    /// Defines a license holder.
    /// </summary>
    public class Licensee
    {
        /// <summary>
        /// The name of the license holder.
        /// </summary>
        [Category("User Information")]
        [Description("The full name of the license holder.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        /// <summary>
        /// The email of the license holder.
        /// </summary>
        [Category("User Information")]
        [Description("The email of the license holder.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// The name of the company for this license holder.
        /// </summary>
        [Category("User Information")]
        [Description("The company this license holder is a part of, if any.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The phone number of the license holder.
        /// </summary>
        [Category("User Information")]
        [Description("The phone number of the license holder.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The UID for the license.
        /// </summary>
        [Category("License Information")]
        [Description("The license activation GUID.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("License GUID")]
        public Guid LicenseGUID { get; set; }

        /// <summary>
        /// The type of license to generate.
        /// </summary>
        [Category("License Information")]
        [Description("The license type.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("License Type")]
        public LicenseType LicenseType { get; set; }

        /// <summary>
        /// The date this license expires, if any.
        /// </summary>
        [Category("License Information")]
        [Description("The date this license expires, if any.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Valid Until")]
        public DateTime LicenseExpiration { get; set; }

        /// <summary>
        /// The maximum number of uses for this license.
        /// </summary>
        [Category("License Information")]
        [Description("The maximum number of uses for this license.")]
        [ReadOnly(true)]
        [Browsable(true)]
        [DisplayName("Number of Uses")]
        public int LicenseUsage { get; set; }

        /// <summary>
        /// Get a value indicating if the licensee information is empty.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return FullName.Length <= 0 || Email.Length <= 0 || PhoneNumber.Length <= 0 || LicenseGUID.Equals(Guid.Empty);
            }
        }

        /// <summary>
        /// Create a new licensee with the supplied information.
        /// </summary>
        /// <param name="name">The name of the license holder.</param>
        /// <param name="email">The email of the license holder.</param>
        /// <param name="licenseID">The UID for the license.</param>
        /// <param name="phoneNumber">The phone number of the license holder.</param>
        public Licensee(string name, string email, Guid licenseID, string phoneNumber)
        {
            FullName = name;
            Email = email;
            LicenseGUID = licenseID;
            PhoneNumber = phoneNumber;
        }
    }
}
