using SalesTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxApp.Services
{
    public class ReceiptService : IReceiptService
    {
        public string GenerateReceipt(Cart cart)
        {
            if (cart == null || !cart.Items.Any())
                throw new ArgumentException("Cart cannot be empty.", nameof(cart));

            decimal totalSalesTax = 0m; // Initially set to 0
            decimal totalPrice = 0m;

            List<string> receipt = new();

            foreach (Item item in cart.Items)
            {
                var salesTax = item.CalculateSalesTax();
                totalSalesTax += salesTax;
                totalPrice += item.Price + salesTax;

                receipt.Add(FormatItemLine(item, salesTax));
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
    }
}