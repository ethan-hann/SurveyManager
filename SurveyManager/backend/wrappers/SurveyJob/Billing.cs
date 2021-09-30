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
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations with the two internal lists.
    /// When any of the interface methods are called, each list is iterated and depending on the method called, the objects are inserted, updated, or deleted from the database.</para>
    /// <para>The objects in each list also implement the <see cref="IDatabaseWrapper"/> class so they can also be inserted, updated, or deleted from the database easily.</para>
    /// </summary>
    public class Billing : IDatabaseWrapper
    {
        private readonly List<BillingItem> items = new List<BillingItem>();
        private readonly List<LineItem> lineItems = new List<LineItem>();

        [Browsable(false)]
        public int ID { get; set; } = 0;

        /// <summary>
        /// The string of comma seperated line item ids.
        /// </summary>
        [Browsable(false)]
        public string LineItemIds { get; set; } = "N/A";

        /// <summary>
        /// The string of comma seperated billing item ids.
        /// </summary>
        [Browsable(false)]
        public string BillingIds { get; set; } = "N/A";

        public List<IDatabaseWrapper> AssociatedObjects
        {
            get
            {
                List<IDatabaseWrapper> objs = new List<IDatabaseWrapper>();
                objs.AddRange(items);
                objs.AddRange(lineItems);
                return objs;
            }
        }

        public Billing() { }

        /// <summary>
        /// Get a list of <see cref="BillingItem"/> objects associated with this <see cref="Billing"/> object.
        /// </summary>
        /// <returns>A list of BillingItems.</returns>
        public List<BillingItem> GetBillingItems()
        {
            return items;
        }

        /// <summary>
        /// Get a list of <see cref="LineItem"/> objects associated with this <see cref="Billing"/> object.
        /// </summary>
        /// <returns></returns>
        public List<LineItem> GetLineItems()
        {
            return lineItems;
        }


        /// <summary>
        /// Set this <see cref="Billing"/> object's associated objects based on the ids in <see cref="BillingIds"/> and <see cref="LineItemIds"/>.
        /// </summary>
        public void SetObjects()
        {
            if (!BillingIds.ToLower().Equals("n/a"))
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
            if (!LineItemIds.ToLower().Equals("n/a"))
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

        /// <summary>
        /// Get the line item ids as a comma seperated list of ids.
        /// </summary>
        /// <returns>A comma seperated list of line item ids.</returns>
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

        /// <summary>
        /// Add a new <see cref="LineItem"/> to this <see cref="Billing"/> object's internal list.
        /// </summary>
        /// <param name="item">The line item to add.</param>
        public void AddLineItem(LineItem item)
        {
            lineItems.Add(item);
        }

        /// <summary>
        /// Add a collection of <see cref="LineItem"/> objects to this <see cref="Billing"/> object.
        /// </summary>
        /// <param name="lItems">The collection of items to add.</param>
        /// <param name="clearListFirst">Should the internal list be cleared first?</param>
        public void AddLineItemsRange(ICollection<LineItem> lItems, bool clearListFirst)
        {
            if (clearListFirst)
                lineItems.Clear();

            lineItems.AddRange(lItems);
        }

        /// <summary>
        /// Remove, if it exists, a line item from this <see cref="Billing"/> object's internal list.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveLineItem(LineItem item)
        {
            if (lineItems.Contains(item))
                lineItems.Remove(item);
        }

        /// <summary>
        /// Add, if not already present, a line item id to the <see cref="LineItemIds"/> string.
        /// </summary>
        /// <param name="id">The id to add.</param>
        public void AddLineItemID(int id)
        {
            if (LineItemIds.ToLower().Equals("n/a"))
                LineItemIds = "";

            if (LineItemIds.Contains($"{id}"))
                return;

            StringBuilder str = new StringBuilder(LineItemIds);
            str.Append($"{id}, ");
            LineItemIds = str.ToString().Trim();
        }

        /// <summary>
        /// Remove, if it exists, a line item id from the <see cref="LineItemIds"/> string.
        /// </summary>
        /// <param name="id">The id to remove.</param>
        public void RemoveLineItemID(int id)
        {
            StringBuilder str = new StringBuilder(LineItemIds);
            str.Replace($"{id},", string.Empty);
            LineItemIds = str.ToString().Trim();
            if (LineItemIds.Equals(""))
                LineItemIds = "N/A";
        }

        /// <summary>
        /// Add a new <see cref="BillingItem"/> to this <see cref="Billing"/> object's internal list.
        /// </summary>
        /// <param name="item">The billing item to add.</param>
        public void AddBilling(BillingItem item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Add a collection of <see cref="BillingItem"/> objects to this <see cref="Billing"/> object.
        /// </summary>
        /// <param name="billingItems">The collection of items to add.</param>
        /// <param name="clearListFirst">Should the internal list be cleared first?</param>
        public void AddBillingRange(ICollection<BillingItem> billingItems, bool clearListFirst)
        {
            if (clearListFirst)
                items.Clear();

            items.AddRange(billingItems);
        }

        /// <summary>
        /// Remove, if it exists, a billing item from this <see cref="Billing"/> object's internal list.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public void RemoveBilling(BillingItem item)
        {
            if (items.Contains(item))
                items.Remove(item);
        }

        /// <summary>
        /// Add, if not already present, a billing item id to the <see cref="BillingIds"/> string.
        /// </summary>
        /// <param name="id">The id to add.</param>
        public void AddBillingID(int id)
        {
            if (BillingIds.ToLower().Equals("n/a"))
                BillingIds = "";
            if (BillingIds.Contains($"{id}"))
                return;

            StringBuilder str = new StringBuilder(BillingIds);
            str.Append($"{id}, ");
            BillingIds = str.ToString().Trim();
        }

        /// <summary>
        /// Remove, if it exists, a billing item id from the <see cref="BillingIds"/> string.
        /// </summary>
        /// <param name="id">The id to remove.</param>
        public void RemoveBillingId(int id)
        {
            StringBuilder str = new StringBuilder(BillingIds);
            str.Replace($"{id},", string.Empty);
            BillingIds = str.ToString().Trim();
            if (BillingIds.Equals(""))
                BillingIds = "N/A";
        }

        /// <summary>
        /// Get the total field time spent on this job based on the list of <see cref="BillingItem"/>s.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representing the total field time.</returns>
        public TimeSpan GetTotalFieldTime()
        {
            return TimeSpan.FromTicks(items.Sum(b => b.FieldTime.Ticks));
        }

        /// <summary>
        /// Get the total office time spent on this job based on the list of <see cref="BillingItem"/>s.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representing the total office time.</returns>
        public TimeSpan GetTotalOfficeTime()
        {
            return TimeSpan.FromTicks(items.Sum(b => b.OfficeTime.Ticks));
        }

        /// <summary>
        /// Get the total time spent on this job based on the list of <see cref="BillingItem"/>s.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representing the total time.</returns>
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

        /// <summary>
        /// Get the total bill amount for the <see cref="LineItem"/>s.
        /// </summary>
        /// <returns>The total line items bill.</returns>
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

        public override string ToString()
        {
            return $"Billing Items: {items.Count} - Line Items: {lineItems.Count}";
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
