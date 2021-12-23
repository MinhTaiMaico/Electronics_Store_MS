using System;
using System.Collections.Generic;
using System.Text;
using Electronics_Store_MS.Product.AirConditioner;
using Electronics_Store_MS.Product.Fan;

namespace Electronics_Store_MS.Menu
{
    public class Menu
    {
        public static void Show()
        {
            Console.WriteLine("\n\n\t*******************************************************");
            Console.WriteLine("\t*\t1. Nhập thông tin hóa đơn.                    *");
            Console.WriteLine("\t*\t2. Xuất thông tin hóa đơn.                    *");
            Console.WriteLine("\t*\t3. Lưu thông tin hóa đơn thành file text.     *");
            Console.WriteLine("\t*\t4. Thoát.                                     *");
            Console.WriteLine("\t*******************************************************");
        }
        public static void CloseApps(int choice, bool isContinue)
        {
            Console.WriteLine("Bạn có thực sự muốn thoát? \n 1- Có\n 0- Không");
            UIController.UIController.EnterNumber("Lựa chọn của bạn là: ", ref choice);

            do
            {
                switch (choice)
                {
                    case 1:
                        ExitConsole();
                        isContinue = false;
                        break;
                    case 0:
                        UIController.UIController.BackToMenu("Trở lại Trang chủ trong giây lát.", 2000);
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chỉ nhập 1 và 0");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }
        public static void ExitConsole()
        {
            Environment.Exit(0);
        }
        public static void ChooseOneProduct(int choice, bool isContinue)
        {
            do
            {
                Console.WriteLine("Sản phẩm bao gồm: 1.Máy quạt - 2.Điều hòa");
                UIController.UIController.EnterNumber("Bạn chọn SP số: ", ref choice);

                switch (choice)
                {
                    case 1:
                        ChooseOneFan(choice, isContinue);
                        break;
                    case 2:
                        ChooseOneAirConditioner(choice, isContinue);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chỉ nhập 1 và 2");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }

        public static void ChooseOneFan(int choice, bool isContinue)
        {
            do
            {
                Console.WriteLine("Chọn loại quạt: 1.Quạt đứng - 2.Quạt phun sương - 3.Quạt sạc điện");
                UIController.UIController.EnterNumber("Bạn chọn loại số: ", ref choice);

                switch (choice)
                {
                    case 1:
                        Pedestal pedestal = new Pedestal();
                        pedestal.AddToInvoice();
                        pedestal.ExportInvoice();
                        isContinue = false;
                        Console.ReadKey();
                        break;
                    case 2:
                        Misting misting = new Misting();
                        misting.AddToInvoice();
                        misting.ExportInvoice();
                        Console.ReadKey();
                        isContinue = false;
                        break;
                    case 3:
                        Battery battery = new Battery();
                        battery.AddToInvoice();
                        battery.ExportInvoice();
                        Console.ReadKey();
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chỉ nhập từ 1-3");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }

        public static void ChooseOneAirConditioner(int choice, bool isContinue)
        {
            do
            {
                Console.WriteLine("Chọn loại điều hòa: 1.Một chiều - 2.Hai chiều");
                UIController.UIController.EnterNumber("Bạn chọn loại số: ", ref choice);

                switch (choice)
                {
                    case 1:
                        OneWay one = new OneWay();
                        one.AddToInvoice();
                        one.ExportInvoice();
                        isContinue = false;
                        Console.ReadKey();
                        break;
                    case 2:
                        TwoWay misting = new TwoWay();
                        misting.AddToInvoice();
                        misting.ExportInvoice();
                        Console.ReadKey();
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chỉ nhập 1 và 2");
                        Console.ResetColor();
                        break;
                }
            } while (isContinue);
        }
    }
}
