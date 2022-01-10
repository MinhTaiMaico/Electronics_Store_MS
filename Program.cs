using System;
using System.Collections.Generic;

namespace Electronics_Store_MS
{
    using Electronics_Store_MS.InvoiceManagement;
    using Electronics_Store_MS.Product.Fan;

    class Program
    {
        private static List<Invoice> _invoices = new List<Invoice>();

        public static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Menu.Menu.Build(ref _invoices);
        }
    }
}
