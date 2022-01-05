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
            Menu.Menu.ChooseOneProduct(choice, isContinue, ref product);
            UIController.EnterQuantity("\t\t\tNhập Số lượng: ", ref quantity);
            GetCost(ref cost);
        }

        public void ExportInformation()
        {
            product.ExportInvoice();
            Console.WriteLine("\t\tSố lượng         : {0}", Quantity);
            Console.WriteLine("\t\tThành tiền       : {0}", Cost);
        }   

        public static void EnterDetailList(ref List<InvoiceDetail> invoiceDetails, int listLength)
        {
            for (int i = 0; i < listLength; i++)
            {
                Console.WriteLine("\n\t\tNhập Thông tin sản phẩm thứ {0}:", i + 1);
                InvoiceDetail detail = new InvoiceDetail();
                detail.EnterInformation();
                invoiceDetails.Add(detail); 
            }
        }

        public static void ExportDetailList(ref List<InvoiceDetail> invoiceDetails)
        {
            int i = 1;
            foreach(InvoiceDetail detail in invoiceDetails)
            {
                Console.WriteLine("\n\tThông tin Sản phẩm thứ {0}:", i);
                detail.ExportInformation();
                i++;
            }
        }

        public decimal GetCost(ref Decimal cost)
        {
            cost= quantity * product.Price;
            return cost;
        }
    }
}
