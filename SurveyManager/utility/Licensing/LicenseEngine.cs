using SeriousBit.Ellipter;
using SurveyManager.Properties;
using System;


namespace SurveyManager.utility.Licensing
{
    /// <summary>
    /// Licensing Engine for validating and getting the information associated with product keys.
    /// </summary>
    public class LicenseEngine
    {
        private static SerialsManager manager = new SerialsManager(Settings.Default.DeveloperName, Settings.Default.DeveloperKey, KeyStrength.Use128Bits);

        /// <summary>
        /// Get a value indicating if the specified product key is valid for this product.
        /// </summary>
        /// <param name="productKey">The product key to check.</param>
        /// <returns>True if the product key is valid; False otherwise.</returns>
        public static bool CheckIfValid(string productKey)
        {
            manager.PublicKey = Resources.public_key;
            return manager.IsValid(productKey);
        }

        /// <summary>
        /// Get the License information associated with the specified product key.
        /// </summary>
        /// <param name="productKey">The product key to get the information for.</param>
        /// <returns>If the License information is in the correct format, returns the correct license info.
        /// If not, returns a LicenseInfo object representing an Unlicensed entity.</returns>
        public static LicenseInfo GetLicenseInfo(string productKey)
        {
            if (!CheckIfValid(productKey))
            {
                return LicenseInfo.CreateUnlicensedInfo();
            }

            long serialID = manager.GetID(productKey);
            DateTime purchaseDate = manager.GetDate(productKey);
            string info = manager.GetInfo(productKey);

            info = info.Trim();
            string[] tokens = info.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 4)
            {
                string customerName = tokens[0].Trim();
                string customerEmail = tokens[1].Trim();
                string numOfUses = tokens[2].Trim();
                string expirationDate = tokens[3].Trim();
                DateTime expDate = DateTime.Parse(expirationDate);
                return new LicenseInfo(customerName, customerEmail, numOfUses, serialID.ToString(),
                    purchaseDate, expDate, LicenseType.Trial);
            }
            else if (tokens.Length == 3)
            {
                string customerName = tokens[0].Trim();
                string customerEmail = tokens[1].Trim();
                string numOfUses = tokens[2].Trim();
                return new LicenseInfo(customerName, customerEmail, numOfUses, serialID.ToString(), purchaseDate,
                    LicenseType.FullLicense);
            }
            else
            {
                return LicenseInfo.CreateUnlicensedInfo();
            }
        }
    }
}

//Serial info format:
//Application Name; Customer Name; Customer Email; <NumOfUses>; Expiration Date;
//If no expiration date: Application Name; Customer Name; Customer Email; <NumOfUses>;