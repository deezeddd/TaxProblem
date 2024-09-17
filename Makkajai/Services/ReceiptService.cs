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

            var receipt = new List<string>();

            foreach (var item in items)
            {
                var tax = item.CalculateSalesTax();
                totalSalesTax += tax;
                totalPrice += item.Price + tax;

                receipt.Add($"{item.Name}: {item.Price + tax:F2}");
            }

            receipt.Add($"Sales Taxes: {totalSalesTax:F2}");
            receipt.Add($"Total: {totalPrice:F2}");

            return string.Join(Environment.NewLine, receipt);
        }
    }
}
