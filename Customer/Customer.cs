using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Customer
{
    public class Customer
    {
        private string _iD;
        private string _name;
        private string _address;
        private string _phoneNum;

        public string ID { get => _iD; }
        public string Name { get => _name; }
        public string Address { get => _address; }
        public string PhoneNum { get => _phoneNum; }

        public void GetInformation()
        {
            UIController.UIController.EnterInformation("\t\tNhập Mã khách hàng: ", ref _iD);
            UIController.UIController.EnterInformation("\t\tNhập Tên khách hàng: ", ref _name);
            UIController.UIController.EnterInformation("\t\tNhập Địa chỉ khách hàng: ", ref _address);
            UIController.UIController.EnterPhoneNumber("\t\tNhập SĐT khách hàng: ", ref _phoneNum);
        }
        public void ExportInformation()
        {
            Console.WriteLine("\n\tThông tin khách hàng: \n");
            Console.WriteLine("\t\tMã khách hàng     : {0}", ID);
            Console.WriteLine("\t\tTên khách hàng    : {0}", Name);
            Console.WriteLine("\t\tĐịa chỉ khách hàng: {0}", Address);
            Console.WriteLine("\t\tSĐT khách hàng    : {0}", PhoneNum);
        }
    }
}
