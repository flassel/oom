using System;

namespace Task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            int number1 = rnd.Next(100);
            int number2 = rnd.Next(100);
            int number3 = rnd.Next(100);

            var notebooks = new Product[] {
                new Notebook("Apple", "MacBook Pro 13", 13.3, "i5-5257U", 8, 256, 1447m, Currency.EUR),
                new Notebook("DELL", "XPS 13 2016", 13.3, "i5-6200U", 8, 256, 1295m, Currency.EUR),
                new Notebook("HP", "Spectre x360 13-4104ng", 13.3, "i5-6200U", 8, 256, 1087.19m, Currency.EUR),
                new Coupon(number1, Currency.EUR),
                new Coupon(number2, Currency.EUR),
                new Coupon(number3, Currency.EUR)
            };

            for (var currency = Currency.EUR; (int)currency <= 4; currency++)
            {
                Console.WriteLine("A list of Notebooks: ({0})", currency);
                Console.WriteLine("######################################################");

                foreach (var a in notebooks)
                {
                    Console.WriteLine("{0,-40} {1,9:0.00} {2}", a.Description.Truncate(40), a.GetPrice(currency), currency);
                }
                Console.WriteLine();
            }
        }
    }
}
