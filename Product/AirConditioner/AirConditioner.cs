using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.AirConditioner
{
    using Electronics_Store_MS.Service;
    class AirConditioner : Product
    {
        private string type;
        public List<Service> extraServices;

        protected string Type { get => type; set => type = value; }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
        }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
        }
        public override decimal GetPrice(ref decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
