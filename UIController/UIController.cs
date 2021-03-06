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
        public static int limitOfEntries = 5;

        public static void EnterInformation(string label, ref string information)
        {
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
                ShowAlert("\tThông tin này không được bỏ trống. Vui lòng nhập lại.", numberOfEntries, limitOfEntries);
                return false;
            }
            else
                return true;
        }

        public static void EnterNumber(string label, ref int number)
        {
            string information;

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
                ShowAlert("\tNhập sai định dạng, phải nhập số tự nhiên.", numberOfEntries, limitOfEntries);
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
            long value;

            bool isChecked = long.TryParse(information, out value);
            if (isChecked != true)
            {
                ShowAlert("\tNhập sai định dạng, phải nhập số tự nhiên.", numberOfEntries, limitOfEntries);
                return false;
            }
            else
            {
                if (information.Length == 10 || information.Length == 11) { return true; }
                else
                {
                    ShowAlert("\tNhập sai định dạng. SĐT phải có độ dài 10 hoặc 11 kí tự.", numberOfEntries, limitOfEntries);
                    return false;
                }
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
                BackToMenu("\tHết lượt nhập, quay lại trang chủ trong giây lát.", 2000);
            }
        }

        public static void BackToMenu(String message, int miliseconds)
        {
            string[] args= null;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(miliseconds);
            Console.Clear();
            Program.Main(args);
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
                EnterNumber($"\t\t\t\tThêm {service.AddServiceName()} ? (1.Có - 0.Không) ", ref choice);
                if (choice != 1 && choice != 0)
                    ShowAlert("\t\t\t\tNhập sai định dạng. Chỉ có 2 lựa chọn (1.Có - 0.Không).", i, limitOfEntries);
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

        public static void EnterDate(string label,ref DateTime dateTime)
        {
            int year = 0, month = 0, day = 0;
            Console.WriteLine(label);
            EnterMonth("\t\tNhập Tháng: ",ref month, ref year);

            for (int i = 0; i < limitOfEntries; i++)
                {
                    Console.WriteLine();
                    Console.Write("\t\tNhập Ngày: ");
                    string information = Console.ReadLine();
                    if (NumericCheck(information, i, limitOfEntries, ref day))
                    {
                        if (IsDay(day, month, year, i, limitOfEntries)) { break; }
                    }
                }

            dateTime = new DateTime(year, month, day);
        }

        public static bool IsDay(int day,int month, int year, int numberOfEntries, int limitOfEntries)
        {
            DateTime now = DateTime.Now;
            bool isTrue = true;
            if (day < 32 && day > 0)
            {
                if (DateTime.IsLeapYear(year) && month == 2)
                {
                    if (day > 29)
                    {
                        ShowAlert("\tSai định dạng. Ngày trong tháng 2 của năm nhuận phải từ 1-29.", numberOfEntries, limitOfEntries);
                        isTrue = false;
                    }
                    else isTrue = true;
                }
                else
                {
                    if (year == now.Year && month == now.Month)
                    {
                        if (day > now.Day)
                        {
                            ShowAlert("\tSai định dang. Ngày bạn nhập lớn hơn ngày hiện tại.", numberOfEntries, limitOfEntries);
                            isTrue = false;
                        }
                        else isTrue = true;
                    }
                    else if (month == 4 || month == 6 || month == 9 || month == 11)
                    {
                        if (day > 30)
                        {
                            ShowAlert("\tSai định dạng. Ngày trong tháng này phải từ 1-30.", numberOfEntries, limitOfEntries);
                            isTrue = false;
                        }
                        else isTrue = true;
                    }
                    else if(month == 1 || month == 3 || month == 5 || month == 7|| month == 8 || month == 10 || month == 12)
                    {
                        if (day > 31)
                        {
                            ShowAlert("\tSai định dạng. Ngày trong tháng này phải từ 1-31.", numberOfEntries, limitOfEntries);
                            isTrue = false;
                        }
                        else isTrue = true;
                    }
                    else if (month == 2)
                    {
                        if (day > 28)
                        {
                            ShowAlert("\tSai định dạng. Ngày trong tháng này phải từ 1-28.", numberOfEntries, limitOfEntries);
                            isTrue = false;
                        }
                        else isTrue = true;
                    }
                }
            }
            else
            {
                ShowAlert("\tSai định dạng. Ngày trong tháng phải từ 1 - 31.", numberOfEntries, limitOfEntries);
                isTrue = false;
            }

            return isTrue;
        }

        public static void EnterMonth(string label, ref int month, ref int year)
        {
            EnterYear("\t\tNhập Năm: ",ref year);
            string information;

            for (int i = 0; i < limitOfEntries; i++)
            {
                Console.WriteLine();
                Console.Write(label);
                information = Console.ReadLine();
                if (NumericCheck(information, i, limitOfEntries, ref month))
                {
                    if (IsMonth(year, month, i, limitOfEntries)) { break; }
                }
            }
        }

        public static bool IsMonth(int year, int month, int numberOfEnties, int limitOfEntries)
        {
            DateTime now = DateTime.Now;
            bool isTrue;

            bool isGreaterThan12 = month > 12;
            bool isSmallerThan0 = month <= 0;
            if (isGreaterThan12)
            {
                ShowAlert("\tSai định dạng. Tháng bạn nhập lớn hơn 12.", numberOfEnties, limitOfEntries);
                isTrue = false;
            }
            else if (isSmallerThan0)
            {
                ShowAlert("\tSai định dạng. Tháng bạn nhập nhỏ hơn hoặc bằng 0.", numberOfEnties, limitOfEntries);
                isTrue = false;
            } 
            else if (year == now.Year && month > now.Month)
            {
                ShowAlert("\tSai định dạng. Tháng bạn nhập lớn hơn tháng hiện tại.", numberOfEnties, limitOfEntries);
                isTrue = false;
            }
            else
                isTrue = true;

            return isTrue;
        }

        public static void EnterYear(string label, ref int year)
        {
            string information;

            for (int i = 0; i < limitOfEntries; i++)
            {
                Console.WriteLine();
                Console.Write(label);
                information = Console.ReadLine();
                if (NumericCheck(information, i, limitOfEntries, ref year))
                {
                    if (IsYear(year, i, limitOfEntries)) { break; }
                }
            }
        }

        public static bool IsYear(int year, int numberOfEnties, int limitOfEntries)
        {
            bool isTrue;

            bool isGreaterThanNow = year > DateTime.Now.Year;
            bool isSmallerThan20 = year < DateTime.Now.AddYears(-20).Year;
            if (isGreaterThanNow)
            {
                ShowAlert($"\tSai định dạng. Năm bạn nhập lớn hơn năm {DateTime.Now.Year}.", numberOfEnties, limitOfEntries);
                isTrue = false; 
            }
            else if (isSmallerThan20)
            {
                ShowAlert("\tSai định dạng. Năm bạn nhập vượt quá thời hạn (20 năm trở lại đây).", numberOfEnties, limitOfEntries);
                isTrue = false;
            }
            else
                isTrue = true;
            
            return isTrue;
        }
        public static void EnterQuantity(string label,ref int quantity)
        {
            int length = 0;
            for(int i =0; i < limitOfEntries; i++)
            {
                EnterNumber(label, ref length);
                if (length < 0 || length == 0)
                {
                    ShowAlert("\tSố lượng phải lớn hơn 0. ", i , limitOfEntries);
                }
                else
                {
                    quantity = length;
                    break;
                }
            }
        }
    }
}
