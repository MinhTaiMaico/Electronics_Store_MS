using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Electronics_Store_MS.UIController
{
    using Electronics_Store_MS.Menu;
    using Electronics_Store_MS.Service;

    public class UIController
    {
        public static void EnterInformation(string label, ref string information)
        {
            int limitOfEntries = 5;
            for (int i = 0; i < limitOfEntries; i++)
            {
                Console.WriteLine();
                Console.Write(label);
                information = Console.ReadLine();
                if (EmptyCheck(ref information, i, limitOfEntries)) { break; }
            }
        }

        public static void EnterNumber(string label, ref int number)
        {
            string information;

            int limitOfEntries = 5;
            for (int i = 0; i < limitOfEntries; i++)
            {
                Console.WriteLine();
                Console.Write(label);
                information = Console.ReadLine();
                if (NumericCheck(information, i, limitOfEntries, ref number)) { break; }
            }
        }

        public static void PrintInformation(string label, string information)
        {

        }

        public static void BackToMenu(String message, int miliseconds)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(miliseconds);
            Console.Clear();
            Menu.Show();
            Console.ReadLine();
        }

        public static bool EmptyCheck(ref string information, int i, int limitOfEntries)
        {
            if (String.IsNullOrWhiteSpace(information.ToString()))
            {
                ShowAlert("Thông tin này không được bỏ trống. Vui lòng nhập lại.", i, limitOfEntries);
                return false;
            }
            else
                return true;
        }


        public static bool PhoneCheck(ref string information, int i, int limitOfEntries)
        {
            uint value;

            bool isChecked = uint.TryParse(information, out value);

            if (isChecked != true)
            {
                ShowAlert("Nhập sai định dạng, phải nhập số tự nhiên!", i, limitOfEntries);
                return false;
            }
            else
            {
                information = value.ToString();
                return true;
            }
        }

        public static bool NumericCheck(string information, int i, int limitOfEntries, ref int number)
        {
            uint value;

            bool isChecked = uint.TryParse(information, out value);

            if (isChecked != true)
            {
                ShowAlert("Nhập sai định dạng, phải nhập số tự nhiên!", i, limitOfEntries);
                return false;
            }
            else
            {
                number = Convert.ToInt32(value);
                return true;
            }
        }
        public static void ShowAlert(string alert, int i, int limitOfEntries)
        {
            if (i < (limitOfEntries - 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(alert + " (Còn {0} lượt)", limitOfEntries - i - 1);
                Console.ResetColor();
            }
            else
            {
                BackToMenu("Hết lượt nhập, quay lại trang chủ trong giây lát.", 2000);
            }
        }

        public static void GetExtraServices(Service service, ref List<Service> services)
        {
            int choice = -1;

            if (EnterIOChoice(choice, service) && service.IsAdded == true)
                services.Add(service);
        }
        public static bool EnterIOChoice(int choice, Service service)
        {
            bool isChecked = false; ;
            int limitOfEntries = 5;
            for (int i = 0; i < limitOfEntries; i++)
            {
                EnterNumber($"Thêm {service.AddServiceName()} ? (1-Có. 0-Không)", ref choice);
                if (choice != 1 && choice != 0)
                {
                    ShowAlert("Nhập sai định dạng. Chỉ có 2 lựa chọn (0-1).", i, limitOfEntries);
                }
                else
                {
                    if (choice == 1)
                    {
                        service.IsAdded = true;
                    }
                    else 
                    {
                        service.IsAdded = false;
                    }
                    isChecked = true;
                    break;
                }
            }
            return isChecked;
        }
    }
}
