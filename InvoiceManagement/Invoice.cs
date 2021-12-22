using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.InvoiceManagement
{
    using Electronics_Store_MS.Customer;
    
    public class Invoice
    {
        private string iD;
        private List<InvoiceDetail> invoiceDetails;
        private Customer customer;
        private DateTime date;
        private decimal totalCost;

        public string ID { get => iD; }
        public List<InvoiceDetail> InvoiceDetails { get => invoiceDetails; }
        public Customer Customer { get => customer; }
        public DateTime Date { get => date; }
        public decimal TotalCost { get => totalCost; }
    }
}
