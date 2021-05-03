using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class BillingItem : ExpandableObjectConverter, DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Billing Information")]
        [Description("The service or product this item represents.")]
        [Browsable(true)]
        [DisplayName("Description")]
        public string Description { get; set; } = "N/A";

        [Category("Billing")]
        [Description("The field rate to use for billing.")]
        [Browsable(true)]
        [DisplayName("Field Rate")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Rate FieldRate { get; set; }

        [Browsable(false)]
        public int FieldRateId { get; set; }

        [Category("Billing")]
        [Description("The office rate to use for billing.")]
        [Browsable(true)]
        [DisplayName("Office Rate")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Rate OfficeRate { get; set; }

        [Browsable(false)]
        public int OfficeRateId { get; set; }

        [Category("Billing")]
        [Description("The field time for this billing entry; format = hours:minutes:seconds")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Field Time")]
        public TimeSpan FieldTime { get; set; }

        [Category("Billing")]
        [Description("The office time for this billing entry; format = hours:minutes:seconds")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Office Time")]
        public TimeSpan OfficeTime { get; set; }

        /// <summary>
        /// Checks the description, the field rate, and the office rate to ensure this is a valid billing item.
        /// </summary>
        [Browsable(false)]
        public bool IsValidItem
        {
            get
            {
                return !Description.Equals("N/A") && FieldRate.IsValidRate && OfficeRate.IsValidRate;
            }
        }

        public BillingItem() { }

        public BillingItem(int iD, string description, Rate fieldRate, int fieldRateId, Rate officeRate, int officeRateId, TimeSpan fieldTime, TimeSpan officeTime)
        {
            ID = iD;
            Description = description;
            FieldRate = fieldRate;
            FieldRateId = fieldRateId;
            OfficeRate = officeRate;
            OfficeRateId = officeRateId;
            FieldTime = fieldTime;
            OfficeTime = officeTime;
        }

        public BillingItem(int iD, string description, Rate fieldRate, Rate officeRate, TimeSpan fieldTime, TimeSpan officeTime)
        {
            ID = iD;
            Description = description;
            FieldRate = fieldRate;
            OfficeRate = officeRate;
            FieldTime = fieldTime;
            OfficeTime = officeTime;
        }

        public BillingItem(string description, Rate fieldRate, Rate officeRate)
        {
            Description = description;
            FieldRate = fieldRate;
            OfficeRate = officeRate;
        }

        public BillingItem(string description, Rate fieldRate, Rate officeRate, TimeSpan fieldTime, TimeSpan officeTime) : this(description, fieldRate, officeRate)
        {
            FieldTime = fieldTime;
            OfficeTime = officeTime;
        }


        public void SetObjects()
        {
            if (FieldRateId != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    FieldRate = Database.GetRate(FieldRateId);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (OfficeRateId != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    OfficeRate = Database.GetRate(OfficeRateId);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
        }

        public override string ToString()
        {
            return $"Description: {Description}\tOffice Rate: {OfficeRate}\tField Rate: {FieldRate}";
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidItem)
            {
                e = OfficeRate.Insert();
                if (e != DatabaseError.NoError)
                    return e;
                e = FieldRate.Insert();
                if (e != DatabaseError.NoError)
                    return e;

                if (ID == 0)
                {
                    ID = Database.InsertBillingItem(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.BillingItemInsert;
                }
                else
                {
                    e = Database.UpdateBillingItem(this) ? DatabaseError.NoError : DatabaseError.BillingItemUpdate;
                }
                return e;
            }
            else
                return DatabaseError.BillingItemIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteBillingItem(this) ? DatabaseError.NoError : DatabaseError.BillingItemDelete;
        }
    }
}
