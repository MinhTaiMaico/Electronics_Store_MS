﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    using Electronics_Store_MS.UIController;

    class Misting : Fan
    {
        private bool isChecked;
        private int waterCapacity;

        public bool IsChecked { get => isChecked; set => isChecked = value; }
        public int WaterCapacity { get => waterCapacity; set => waterCapacity = value; }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy quạt phun sương";
            UIController.EnterNumber("Nhập dung tích nước(l): ", ref waterCapacity);
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\tLoại: {0}", Type);
            Console.WriteLine("\tDung tích nước: {0}", WaterCapacity);
            Console.WriteLine("\tGiá tiền: {0}", GetPrice(ref price));
        }

        public override decimal GetPrice(ref decimal price)
        {
            price = WaterCapacity * 400;
            return price;
        }
    }
}
