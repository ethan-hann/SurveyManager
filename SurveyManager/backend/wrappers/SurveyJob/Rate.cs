using System;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// Class to represents a single rate. A rate is what is used in billing to determine how much to bill.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Rate : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Rate Information")]
        [Description("The service or product this rate represents.")]
        [Browsable(true)]
        [DisplayName("Description")]
        public string Description { get; set; } = "N/A";

        [Category("Rate Information")]
        [Description("The dollar amount to charge for this rate.")]
        [Browsable(true)]
        [DisplayName("Amount")]
        public decimal Amount { get; set; } = 0.00m;

        [Category("Rate Information")]
        [Description("The time unit describing how often this rate should be billed. The default is per Hour.")]
        [Browsable(true)]
        [DisplayName("Time Unit")]
        public TimeUnit TimeUnit { get; set; } = TimeUnit.Hour;

        [Category("Rate Information")]
        [Description("Should tax be included in the final amount for this rate? The tax rate can be set in the application's settings.")]
        [Browsable(true)]
        [DisplayName("Is Tax Included?")]
        public bool TaxIncluded { get; set; } = true;

        /// <summary>
        /// Checks the description, amount, and county to ensure this is a valid rate.
        /// </summary>
        [Browsable(false)]
        public bool IsValidRate
        {
            get
            {
                return !Description.Equals("N/A") && Amount != 0.00m;
            }
        }

        public Rate() { }

        public Rate(int iD, string description, decimal amount, TimeUnit timeUnit, bool taxIncluded)
        {
            ID = iD;
            Description = description;
            Amount = amount;
            TimeUnit = timeUnit;
            TaxIncluded = taxIncluded;
        }

        public Rate(string description, decimal amount, TimeUnit timeUnit, bool taxIncluded)
        {
            Description = description;
            Amount = amount;
            TimeUnit = timeUnit;
            TaxIncluded = taxIncluded;
        }

        public Rate(string description, decimal amount, TimeUnit timeUnit)
        {
            Description = description;
            Amount = amount;
            TimeUnit = timeUnit;
        }

        public override string ToString()
        {
            return $"{Description} - {Amount.ToString("C2")} per {TimeUnit}";
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidRate)
            {
                if (ID == 0)
                {
                    ID = Database.InsertRate(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.RateInsert;
                }
                else
                {
                    e = Database.UpdateRate(this) ? DatabaseError.NoError : DatabaseError.RateUpdate;
                }
                return e;
            }
            return DatabaseError.RateIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteRate(this) ? DatabaseError.NoError : DatabaseError.RateDelete;
        }
    }
}
