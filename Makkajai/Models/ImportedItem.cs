using SalesTaxApp.Services;

namespace SalesTaxApp.Models
{
    public class ImportedItem : Item
    {
        public ImportedItem(string name, decimal price, bool isTaxable = false)
            : base(name, price, true) // Automatically set IsImported to true
        {
        }

        public override decimal GetTaxAmount(ITaxCalculator calculator)
        {
            // This will always include the import duty
            return calculator.CalculateTax(this, true);
        }

        public override string ToString()
        {
            return $"{Name}: {Price + GetTaxAmount(new TaxCalculator()):F2}";
        }
    }
}
