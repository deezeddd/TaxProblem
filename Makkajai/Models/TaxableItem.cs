using SalesTaxApp.Services;

namespace SalesTaxApp.Models
{
    public class TaxableItem : Item
    {
        public TaxableItem(string name, decimal price, bool isImported)
            : base(name, price, isImported) { }

        public override decimal GetTaxAmount(ITaxCalculator calculator) => calculator.CalculateTax(this, isTaxable: true);

        public override string ToString()
        {
            return $"{Name}: {Price + GetTaxAmount(new TaxCalculator()):F2}";
        }
    }
}
