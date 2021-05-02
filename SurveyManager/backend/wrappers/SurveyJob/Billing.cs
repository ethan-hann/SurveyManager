using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private List<BillingItem> items = new List<BillingItem>();
        private List<LineItem> lineItems = new List<LineItem>();

        [Browsable(false)]
        public string LineItemIds { get; set; } = "N/A";

        [Browsable(false)]
        public string BillingIds { get; set; } = "N/A";

        public Billing() { }

        public void SetObjects()
        {
            if (!BillingIds.Equals("N/A"))
            {
                Thread dbThread = new Thread(() =>
                {
                    int[] ids = ParseIds(BillingIds);
                    items = Database.GetBillingItems(ids);
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
                    lineItems = Database.GetLineItems(ids);
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
            if (lineItems == null)
                lineItems = new List<LineItem>();

            lineItems.Add(item);
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
            if (items == null)
                items = new List<BillingItem>();
            items.Add(item);
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
                        current = (decimal)((double) item.OfficeRate.Amount * item.OfficeTime.TotalHours);
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
                    current = (decimal) ((double)current + ((double)current * Settings.Default.DefaultTaxRate));
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
            DatabaseError e = DatabaseError.NoError;
            foreach (BillingItem item in items)
            {
                e = item.Insert();
                if (e != DatabaseError.NoError)
                    break;
            }

            if (e == DatabaseError.NoError)
            {
                foreach (LineItem item in lineItems)
                {
                    e = item.Insert();
                    if (e != DatabaseError.NoError)
                        break;
                }
            }

            return e;
        }

        public DatabaseError Update()
        {
            DatabaseError e = DatabaseError.NoError;
            foreach (BillingItem item in items)
            {
                e = item.Update();
                if (e != DatabaseError.NoError)
                    break;
            }

            if (e == DatabaseError.NoError)
            {
                foreach (LineItem item in lineItems)
                {
                    e = item.Update();
                    if (e != DatabaseError.NoError)
                        break;
                }
            }

            return e;
        }

        public DatabaseError Delete()
        {
            DatabaseError e = DatabaseError.NoError;
            foreach (BillingItem item in items)
            {
                e = item.Delete();
                if (e != DatabaseError.NoError)
                    break;
            }

            if (e == DatabaseError.NoError)
            {
                foreach (LineItem item in lineItems)
                {
                    e = item.Delete();
                    if (e != DatabaseError.NoError)
                        break;
                }
            }

            return e;
        }
    }
}
