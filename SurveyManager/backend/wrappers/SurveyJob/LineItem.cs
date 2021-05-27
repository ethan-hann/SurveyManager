using SurveyManager.Properties;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers.SurveyJob
{
    /// <summary>
    /// Class to represent one line item in a survey job's bill. Multiple line items can be added to a survey.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LineItem : IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }
        /// <summary>
        /// The amount in US dollars to charge for this line item.
        /// </summary>
        [Category("Details")]
        [Description("The amount associated with this line item.")]
        [Browsable(true)]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// A brief description about this charge.
        /// </summary>
        [Category("Details")]
        [Description("A description for this line item.")]
        [Browsable(true)]
        [DisplayName("Description")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Description { get; set; }

        /// <summary>
        /// Any applicable tax to add to the total for this line item.
        /// </summary>
        [Category("Details")]
        [Description($"The tax rate that should be applied to the amount. Default is modified in application settings.")]
        [Browsable(true)]
        [DisplayName("Tax Rate")]
        public double TaxRate { get; set; } = Settings.Default.DefaultTaxRate;

        /// <summary>
        /// Get a value representing the subtotal for this line item. The subtotal is calculated using the <see cref="Amount"/> and the <see cref="TaxRate"/>.
        /// </summary>
        [Category("Details")]
        [Description("The sub-total of this line item including any applicable tax.")]
        [Browsable(true)]
        [DisplayName("Sub-Total")]
        public decimal SubTotal
        {
            get
            {
                return (decimal)((TaxRate * (double)Amount) + (double)Amount);
            }
        }

        /// <summary>
        /// Get a value indicating if this is a valid billing line item.
        /// <para>A valid line item is one whose amount is not $0.00 and has a description.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidLineItem
        {
            get
            {
                return Amount != 0.0M && Description.Length > 0;
            }
        }

        public LineItem() { }

        /// <summary>
        /// Create a new line item with the necessary information.
        /// </summary>
        /// <param name="amount">The amount for this charge.</param>
        /// <param name="description">A brief description of the charge.</param>
        /// <param name="taxRate">Any applicable tax that should be considered for this charge.</param>
        public LineItem(decimal amount, string description, double taxRate = 0.0)
        {
            Amount = amount;
            Description = description;
            TaxRate = taxRate;
        }

        /// <summary>
        /// Create a new line item with the necessary information.
        /// </summary>
        /// <param name="id">The id of the row in the database.</param>
        /// <param name="amount">The amount for this charge.</param>
        /// <param name="description">A brief description of the charge.</param>
        /// <param name="taxRate">Any applicable tax that should be considered for this charge.</param>
        public LineItem(int id, decimal amount, string description, double taxRate = 0.0)
        {
            ID = id;
            Amount = amount;
            Description = description;
            TaxRate = taxRate;
        }

        public override string ToString()
        {
            return $"{SubTotal:C2} - {Description}";
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidLineItem)
            {
                if (ID == 0)
                {
                    ID = Database.InsertLineItem(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.LineItemInsert;
                }
                else
                {
                    e = Database.UpdateLineItem(this) ? DatabaseError.NoError : DatabaseError.LineItemUpdate;
                }
                return e;
            }
            return DatabaseError.LineItemIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteLineItem(ID) ? DatabaseError.NoError : DatabaseError.LineItemDelete;
        }
    }
}
