using SalesTaxApp.Entities;
using SalesTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxApp.Services
{
    public class ReceiptService : IReceiptService
    {
        public string GenerateReceipt(List<Item> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("Items list cannot be empty.");

            decimal totalSalesTax = 0m;   //Initially set to 0
            decimal totalPrice = 0m;

            List<string> receipt = new List<string>();

            foreach (var item in items)
            {
                var tax = item.CalculateSalesTax();
                totalSalesTax += tax ;
                totalPrice += item.Price  + tax;

                receipt.Add(FormatItemLine(item, tax));
            }

            receipt.Add($"Sales Taxes: {totalSalesTax:F2}");
            receipt.Add($"Total: {totalPrice:F2}");

            return string.Join(Environment.NewLine, receipt);
        }

        private static string FormatItemLine(Item item, decimal salesTax)
        {
            decimal finalPrice = item.Price + salesTax;
            return $"{item.Name}: {finalPrice:F2}";
        }

        // // #region Private Method
        // //Prints the receipt
        // public static void PrintReceipt(Cart cart)
        // {
        //     if (cart == null)
        //         throw new ArgumentNullException(nameof(cart), "Cart cannot be null.");

        //     var receiptService = new ReceiptService();
        //     string receipt = receiptService.GenerateReceipt(cart.Items);
        //     Console.WriteLine(receipt);
        // }
        // // #endregion

    }
}
