
using System;
using System.Collections.Generic;

namespace InvoiceProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Xero Tech Test!");

            CreateInvoiceWithOneItem();
            CreateInvoiceWithMultipleItemsAndQuantities();
            RemoveItem();
            MergeInvoices();
            CloneInvoice();
            InvoiceToString();
        }

        private static void CreateInvoiceWithOneItem()
        {
            var invoice = new Invoice();

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99,
                Quantity = 1,
                Description = "Apple"
            });

            Console.WriteLine(invoice.GetTotal());
        }

        private static void CreateInvoiceWithMultipleItemsAndQuantities()
        {
            var invoice = new Invoice();

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.21,
                Quantity = 4,
                Description = "Banana"
            });

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21,
                Quantity = 1,
                Description = "Orange"
            });

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 5.21,
                Quantity = 5,
                Description = "Pineapple"
            });

            Console.WriteLine(invoice.GetTotal());
        }

        private static void RemoveItem()
        {
            var invoice = new Invoice();

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21,
                Quantity = 1,
                Description = "Orange"
            });

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 10.99,
                Quantity = 4,
                Description = "Banana"
            });

            invoice.RemoveInvoiceLine(1);
            Console.WriteLine(invoice.GetTotal());
        }

        private static void MergeInvoices()
        {
            var invoice1 = new Invoice();

            invoice1.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.33,
                Quantity = 4,
                Description = "Banana"
            });

            var invoice2 = new Invoice();

            invoice2.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.22,
                Quantity = 1,
                Description = "Orange"
            });

            invoice2.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 6.27,
                Quantity = 3,
                Description = "Blueberries"
            });

            invoice1.MergeInvoices(invoice2);
            Console.WriteLine(invoice1.GetTotal());
        }

        private static void CloneInvoice()
        {
            var invoice = new Invoice();

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99,
                Quantity = 1,
                Description = "Apple"
            });

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 6.27,
                Quantity = 3,
                Description = "Blueberries"
            });

            var clonedInvoice = invoice.Clone();
            Console.WriteLine(clonedInvoice.GetTotal());
        }

        private static void InvoiceToString()
        {
            var invoice = new Invoice()
            {
                InvoiceDate = DateTime.Now,
                InvoiceNumber = 1000,
                LineItems = new List<InvoiceLine>()
                {
                    new InvoiceLine()
                    {
                        InvoiceLineId = 1,
                        Cost = 6.99,
                        Quantity = 1,
                        Description = "Apple"
                    }
                }
            };

            Console.WriteLine(invoice.ToString());
        }
    }
}