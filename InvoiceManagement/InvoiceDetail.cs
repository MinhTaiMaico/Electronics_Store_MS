using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.InvoiceManagement
{
    using Electronics_Store_MS.Product;
    using Electronics_Store_MS.UIController;

    public class InvoiceDetail
    {
        private int quantity;
        private decimal cost;
        private Product product;

        public int Quantity { get => quantity; }
        public decimal Cost { get => cost; }
        public Product Product { get => product; }

        public void EnterInformation()
        {
            product.AddToInvoice();
            UIController.EnterNumber("Nhập Số lượng: ", ref quantity);
        }

        public void ExportInformation()
        {
            product.ExportInvoice();
            Console.WriteLine("Số lượng: {0}", Quantity);
            Console.WriteLine("Thành tiền: {0}", GetCost());
        }

        public decimal GetCost()
        {
            cost= quantity * product.Price;
            return cost;
        }
    }
}
