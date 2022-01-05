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
        public string productDetails;

        public virtual void AddToInvoice()
        {
            UIController.EnterInformation("\t\t\t\tNhập mã SP: ", ref iD); 
            UIController.EnterInformation("\t\t\t\tNhập tên SP: ", ref name);
            UIController.EnterInformation("\t\t\t\tNhập tên nhà SX: ", ref provider);
        }
        public virtual void ExportInvoice()
        {
            Console.WriteLine("\n\t\tMã SP            : {0}", ID);
            Console.WriteLine("\t\tTên SP           : {0}", Name);
            Console.WriteLine("\t\tThuộc nhà SX     : {0}", Provider);
            productDetails += $"\tMã SP: {ID}\n" +
                              $"\tTên SP: {Name}\n" +
                              $"\tThuộc nhà SX: {Provider}";
        }
        public abstract decimal GetPrice(ref decimal price);
    }
}
