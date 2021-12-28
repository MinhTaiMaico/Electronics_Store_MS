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
            int choice = 0;
            bool isContinue = true;
            Menu.Menu.ChooseOneProduct(choice, isContinue, product);
            UIController.EnterNumber("Nhập Số lượng: ", ref quantity);
        }

        public void ExportInformation()
        {
            product.ExportInvoice();
            Console.WriteLine("Số lượng: {0}", Quantity);
            Console.WriteLine("Thành tiền: {0}", GetCost());
        }

        public static void EnterDetailList(ref List<InvoiceDetail> invoiceDetails, int listLength)
        {
            for (int i = 0; i < listLength; i++)
            {
                Console.WriteLine("Nhập Thông tin sản phẩm thứ {0}:", i + 1);
                InvoiceDetail detail = new InvoiceDetail();
                detail.EnterInformation();
                invoiceDetails.Add(detail); 
            }
        }

        public static void ExportDetailList(ref List<InvoiceDetail> invoiceDetails)
        {
            foreach(InvoiceDetail detail in invoiceDetails)
            {
                detail.ExportInformation();
            }
        }

        public decimal GetCost()
        {
            cost= quantity * product.Price;
            return cost;
        }
    }
}
