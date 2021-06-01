using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers.SurveyJob
{
    /// <summary>
    /// This class is a wrapper for a list of <see cref="BillingItem"/>s and <see cref="LineItem"/>s.
    /// <para>This class implements the <see cref="DatabaseWrapper"/> interface to facilitate easier database operations with the two internal lists.
    /// When any of the interface methods are called, each list is iterated and depending on the method called, the objects are inserted, updated, or deleted from the database.</para>
    /// <para>The objects in each list also implement the <see cref="DatabaseWrapper"/> class so they can also be inserted, updated, or deleted from the database easily.</para>
    /// </summary>
    public class Billing : DatabaseWrapper
    {
        private readonly List<BillingItem> items = new List<BillingItem>();
        private readonly List<LineItem> lineItems = new List<LineItem>();

        [Browsable(false)]
        public string LineItemIds { get; set; } = "N/A";

        [Browsable(false)]
        public string BillingIds { get; set; } = "N/A";

        public Billing() { }

        public List<BillingItem> GetBillingItems()
        {
            return items;
        }

        public List<LineItem> GetLineItems()
        {
            return lineItems;
        }

        public void SetObjects()
        {
            if (!BillingIds.Equals("N/A"))
            {
                Thread dbThread = new Thread(() =>
                {
                    int[] ids = ParseIds(BillingIds);
                    List<BillingItem> temp = Database.GetBillingItems(ids);
                    items.AddRange(temp);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (!LineItemIds.Equals("N/A"))
            {
                Thread dbThread = new Thread(() =>
                {
                    int[] ids = ParseIds(LineItemIds);
                    List<LineItem> temp = Database.GetLineItems(ids);
                    lineItems.AddRange(temp);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
        }

        private int[] ParseIds(string strids)
        {
            string trimmed = strids.Trim();
            string delimeter = ",";
            string[] tokens = trimmed.Split(delimeter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int[] ids = new int[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                ids[i] = int.Parse(tokens[i]);
            }
            return ids;
        }

        /// <summary>
        /// Get the billing item ids as a comma seperated list of ids.
        /// </summary>
        /// <returns>A comma seperated list of billing item ids.</returns>
        public string GetBillingIds()
        {
            StringBuilder str = new StringBuilder();
            foreach (BillingItem item in items)
            {
                if (item.ID != 0)
                    str.Append($"{item.ID}, ");
            }
            return str.ToString();
        }

        public string GetLineItemIds()
        {
            StringBuilder str = new StringBuilder();
            foreach (LineItem item in lineItems)
            {
                if (item.ID != 0)
                    str.Append($"{item.ID}, ");
            }
            return str.ToString();
        }

        public void AddLineItem(LineItem item)
        {
            lineItems.Add(item);
        }

        public void AddLineItemsRange(ICollection<LineItem> lItems, bool clearListFirst)
        {
            if (clearListFirst)
                lineItems.Clear();

            lineItems.AddRange(lItems);
        }

        public void RemoveLineItem(LineItem item)
        {
            if (lineItems.Contains(item))
                lineItems.Remove(item);
        }

        public void AddLineItemID(int id)
        {
            if (LineItemIds.Equals("N/A"))
                LineItemIds = "";

            if (LineItemIds.Contains($"{id}"))
                return;

            StringBuilder str = new StringBuilder(LineItemIds);
            str.Append($"{id}, ");
            LineItemIds = str.ToString().Trim();
        }

        public void RemoveLineItemID(int id)
        {
            StringBuilder str = new StringBuilder(LineItemIds);
            str.Replace($"{id},", string.Empty);
            LineItemIds = str.ToString().Trim();
            if (LineItemIds.Equals(""))
                LineItemIds = "N/A";
        }

        public void AddBilling(BillingItem item)
        {
            items.Add(item);
        }

        public void AddBillingRange(ICollection<BillingItem> billingItems, bool clearListFirst)
        {
            if (clearListFirst)
                items.Clear();

            items.AddRange(billingItems);
        }

        public void RemoveBilling(BillingItem item)
        {
            if (items.Contains(item))
                items.Remove(item);
        }

        public void AddBillingID(int id)
        {
            if (BillingIds.Equals("N/A"))
                BillingIds = "";
            if (BillingIds.Contains($"{id}"))
                return;

            StringBuilder str = new StringBuilder(BillingIds);
            str.Append($"{id}, ");
            BillingIds = str.ToString().Trim();
        }

        public void RemoveBillingId(int id)
        {
            StringBuilder str = new StringBuilder(BillingIds);
            str.Replace($"{id},", string.Empty);
            BillingIds = str.ToString().Trim();
            if (BillingIds.Equals(""))
                BillingIds = "N/A";
        }

        public TimeSpan GetTotalFieldTime()
        {
            return TimeSpan.FromTicks(items.Sum(b => b.FieldTime.Ticks));
        }

        public TimeSpan GetTotalOfficeTime()
        {
            return TimeSpan.FromTicks(items.Sum(b => b.OfficeTime.Ticks));
        }

        public TimeSpan GetTotalTime()
        {
            return GetTotalFieldTime() + GetTotalOfficeTime();
        }

        /// <summary>
        /// Get the total bill amount for the office time including any applicable tax and time.
        /// </summary>
        /// <returns>The total office bill.</returns>
        public decimal GetTotalOfficeBill()
        {
            decimal total = 0.00m;
            foreach (BillingItem item in items)
            {
                decimal current = 0.00m;
                switch (item.OfficeRate.TimeUnit)
                {
                    case TimeUnit.Hour:
                    {
                        current = (decimal)((double)item.OfficeRate.Amount * item.OfficeTime.TotalHours);
                        break;
                    }
                    case TimeUnit.Minute:
                    {
                        current = (decimal)((double)item.OfficeRate.Amount * item.OfficeTime.TotalMinutes);
                        break;
                    }
                    case TimeUnit.Day:
                    {
                        current = (decimal)((double)item.OfficeRate.Amount * item.OfficeTime.TotalDays);
                        break;
                    }
                }
                if (item.OfficeRate.TaxIncluded)
                    current = (decimal)((double)current + ((double)current * Settings.Default.DefaultTaxRate));
                total += current;
            }
            return total;
        }

        /// <summary>
        /// Get the total bill amount for the field time including any applicable tax and time.
        /// </summary>
        /// <returns>The total field bill.</returns>
        public decimal GetTotalFieldBill()
        {
            decimal total = 0.00m;
            foreach (BillingItem item in items)
            {
                decimal current = 0.00m;
                switch (item.FieldRate.TimeUnit)
                {
                    case TimeUnit.Hour:
                    {
                        current = (decimal)((double)item.FieldRate.Amount * item.FieldTime.TotalHours);
                        break;
                    }
                    case TimeUnit.Minute:
                    {
                        current = (decimal)((double)item.FieldRate.Amount * item.FieldTime.TotalMinutes);
                        break;
                    }
                    case TimeUnit.Day:
                    {
                        current = (decimal)((double)item.FieldRate.Amount * item.FieldTime.TotalDays);
                        break;
                    }
                }
                if (item.FieldRate.TaxIncluded)
                    current = (decimal)((double)current + ((double)current * Settings.Default.DefaultTaxRate));
                total += current;
            }
            return total;
        }

        public decimal GetBillingLineItemsBill()
        {
            return lineItems.Sum(l => l.SubTotal);
        }

        /// <summary>
        /// Get the total bill combining the office bill, the field bill, and the line items bill.
        /// </summary>
        /// <returns>The total bill.</returns>
        public decimal GetTotalBill()
        {
            return GetTotalOfficeBill() + GetTotalFieldBill() + GetBillingLineItemsBill();
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            foreach (BillingItem item in items)
            {
                e = item.Insert();
                if (e != DatabaseError.NoError)
                    return e;
            }

            foreach (LineItem item in lineItems)
            {
                e = item.Insert();
                if (e != DatabaseError.NoError)
                    return e;
            }

            return DatabaseError.NoError;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            DatabaseError e;
            foreach (BillingItem item in items)
            {
                e = item.Delete();
                if (e != DatabaseError.NoError)
                    return e;
            }

            foreach (LineItem item in lineItems)
            {
                e = item.Delete();
                if (e != DatabaseError.NoError)
                    return e;
            }

            return DatabaseError.NoError;
        }
    }
}
