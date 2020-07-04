using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceProject
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceLine> LineItems = new List<InvoiceLine>{};

        public void AddInvoiceLine(InvoiceLine invoiceLine)
        {
            LineItems.Add(invoiceLine);
        }

        public void RemoveInvoiceLine(int SOMEID)
        {
            LineItems.RemoveAt(SOMEID);
        }

        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        public decimal GetTotal()
        {
            return (Decimal)LineItems.Sum(item => item.Cost * item.Quantity);
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        public void MergeInvoices(Invoice sourceInvoice)
        {
            foreach (InvoiceLine lineItems in sourceInvoice.LineItems) {
                LineItems.Add(lineItems);
            }
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        public Invoice Clone()
        {
            return new Invoice() {
                InvoiceNumber = InvoiceNumber,
                InvoiceDate = InvoiceDate,
                LineItems = LineItems
            };
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [dd/MM/yyyy], LineItemCount: [Number of items in LineItems]
        /// </summary>
        public override string ToString()
        {
            string invoiceNumber = InvoiceNumber.ToString();
            string invoiceDate = InvoiceDate.ToString("dd/MM/yyyy");
            string lineItems = LineItems.Count().ToString();
            return $"Invoice Number: {invoiceNumber}, InvoiceDate: {invoiceDate}, LineItemCount: {lineItems}";
        }
    }
}

