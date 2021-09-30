using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers.SurveyJob
{
    /// <summary>
    /// This class represents a single billing item for a survey job. A billing item has a field rate and time as well as an office rate and time.
    /// <para>There is also an associated date that corresponds to when the entry was created.</para>
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class BillingItem : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// A description of this billing item.
        /// </summary>
        [Category("Billing Information")]
        [Description("The service or product this item represents.")]
        [Browsable(true)]
        [DisplayName("Description")]
        public string Description { get; set; } = "N/A";

        /// <summary>
        /// The <see cref="Rate"/> that should be associated with the Field time.
        /// </summary>
        [Category("Billing")]
        [Description("The field rate to use for billing.")]
        [Browsable(true)]
        [DisplayName("Field Rate")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Rate FieldRate { get; set; }

        /// <summary>
        /// The id in the database of the <see cref="FieldRate"/>.
        /// </summary>
        [Browsable(false)]
        public int FieldRateId { get; set; }

        /// <summary>
        /// The <see cref="Rate"/> that should be associated with the Office time.
        /// </summary>
        [Category("Billing")]
        [Description("The office rate to use for billing.")]
        [Browsable(true)]
        [DisplayName("Office Rate")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Rate OfficeRate { get; set; }

        /// <summary>
        /// The id in the database of the <see cref="OfficeRate"/>.
        /// </summary>
        [Browsable(false)]
        public int OfficeRateId { get; set; }

        /// <summary>
        /// The time entry for this billing item's field time. This is used in conjuction with the <see cref="FieldRate"/> to determine the field bill.
        /// </summary>
        [Category("Billing")]
        [Description("The field time for this billing entry; format = hours:minutes:seconds")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Field Time")]
        public TimeSpan FieldTime { get; set; }

        /// <summary>
        /// The time entry for this billing item's office time. This is used in conjuction with the <see cref="OfficeRate"/> to determine the office bill.
        /// </summary>
        [Category("Billing")]
        [Description("The office time for this billing entry; format = hours:minutes:seconds")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Office Time")]
        public TimeSpan OfficeTime { get; set; }

        /// <summary>
        /// The date this entry was created.
        /// </summary>
        [Browsable(false)]
        public DateTime AssociatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Checks the description, the field rate, and the office rate to ensure this is a valid billing item.
        /// </summary>
        [Browsable(false)]
        public bool IsValidItem
        {
            get
            {
                return !Description.ToLower().Equals("n/a") && FieldRate.IsValidRate && OfficeRate.IsValidRate;
            }
        }

        public List<IDatabaseWrapper> AssociatedObjects { get { return new List<IDatabaseWrapper>(); } }

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

        /// <summary>
        /// Set this billing item's objects with those from the database based on the Ids. Each database operation runs on a seperate thread.
        /// </summary>
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
            return OfficeTime == TimeSpan.Zero ? $"Billing Item: {Description}\tField Rate: {FieldRate}\tField Time: {FieldTime}" :
                $"Billing Item: {Description}\tOffice Rate: {OfficeRate}\tOffice Time: {OfficeTime}";
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
