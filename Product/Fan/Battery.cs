using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    using Electronics_Store_MS.UIController;
    class Battery : Fan
    {
        private int batteryCapacity;

        public int BatteryCapacity { get => batteryCapacity; }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy quạt sạc điện";
            UIController.EnterNumber("\t\t\t\tNhập dung lượng pin(mAh): ", ref batteryCapacity);
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\t\tLọai             : {0}", Type);
            Console.WriteLine("\t\tDung lượng pin   : {0}", BatteryCapacity);
            Console.WriteLine("\t\tGiá tiền         : {0}", GetPrice(ref price));
            productDetails += $"\tLọai: {Type}\n" +
                              $"\tDung lượng pin: {BatteryCapacity}\n" +
                              $"\tGiá tiền: {GetPrice(ref price)}";
        }

        public override decimal GetPrice(ref decimal price)
        {
            price = BatteryCapacity * 500;
            return price;
        }
    }
}
