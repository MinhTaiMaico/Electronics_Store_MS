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
            UIController.UIController.EnterInformation("Nhập Mã khách hàng: ", ref iD);
            UIController.UIController.EnterInformation("Nhập Tên khách hàng: ", ref name);
            UIController.UIController.EnterInformation("Nhập Địa chỉ khách hàng: ", ref address);
            UIController.UIController.EnterPhoneNumber("Nhập SĐT khách hàng: ", ref phoneNum);
        }
        public void ExportInformation()
        {
            Console.WriteLine("Thông tin khách hàng: ");
            Console.WriteLine("\tMã khách hàng     : {0}", ID);
            Console.WriteLine("\tTên khách hàng    : {0}", Name);
            Console.WriteLine("\tĐịa chỉ khách hàng: {0}", Address);
            Console.WriteLine("\tSĐT khách hàng    : {0}", PhoneNum);
        }
    }
}
