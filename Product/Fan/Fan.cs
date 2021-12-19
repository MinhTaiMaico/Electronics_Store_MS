using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product.Fan
{
    class Fan : Product
    {
        private string type;

        protected string Type { get => type; set => type = value; }

        public override void ExportInvoice()
        {
            base.ExportInvoice();
        }

        public override void AddToInvoice()
        {
            base.AddToInvoice();
        }
        public override decimal GetPrice(ref decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
