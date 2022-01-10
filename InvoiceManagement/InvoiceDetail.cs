using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.InvoiceManagement
{
    using Electronics_Store_MS.Product;
    using Electronics_Store_MS.UIController;

    public class InvoiceDetail
    {
        private int _quantity;
        private decimal _cost;
        private Product _product;

        public int Quantity { get => _quantity; }
        public decimal Cost { get => _cost; }
        public Product Product { get => _product; }

        public void EnterInformation()
        {
            int choice = 0;
            bool isContinue = true;
            Menu.Menu.ChooseOneProduct(choice, isContinue, ref _product);
            UIController.EnterQuantity("\t\t\tNhập Số lượng: ", ref _quantity);
            GetCost(ref _cost);
        }

        public void ExportInformation()
        {
            _product.ExportInvoice();
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
            cost= _quantity * _product.Price;
            return cost;
        }
    }
}
