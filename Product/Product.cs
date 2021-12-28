using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product
{
    using Electronics_Store_MS.UIController;
    public abstract class Product
    {
        private string iD;
        private string name;
        private string provider;
        protected decimal price;

        protected string Name { get => name; }
        protected string ID { get => iD; }
        protected string Provider { get => provider; }
        public decimal Price { get => price; }

        public virtual void AddToInvoice()
        {
            UIController.EnterInformation("Nhập mã SP: ", ref iD);
            UIController.EnterInformation("Nhập tên SP: ", ref name);
            UIController.EnterInformation("Nhập tên nhà SX: ", ref provider);
        }
        public virtual void ExportInvoice()
        {
            Console.WriteLine("\tMã SP: {0}", ID);
            Console.WriteLine("\tTên SP: {0}", Name);
            Console.WriteLine("\tThuộc nhà SX: {0}", Provider);
        }
        public abstract decimal GetPrice(ref decimal price);
    }
}
