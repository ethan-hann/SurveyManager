using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility.Licensing
{
    /// <summary>
    /// Represents the information associated with a product key. This class can also create an empty, unlicensed information object.
    /// </summary>
    [Serializable]
    public class LicenseInfo
    {
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Registered To")]
        public string CustomerName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Registration Email")]
        public string CustomerEmail { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Uses Left")]
        public string NumberOfUses { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Serial ID")]
        public string SerialID { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("License Type")]
        public LicenseType Type { get; set; }

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
