using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Product
{
    using Electronics_Store_MS.UIController;
    public abstract class Product
    {
        private string _iD;
        private string _name;
        private string _provider;
        protected decimal _price;

        protected string Name { get => _name; }
        protected string ID { get => _iD; }
        protected string Provider { get => _provider; }
        public decimal Price { get => _price; }
        public string ProductDetails;

        public virtual void AddToInvoice()
        {
            UIController.EnterInformation("\t\t\t\tNhập mã SP: ", ref _iD); 
            UIController.EnterInformation("\t\t\t\tNhập tên SP: ", ref _name);
            UIController.EnterInformation("\t\t\t\tNhập tên nhà SX: ", ref _provider);
            ProductDetails += $"\tMã SP           : {ID}\n" +
                              $"\t\tTên SP          : {Name}\n" +
                              $"\t\tThuộc nhà SX    : {Provider}";
        }
        public virtual void ExportInvoice()
        {
            Console.WriteLine("\n\t\tMã SP            : {0}", ID);
            Console.WriteLine("\t\tTên SP           : {0}", Name);
            Console.WriteLine("\t\tThuộc nhà SX     : {0}", Provider);
        }
        public abstract decimal GetPrice(ref decimal price);
    }
}
