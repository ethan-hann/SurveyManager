﻿using SurveyManager.utility;
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
    public class Rate : ExpandableObjectConverter, DatabaseWrapper
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

        [Browsable(false)]
        public int CountyID { get; set; }

        [Category("Rate Information")]
        [Description("The county this rate applies to.")]
        [Browsable(true)]
        [DisplayName("County")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public County County { get; set; } = RuntimeVars.Instance.Counties.Find(c => c.CountyName.Equals("Chambers"));

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
                return !Description.Equals("N/A") && Amount != 0.00m && CountyID != 0;
            }
        }

        public Rate() { }

        public Rate(int iD, string description, decimal amount, TimeUnit timeUnit, int countyID, County county, bool taxIncluded)
        {
            ID = iD;
            Description = description;
            Amount = amount;
            TimeUnit = timeUnit;
            CountyID = countyID;
            County = county;
            TaxIncluded = taxIncluded;
        }

        public Rate(string description, decimal amount, TimeUnit timeUnit, int countyID, County county, bool taxIncluded)
        {
            Description = description;
            Amount = amount;
            TimeUnit = timeUnit;
            CountyID = countyID;
            County = county;
            TaxIncluded = taxIncluded;
        }

        public Rate(string description, decimal amount, TimeUnit timeUnit, int countyID, County county)
        {
            Description = description;
            Amount = amount;
            TimeUnit = timeUnit;
            CountyID = countyID;
            County = county;
        }

        public void SetObjects()
        {
            if (CountyID != 0)
            {
                County = RuntimeVars.Instance.Counties.Find(c => c.ID == CountyID);
            }
        }

        public override string ToString()
        {
            return $"{Description} - {Amount.ToString("C2")} per {TimeUnit}";
        }

        public DatabaseError Insert()
        {
            if (IsValidRate)
            {
                int id = Database.InsertRate(this);
                if (id != 0)
                {
                    ID = id;
                }

                return id != 0 ? DatabaseError.NoError : DatabaseError.RateInsert;
            }
            else
                return DatabaseError.RateIncomplete;
        }

        public DatabaseError Update()
        {
            if (IsValidRate)
                return Database.UpdateRate(this) ? DatabaseError.NoError : DatabaseError.RateUpdate;
            else
                return DatabaseError.RateIncomplete;
        }

        public DatabaseError Delete()
        {
            return Database.DeleteRate(this) ? DatabaseError.NoError : DatabaseError.RateDelete;
        }
    }
}
