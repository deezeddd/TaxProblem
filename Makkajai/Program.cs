using SalesTaxApp.Models;
using SalesTaxApp.Services;
using System;
using System.Collections.Generic;

namespace SalesTaxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaxCalculator taxCalculator = new TaxCalculator();
            IReceiptService receiptService = new ReceiptService(taxCalculator);

            List<Item> basket1 = new List<Item>
            {
                new ("1 book", 12.49m, false),
                new TaxableItem("1 music CD", 14.99m, false),
                new ("1 chocolate bar", 0.85m, false)
            };

            List<Item> basket2 = new List<Item>
            {
                new ImportedItem("1 imported box of chocolates", 10.00m),
                new TaxableItem("1 imported bottle of perfume", 47.50m, true)
            };

            List<Item> basket3 = new List<Item>
            {
                new TaxableItem("1 imported bottle of perfume", 27.99m, true),
                new TaxableItem("1 bottle of perfume", 18.99m, false),
                new("1 packet of headache pills", 9.75m, false),
                new ImportedItem("1 box of imported chocolates", 11.25m)
            };

            Console.WriteLine("Output 1:");
            Console.WriteLine(receiptService.GenerateReceipt(basket1));
            Console.WriteLine("\nOutput 2:");
            Console.WriteLine(receiptService.GenerateReceipt(basket2));
            Console.WriteLine("\nOutput 3:");
            Console.WriteLine(receiptService.GenerateReceipt(basket3));
        }
    }
}
