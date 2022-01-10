using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.AirConditioner
{
    using Electronics_Store_MS.Service;
    class OneWay : AirConditioner
    {
        private int _initalPrice = 1000;

        protected int InitalPrice { get => _initalPrice; }


        public override void AddToInvoice()
        {
            base.AddToInvoice();
            Type = "Máy lạnh 1 chiều.";
            InverterTech inverter = new InverterTech();
            UIController.UIController.GetExtraServices(inverter, ref extraServices);
            string extraServiceName = "";
            int extraCount = extraServices.Count;
            for (int i = 0; i < extraCount; i++)
                extraServiceName += $"\t\t\t{extraServices[i].Name}\n";
            ProductDetails += $"\n\t\tLọai            : {Type}\n" +
                              $"\t\tCông nghệ bổ sung: \n{extraServiceName}" +
                              $"\t\tGiá tiền        : {GetPrice(ref _price)}";
        }

        public override void ExportInvoice()
        {
            int extraCount = extraServices.Count;
            base.ExportInvoice();
            Console.WriteLine("\t\tLoại             : {0}", Type);
            Console.Write("\t\tCông nghệ bổ sung: ");
            for(int i = 0; i< extraCount; i++)
            {
                Console.WriteLine("{0}", extraServices[i].Name);
            }
            Console.WriteLine("\t\tGiá tiền         : {0}", GetPrice(ref _price));
        }

        public override decimal GetPrice(ref decimal price)
        {
            Service service = new InverterTech();
            int fee = service.Fee;
            price = _initalPrice + extraServices.Count * fee;
            return price;
        }
    }
}
