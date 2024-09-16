using System;
using SalesTaxApp.Services;

namespace SalesTaxApp.Models
{
    public class Item
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool IsImported { get; }

        public Item(string name, decimal price, bool isImported)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative");
            IsImported = isImported;
        }

        public virtual decimal GetTaxAmount(ITaxCalculator calculator)
        {
            return calculator.CalculateTax(this);
        }

        public override string ToString()
        {
            return $"{Name}: {Price:F2}";
        }
    }
}
