using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    using Electronics_Store_MS.UIController;

    class Misting : Fan
    {
        private int waterCapacity;

        public int WaterCapacity { get => waterCapacity; set => waterCapacity = value; }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy quạt phun sương";
            UIController.EnterNumber("\t\t\t\tNhập dung tích nước(l): ", ref waterCapacity);
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\t\tLọai             : {0}", Type);
            Console.WriteLine("\t\tDung tích nước   : {0}", WaterCapacity);
            Console.WriteLine("\t\tGiá tiền         : {0}", GetPrice(ref price));
            productDetails += $"\tLọai: {Type}\n" +
                              $"\tDung tích nước: {WaterCapacity}\n" +
                              $"\tGiá tiền: {GetPrice(ref price)}";
        }

        public override decimal GetPrice(ref decimal price)
        {
            price = WaterCapacity * 400;
            return price;
        }
    }
}
