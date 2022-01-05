using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Customer
{
    public class Customer
    {
        private string iD;
        private string name;
        private string address;
        private string phoneNum;

        public string ID { get => iD; }
        public string Name { get => name; }
        public string Address { get => address; }
        public string PhoneNum { get => phoneNum; }

        public void GetInformation()
        {
            UIController.UIController.EnterInformation("\t\tNhập Mã khách hàng: ", ref iD);
            UIController.UIController.EnterInformation("\t\tNhập Tên khách hàng: ", ref name);
            UIController.UIController.EnterInformation("\t\tNhập Địa chỉ khách hàng: ", ref address);
            UIController.UIController.EnterPhoneNumber("\t\tNhập SĐT khách hàng: ", ref phoneNum);
        }
        public void ExportInformation()
        {
            Console.WriteLine("\n\tThông tin khách hàng: ");
            Console.WriteLine("\t\tMã khách hàng     : {0}", ID);
            Console.WriteLine("\t\tTên khách hàng    : {0}", Name);
            Console.WriteLine("\t\tĐịa chỉ khách hàng: {0}", Address);
            Console.WriteLine("\t\tSĐT khách hàng    : {0}", PhoneNum);
        }
    }
}
