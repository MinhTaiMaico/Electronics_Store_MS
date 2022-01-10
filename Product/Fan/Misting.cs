using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    using Electronics_Store_MS.UIController;

    class Misting : Fan
    {
        private int _waterCapacity;

        public int WaterCapacity { get => _waterCapacity; set => _waterCapacity = value; }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy quạt phun sương";
            UIController.EnterQuantity("\t\t\t\tNhập dung tích nước(l): ", ref _waterCapacity);
            ProductDetails += $"\n\t\tLọai            : {Type}\n" +
                              $"\t\tDung tích nước  : {WaterCapacity}\n" +
                              $"\t\tGiá tiền        : {GetPrice(ref _price)}";
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\t\tLọai             : {0}", Type);
            Console.WriteLine("\t\tDung tích nước   : {0}", WaterCapacity);
            Console.WriteLine("\t\tGiá tiền         : {0}", GetPrice(ref _price));
        }

        public override decimal GetPrice(ref decimal price)
        {
            price = WaterCapacity * 400;
            return price;
        }
    }
}
