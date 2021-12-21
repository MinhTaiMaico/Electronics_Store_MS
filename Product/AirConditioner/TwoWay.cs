using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.AirConditioner
{
    class TwoWay : AirConditioner
    {
        private int initalPrice = 2000;

        protected int InitalPrice { get => initalPrice; }


        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy lạnh 2 chiều.";
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\tLoại: {0}", Type);
        }

        public override decimal GetPrice(ref decimal price)
        {
            return base.GetPrice(ref price);
        }
    }
}
