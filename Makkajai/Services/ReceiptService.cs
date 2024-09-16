using SalesTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxApp.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly ITaxCalculator _taxCalculator;

        public ReceiptService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public string GenerateReceipt(List<Item> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("Items list cannot be empty.");

            decimal totalSalesTax = 0m;
            decimal totalPrice = 0m;

            var receipt = new List<string>();

            foreach (var item in items)
            {
                var tax = item.GetTaxAmount(_taxCalculator);
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
