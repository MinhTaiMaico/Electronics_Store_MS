using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Electronics_Store_MS.InvoiceManagement
{
    using Electronics_Store_MS.Customer;
    using Electronics_Store_MS.UIController;
    using System.IO;

    public class Invoice
    {
        private string _iD;
        private List<InvoiceDetail> _invoiceDetails = new List<InvoiceDetail>();
        private Customer _customer = new Customer();
        private DateTime _date;
        private decimal _totalCost;

        public string ID { get => _iD; }
        public List<InvoiceDetail> InvoiceDetails { get => _invoiceDetails; }
        public Customer Customer { get => _customer; }
        public DateTime Date { get => _date; }
        public decimal TotalCost { get => _totalCost; }

        public void EnterInformation()
        {
            int length = 0;
            UIController.EnterInformation("\tNhập Mã hóa đơn: ", ref _iD);
            UIController.EnterDate("\n\tNhập Ngày lập hóa đơn: ", ref _date);
            Console.WriteLine("\n\tNhập Thông tin khách hàng:");
            _customer.GetInformation();
            UIController.EnterQuantity("\tNhập Số lượng các Loại sản phẩm trong hóa đơn: ", ref length);
            InvoiceDetail.EnterDetailList(ref _invoiceDetails, length);
            GetTotalCost(ref _totalCost);
        }

        public void ExportInformation()
        {
            Console.Clear();
            Console.WriteLine("\tMã hóa đơn         : {0}", ID); 
            Console.WriteLine("\tNgày lập hóa đơn   : {0}\n", Date.ToShortDateString());
            _customer.ExportInformation();
            InvoiceDetail.ExportDetailList(ref _invoiceDetails);
            Console.WriteLine("\tTổng tiền          : {0}.\n.", TotalCost);
        }

        public decimal GetTotalCost(ref Decimal totalCost)
        {
            var costs = from invoiceDetail in _invoiceDetails
                        select invoiceDetail.Cost;
            totalCost = costs.Sum();
            
            return totalCost;
        }

        public static void EnterList(ref List<Invoice> invoices, int length)
        {
            for (int i=0; i < length; i++)
            {
                Console.WriteLine("\n\tNhập thông tin Hóa đơn thứ {0}:", i + 1);
                Invoice invoice = new Invoice();
                invoice.EnterInformation();
                invoices.Add(invoice);
            }
        }

        public static void ExportListToConsole(ref List<Invoice> invoices)
        {
            int choice = 0;
            int length = invoices.Count;
            Console.WriteLine("\tDanh sách hóa đơn:");
            for (int i = 0; i < length; i++)
                Console.WriteLine("\t{0}. Hóa đơn số {0}", i + 1);
            for (int i = 0; i < UIController.limitOfEntries; i++)
            {
                UIController.EnterQuantity("\tBạn muốn xem hóa đơn số:", ref choice);
                if (choice <= length)
                {
                    Console.WriteLine("", choice);
                    MoveOver($"\t\tTHÔNG TIN HÓA ĐƠN THỨ {choice}\n", ref invoices, choice - 1);
                    break;
                }
                else
                    UIController.ShowAlert("\tHóa đơn không tồn tại.", i, UIController.limitOfEntries);
            }
        }
        public static void MoveOver(string message, ref List<Invoice> invoices, int index)
        {
            Console.WriteLine(message);
            invoices[index].ExportInformation();
            int listCount = invoices.Count;
            bool isChecked = false;

            do
            {
                Console.WriteLine("\tSử dụng các phím mũi tên Lên/Xuống, Trái/Phải để di chuyển giữa các hóa đơn.\n\tNhấn Bất kì nút nào để trở lại Trang chủ.");
                var keyPress = Console.ReadKey();
                switch (keyPress.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.DownArrow:
                        if (index > 0)
                        {
                            index--;
                            invoices[index].ExportInformation();
                        }
                        else
                        {
                            index = listCount - 1;
                            invoices[index].ExportInformation();
                        }
                        isChecked = true;
                        break;

                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                        if (index == listCount - 1)
                        {
                            index = 0;
                            invoices[index].ExportInformation();
                        }
                        else
                        {
                            index++;
                            invoices[index].ExportInformation();
                        }
                        isChecked = true;
                        break;
                    default:
                        Menu.Menu.ShowMenu("Quay lại trang chủ trong giây lát. ", 1500);
                        isChecked = false;
                        break;
                } 
            } while (isChecked);
        }

        public static void ExportListToFile(ref List<Invoice> invoices)
        {
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ListInvoice.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(fs);
            int i = 0;
            foreach (Invoice invoice in invoices)
            {
                i++;
                sw.WriteLine("\t==================================================\n");
                sw.WriteLine($"\tThông tin hóa đơn thứ {i} : ");
                sw.WriteLine($"\tMã hóa đơn        : {invoice.ID}");
                sw.WriteLine($"\tNgày lập          : {invoice.Date.ToShortDateString()}");
                sw.WriteLine($"\tTổng thanh toán   : {invoice.TotalCost}\n");
                sw.WriteLine("\t--------------------------------------------------");
                sw.WriteLine("\tThông tin khách hàng :\n");
                sw.WriteLine("\tMã khách hàng       : {0}", invoice.Customer.ID);
                sw.WriteLine("\tTên khách hàng      : {0}", invoice.Customer.Name);
                sw.WriteLine("\tĐịa chỉ khách hàng  : {0}", invoice.Customer.Address);
                sw.WriteLine("\tSĐT khách hàng      : {0}\n", invoice.Customer.PhoneNum);
                sw.WriteLine($"\t--------------------------------------------------\n");
                sw.WriteLine("\tDanh sách các loại SP trong hóa đơn :\n");
                int invoiceCount = invoice.InvoiceDetails.Count;
                for (int j = 0; j < invoiceCount; j++)
                {
                    sw.WriteLine($"\tSản phẩm thứ {j + 1}:");
                    sw.WriteLine($"\t{invoice.InvoiceDetails[j].Product.ProductDetails}");
                    sw.WriteLine($"\t\tSố lượng        : {invoice.InvoiceDetails[j].Quantity}");
                    sw.WriteLine($"\t\tThành tiền      : {invoice.InvoiceDetails[j].Cost}\n");
                }
                sw.WriteLine();
            }
            sw.Flush();
            fs.Close();
        }
    }
}
