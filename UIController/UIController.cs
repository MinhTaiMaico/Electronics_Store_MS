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

        public static bool EmptyCheck(ref string information, int numberOfEntries, int limitOfEntries)
        {
            if (String.IsNullOrWhiteSpace(information.ToString()))
            {
                ShowAlert("Thông tin này không được bỏ trống. Vui lòng nhập lại.", numberOfEntries, limitOfEntries);
                return false;
            }
            else
                return true;
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

        public static bool NumericCheck(string information, int numberOfEntries, int limitOfEntries, ref int number)
        {
            uint value;

            bool isChecked = uint.TryParse(information, out value);

            if (isChecked != true)
            {
                ShowAlert("Nhập sai định dạng, phải nhập số tự nhiên.", numberOfEntries, limitOfEntries);
                return false;
            }
            else
            {
                number = Convert.ToInt32(value);
                return true;
            }
        }

        public static void EnterPhoneNumber(string label, ref string phoneNumber)
        {
            int limitOfEntries = 5;
            for (int i = 0; i < limitOfEntries; i++)
            {
                Console.WriteLine();
                Console.Write(label);
                phoneNumber = Console.ReadLine();
                if (PhoneCheck(ref phoneNumber, i, limitOfEntries)) { break; }
            }
        }

        public static bool PhoneCheck(ref string information, int numberOfEntries, int limitOfEntries)
        {
            uint value;

            bool isChecked = uint.TryParse(information, out value);

            if (isChecked != true)
            {
                ShowAlert("Nhập sai định dạng, phải nhập số tự nhiên.", numberOfEntries, limitOfEntries);
                return false;
            }
            else
            {
                information = value.ToString();
                if (information.Trim().Length != 10 && information.Trim().Length != 11)
                {
                    ShowAlert("Nhập sai định dạng. SĐT phải có độ dài 10 hoặc 11 kí tự.", numberOfEntries, limitOfEntries);
                    return false;
                }
                else 
                    return true;
            }
        }

        public static void ShowAlert(string alert, int numberOfEntries, int limitOfEntries)
        {
            if (numberOfEntries < (limitOfEntries - 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(alert + " (Còn {0} lượt)", limitOfEntries - numberOfEntries - 1);
                Console.ResetColor();
            }
            else
            {
                BackToMenu("Hết lượt nhập, quay lại trang chủ trong giây lát.", 2000);
            }
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

        public static void GetExtraServices(Service service, ref List<Service> services)
        {
            int choice = -1;

            if (WhatYourChoice(choice, service) && service.IsAdded == true)
                services.Add(service);
        }

        public static bool WhatYourChoice(int choice, Service service)
        {
            bool isChecked = false; ;
            int limitOfEntries = 5;
            for (int i = 0; i < limitOfEntries; i++)
            {
                EnterNumber($"Thêm {service.AddServiceName()} ? (1.Có - 0.Không)", ref choice);
                if (choice != 1 && choice != 0)
                    ShowAlert("Nhập sai định dạng. Chỉ có 2 lựa chọn (1.Có - 0.Không).", i, limitOfEntries);
                else
                {
                    if (choice == 1)
                        service.IsAdded = true;
                    else 
                        service.IsAdded = false;
                    isChecked = true;
                    break;
                }
            }
            return isChecked;
        }
    }
}
