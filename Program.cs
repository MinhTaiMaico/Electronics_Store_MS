using System;
using Electronics_Store_MS.Product.Fan;

namespace Electronics_Store_MS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int choice = 0;
            bool isContinue = true;
            do
            {
                Console.WriteLine("Chọn loại quạt: 1.Quạt đứng - 2.Quạt phun sướng - 3.Quạt sạc điện");
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
            }
            while (isContinue);
        }
    }
}
