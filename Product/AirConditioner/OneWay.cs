using System;
using System.Collections.Generic;
using System.Text;
using Electronics_Store_MS.Service;

namespace Electronics_Store_MS.Product.AirConditioner
{
    class OneWay : AirConditioner
    {
        private int initalPrice = 1000;

        protected int InitalPrice { get => initalPrice; }


        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy lạnh 1 chiều.";
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\tLoại: {0}", Type);
        }

        public override decimal GetPrice(ref decimal price)
        {
            
            return price;
        }
    }
}
