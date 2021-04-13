using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend.wrappers.SurveyJob
{
    /// <summary>
    /// Class to represent one line item in a survey job's bill. Multiple line items can be added to a survey.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LineItem
    {
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
        [Description("The tax rate that should be applied to the amount. Default is 0.0825 or 8.25%")]
        [Browsable(true)]
        [DisplayName("Tax Rate")]
        public double TaxRate { get; set; } = 0.0825;

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
                return (decimal)((TaxRate * (double) Amount) + (double) Amount);
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

        public override string ToString()
        {
            return $"{SubTotal:C2} - {Description}";
        }
    }
}
