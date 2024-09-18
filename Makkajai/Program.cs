using SalesTaxApp.Services;
using System;

namespace SalesTaxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IReceiptService receiptService = new ReceiptService();
                IShoppingCart shoppingCart = new ShoppingCart(receiptService);
                shoppingCart.ReadUserInput();                

            }
            catch (Exception e)
            {
                Console.WriteLine("An Exception Occured: " + e.Message);
            }

            // List<Item> basket1 = new()
            // {
            //     new ("1 book", 12.49m),
            //     new ("1 music CD", 14.99m, false, true),
            //     new ("1 chocolate bar", 0.85m, false)
            // };

            // List<Item> basket2 = new()
            // {
            //     new ("1 imported box of chocolates", 10.00m, true),
            //     new ("1 imported bottle of perfume", 47.50m,true, IsTaxable: true)
            // };

            // List<Item> basket3 = new()
            // {
            //     new ("1 imported bottle of perfume", 27.99m, true, true),
            //     new ("1 bottle of perfume", 18.99m, IsTaxable: true),
            //     new("1 packet of headache pills", 9.75m),
            //     new ("1 box of imported chocolates", 11.25m, true)
            // };

            // Console.WriteLine("Output 1:");
            // Console.WriteLine(receiptService.GenerateReceipt(basket1));
            // Console.WriteLine("\nOutput 2:");
            // Console.WriteLine(receiptService.GenerateReceipt(basket2));

        }
    }
}
