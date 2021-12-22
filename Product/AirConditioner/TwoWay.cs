using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.AirConditioner
{
    using Electronics_Store_MS.Service;

    class TwoWay : AirConditioner
    {
        private int initalPrice = 2000;

        protected int InitalPrice { get => initalPrice; }


        public override void AddToInvoice()
        {
            InverterTech inverter = new InverterTech();
            Antibacterial antibacterial = new Antibacterial();
            Deodorization deodorization = new Deodorization();
            base.AddToInvoice();
            Type = "Máy lạnh 2 chiều.";
            UIController.UIController.GetExtraServices(inverter, ref extraServices);
            UIController.UIController.GetExtraServices(antibacterial, ref extraServices);
            UIController.UIController.GetExtraServices(deodorization, ref extraServices);

        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
            Console.WriteLine("\tLoại: {0}", Type);
            Console.Write("\tCông nghệ bổ sung: ");
            for (int i = 0; i < extraServices.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0}", extraServices[i].Name);
                }
                else
                {
                    Console.WriteLine("\t\t\t   {0}", extraServices[i].Name);
                }
            }
            Console.WriteLine("\tGiá: {0}", GetPrice(ref price));
        }

        public override decimal GetPrice(ref decimal price)
        {
            Service service = new InverterTech();
            int fee = service.Fee;
            price = initalPrice + extraServices.Count * fee;
            return price;
        }
    }
}
