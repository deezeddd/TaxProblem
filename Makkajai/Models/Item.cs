using System;
using SalesTaxApp.Utils;

namespace SalesTaxApp.Models
{
    public class Item
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool IsImported { get; }
        public bool IsTaxable { get; }


        public Item(string Name, decimal Price, bool IsImported = false, bool IsTaxable = false)
        {
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.Price = Price >= 0 ? Price : throw new ArgumentException("Price cannot be negative");
            this.IsImported = IsImported;
            this.IsTaxable = IsTaxable;

        }

        // public decimal GetTaxAmount(ITaxCalculator calculator)
        // {
        //     if (IsTaxable){
        //      return calculator.CalculateTax(this, IsTaxable);
        //     }
        //     else{
        //         return calculator.CalculateTax(this, IsImported);
        //     }
        // }

        public decimal CalculateSalesTax()
        {
            decimal tax = 0;

            // Basic sales tax
            if (!IsTaxable)
            {
                tax += Price * 0.10m;
            }

            // Import duty
            if (IsImported)
            {
                tax += TaxUtils.ImportDuty(Price);
            }

            // Round up to the nearest 0.05
            return TaxUtils.RoundUpToNearest05(tax);
        }

    }
}
