using System;

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
            Menu.Menu.Show();
            do
            {
                UIController.UIController.EnterNumber("\tLựa chọn của bạn là: ", ref choice);

                switch (choice)
                {
                    case 1:
                        Menu.Menu.ChooseOneProduct(choice, isContinue);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Menu.Menu.CloseApps(choice, isContinue);
                        break;
                }

            } while (isContinue);
        }

        
    }
}
