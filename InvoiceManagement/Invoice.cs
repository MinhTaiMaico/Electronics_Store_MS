using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Electronics_Store_MS.InvoiceManagement
{
    using Electronics_Store_MS.Customer;
    using Electronics_Store_MS.UIController;
    
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

        public void EnterInformation()
        {
            customer = new Customer();
            int length = 0;
            UIController.EnterInformation("Nhập Mã hóa đơn: ", ref iD);
            UIController.EnterDate("Nhập Ngày lập hóa đơn: ", ref date);
            Console.WriteLine("Nhập Thông tin khách hàng:");
            customer.GetInformation();
            UIController.EnterNumber("Nhập Số lượng các sản phẩm trong hóa đơn: ", ref length);
            InvoiceDetail.EnterDetailList(ref invoiceDetails, length);
        }

        public decimal GetTotalCost()
        {
            var costs = from invoiceDetail in invoiceDetails
                        select invoiceDetail.Cost;
            totalCost = costs.Sum();
            
            return totalCost;
        }
    }
}
