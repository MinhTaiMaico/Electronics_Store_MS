using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    class Pedestal : Fan
    {
        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy quạt đứng";
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\t\tLọai             : {0}", Type);
            Console.WriteLine("\t\tGiá tiền         : {0}", GetPrice(ref price));
            productDetails += $"\tLọai: {Type}\n" +
                              $"\tGiá tiền: {GetPrice(ref price)}";
        }

        public override decimal GetPrice(ref decimal price)
        {
            price = 500;
            return price;
        }
    }
}
