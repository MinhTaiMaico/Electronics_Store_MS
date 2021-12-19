using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    using Electronics_Store_MS.UIController;
    class Battery : Fan
    {
        private bool isChecked;
        private int batteryCapacity;

        public bool IsChecked { get => isChecked; set => isChecked = value; }
        public int BatteryCapacity { get => batteryCapacity; }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy quạt sạc điện";
            UIController.EnterNumber("Nhập dung lượng pin(mAh): ", ref batteryCapacity);
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\tLọai: {0}", Type);
            Console.WriteLine("\tDung lượng pin: {0}", BatteryCapacity);
            Console.WriteLine("\tGiá tiền: {0}", GetPrice(ref price));
        }

        public override decimal GetPrice(ref decimal price)
        {
            price = BatteryCapacity * 500;
            return price;
        }
    }
}
