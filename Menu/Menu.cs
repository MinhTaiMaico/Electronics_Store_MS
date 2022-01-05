using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Electronics_Store_MS.InvoiceManagement;
using Electronics_Store_MS.Product.AirConditioner;
using Electronics_Store_MS.Product.Fan;

namespace Electronics_Store_MS.Menu
{
    public class Menu
    {
        public static void Build(ref List<Invoice> invoices)
        {
            Console.WriteLine("\n\n\t*******************************************************");
            Console.WriteLine("\t*\t1. Nhập thông tin hóa đơn.                    *");
            Console.WriteLine("\t*\t2. Xuất thông tin hóa đơn.                    *");
            Console.WriteLine("\t*\t3. Lưu thông tin hóa đơn thành file text.     *");
            Console.WriteLine("\t*\t4. Thoát.                                     *");
            Console.WriteLine("\t*******************************************************");
            int choice = 0;
            bool isContinue = true;
            do
            {
                UIController.UIController.EnterNumber("\tLựa chọn của bạn là: ", ref choice);

                switch (choice)
                {
                    case 1:
                        int length = 0;
                        UIController.UIController.EnterQuantity("\tNhập Số lượng hóa đơn muốn nhập: ", ref length);
                        Invoice.EnterList(ref invoices, length);
                        ShowMenu($"Bạn đã nhập thành công {length} hóa đơn. Trở về Trang chủ trong giây lát.", 2000);
                        break;
                    case 2:
                        if (invoices.Count == 0)
                            UIController.UIController.BackToMenu("\tChưa nhập bất kì hóa đơn nào.", 1000);
                        else
                            Invoice.ExportListToConsole(ref invoices);
                        break;
                    case 3:
                        if (invoices.Count == 0)
                            UIController.UIController.BackToMenu("\tChưa nhập bất kì hóa đơn nào.", 1000);
                        else
                        {
                            Invoice.ExportListToFile(ref invoices);
                            ShowMenu("\tĐã xuất danh sách hóa đơn (ListInvoice.txt) ra Desktop", 1000);
                        }
                        break;
                    case 4:
                        CloseApps(choice, isContinue);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tChỉ nhập từ 1-4.");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }
        public static void CloseApps(int choice, bool isContinue)
        {
            Console.WriteLine("\tBạn có thực sự muốn thoát? \n\t 1- Có\n\t 0- Không");
            UIController.UIController.EnterNumber("\tLựa chọn của bạn là: ", ref choice);

            do
            {
                switch (choice)
                {
                    case 1:
                        ExitConsole();
                        isContinue = false;
                        break;
                    case 0:
                        UIController.UIController.BackToMenu("\tTrở lại Trang chủ trong giây lát.", 2000);
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tChỉ nhập 1 và 0");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }
        public static void ExitConsole()
        {
            Environment.Exit(0);
        }
        public static void ChooseOneProduct(int choice, bool isContinue, ref Product.Product product)
        {
            do
            {
                Console.WriteLine("\n\t\t\tSản phẩm bao gồm: 1.Máy quạt - 2.Điều hòa");
                UIController.UIController.EnterNumber("\t\t\tBạn chọn SP số: ", ref choice);

                switch (choice)
                {
                    case 1:
                        ChooseOneFan(choice, isContinue, ref product);
                        isContinue = false;
                        break;
                    case 2:
                        ChooseOneAirConditioner(choice, isContinue,ref product);
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\tChỉ nhập 1 và 2");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }

        public static void ChooseOneFan(int choice, bool isContinue, ref Product.Product product)
        {
            do
            {
                Console.WriteLine("\n\t\t\t\tChọn loại quạt: 1.Quạt đứng - 2.Quạt phun sương - 3.Quạt sạc điện");
                UIController.UIController.EnterNumber("\t\t\t\tBạn chọn loại số: ", ref choice);

                switch (choice)
                {
                    case 1:
                        Pedestal pedestal = new Pedestal();
                        pedestal.AddToInvoice();
                        product = pedestal;
                        Console.WriteLine("\n\tSản phẩm đã chọn: ");
                        product.ExportInvoice();
                        isContinue = false;
                        break;
                    case 2:
                        Misting misting = new Misting();
                        misting.AddToInvoice();
                        product = misting;
                        Console.WriteLine("\n\tSản phẩm đã chọn: ");
                        product.ExportInvoice();

                        isContinue = false;
                        break;
                    case 3:
                        Battery battery = new Battery();
                        battery.AddToInvoice();
                        product = battery;
                        Console.WriteLine("\n\tSản phẩm đã chọn: ");
                        product.ExportInvoice();
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\tChỉ nhập từ 1-3");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }

        public static void ChooseOneAirConditioner(int choice, bool isContinue,ref Product.Product product)
        {
            do
            {
                Console.WriteLine("\n\t\t\t\tChọn loại điều hòa: 1.Một chiều - 2.Hai chiều");
                UIController.UIController.EnterNumber("\t\t\t\tBạn chọn loại số: ", ref choice);

                switch (choice)
                {
                    case 1:
                        OneWay one = new OneWay();
                        one.AddToInvoice();
                        product = one;
                        Console.WriteLine("\n\tSản phẩm đã chọn: ");
                        product.ExportInvoice();
                        isContinue = false;
                        break;
                    case 2:
                        TwoWay two = new TwoWay();
                        two.AddToInvoice();
                        product = two;
                        Console.WriteLine("\n\tSản phẩm đã chọn: ");
                        product.ExportInvoice();
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\tChỉ nhập 1 và 2");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }
        public static void ShowMenu(string message, int miliseconds)
        {
            string[] args = null;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t" + message);
            Console.ResetColor();
            Thread.Sleep(miliseconds);
            Console.Clear();
            Program.Main(args);
            Console.ReadLine();
        }
    }
}
