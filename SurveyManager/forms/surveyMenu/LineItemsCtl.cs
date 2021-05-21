using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.surveyMenu
{
    public partial class LineItemsCtl : UserControl
    {
        private List<LineItem> items;

        public EventHandler StatusUpdate;

        public LineItemsCtl(List<LineItem> items)
        {
            InitializeComponent();

            this.items = items;
        }

        private void LineItemsCtl_Load(object sender, EventArgs e)
        {
            foreach (LineItem item in items)
            {
                lbItems.Items.Add(item);
            }

            if (lbItems.Items.Count > 0)
                lbItems.SelectedIndex = 0;

            lblSubTotal.Text = "Sub Total for Line Items: " + items.Sum(i => i.SubTotal).ToString("C2");

            propGrid.GetAcceptButton().Visible = false;
            propGrid.GetClearButton().Visible = false;
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex >= 0)
            {
                propGrid.SelectedObject = lbItems.Items[lbItems.SelectedIndex];
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            LineItem item = new LineItem();
            lbItems.Items.Add(item);

            if (lbItems.Items.Count > 0)
            {
                lbItems.SelectedItem = item;
                propGrid.Enabled = true;
            }

            UpdateSubTotal();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            LineItem selected = (LineItem)lbItems.SelectedItem;
            lbItems.Items.Remove(selected);
            lbItems.SelectedIndex = lbItems.Items.Count - 1;

            if (selected.ID != 0)
                JobHandler.Instance.CurrentJob.BillingObject.RemoveLineItemID(selected.ID);

            if (lbItems.Items.Count <= 0)
            {
                propGrid.SelectedObject = null;
                propGrid.Enabled = false;
            }
                

            UpdateSubTotal();
        }

        private void UpdateSubTotal()
        {
            if (lbItems.Items.Count > 0)
                lblSubTotal.Text = "Sub Total for Line Items: " + lbItems.Items.Cast<LineItem>().Sum(i => i.SubTotal).ToString("C2");
            else
                lblSubTotal.Text = "Sub Total for Line Items: $0.00";
        }

        private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label.Contains("Amount") || e.ChangedItem.Label.Contains("Tax"))
                UpdateSubTotal();

            if (JobHandler.Instance.IsJobOpen)
                JobHandler.Instance.UpdateSavePending(true);
        }

        protected override void Dispose(bool disposing)
        {
            //When this user control is disposed (closed), update the currently open job with the new billing line items.
            SaveItems();
                

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            SaveItems();
        }

        private void SaveItems()
        {
            if (JobHandler.Instance.IsJobOpen)
            {
                JobHandler.Instance.CurrentJob.BillingObject.AddLineItemsRange(lbItems.Items.Cast<LineItem>().ToList(), true);
                StatusUpdate?.Invoke(this, new StatusArgs("Line items for Job# " + JobHandler.Instance.CurrentJob.JobNumber + " updated internally."));
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs("Invalid operation: <Save Billing Line Items> => Job is not opened!"));
            }
        }
    }
}
