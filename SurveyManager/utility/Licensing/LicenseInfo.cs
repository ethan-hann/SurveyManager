using System;
using System.ComponentModel;

namespace SurveyManager.utility.Licensing
{
    /// <summary>
    /// Represents the information associated with a product key. This class can also create an empty, unlicensed information object.
    /// </summary>
    [Serializable]
    public class LicenseInfo
    {
        /// <summary>
        /// The name of the customer whom this product is licensed to.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Registered To")]
        public string CustomerName { get; set; }

        /// <summary>
        /// The email of the customer.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Registration Email")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// The number of uses left for this product key.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Uses Left")]
        public string NumberOfUses { get; set; }

        /// <summary>
        /// The id of the serial number.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Serial ID")]
        public string SerialID { get; set; }

        /// <summary>
        /// The date this license was purchased/obtained.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The date this license expires.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// The type of license this customer has.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("License Type")]
        public LicenseType Type { get; set; }

        /// <summary>
        /// Get a value indicating if this license info is empty.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return CustomerName.Equals("Unlicensed") && CustomerEmail.Equals("Unlicensed") &&
                    NumberOfUses.Equals("0") && SerialID.Equals("NaN") && Type == LicenseType.Unlicensed;
            }
        }

        public LicenseInfo(string customerName, string customerEmail, string numberOfUses, string serialID, LicenseType license)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            NumberOfUses = numberOfUses;
            SerialID = serialID;
            Type = license;

            PurchaseDate = DateTime.MinValue;
            ExpirationDate = DateTime.MaxValue;
        }

        public LicenseInfo(string customerName, string customerEmail, string numberOfUses, string serialID, DateTime purchaseDate, DateTime expirationDate, LicenseType license) : this(customerName, customerEmail, numberOfUses, serialID, license)
        {
            PurchaseDate = purchaseDate;
            ExpirationDate = expirationDate;
        }

        public LicenseInfo(string customerName, string customerEmail, string numberOfUses, string serialID, DateTime purchaseDate, LicenseType license) : this(customerName, customerEmail, numberOfUses, serialID, license)
        {
            PurchaseDate = purchaseDate;
            ExpirationDate = DateTime.MaxValue;
        }

        /// <summary>
        /// Get a license information object that represents an unlicensed product.
        /// </summary>
        /// <returns></returns>
        public static LicenseInfo CreateUnlicensedInfo()
        {
            return new LicenseInfo("Unlicensed", "Unlicensed", "0", "NaN", DateTime.MinValue, DateTime.MaxValue, LicenseType.Unlicensed);
        }
    }
}
