using SalesTaxApp.Models;
using SalesTaxApp.Utils;

namespace SalesTaxApp.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly decimal _basicTaxRate;
        private readonly decimal _importDutyRate;

        public TaxCalculator(decimal basicTaxRate = 0.10m, decimal importDutyRate = 0.05m)
        {
            _basicTaxRate = basicTaxRate;
            _importDutyRate = importDutyRate;
        }

        public decimal CalculateTax(Item item, bool isTaxable = false)
        {
            decimal tax = 0m;

            if (isTaxable)
                tax += item.Price * _basicTaxRate;

            if (item.IsImported)
                tax += item.Price * _importDutyRate;

            return TaxUtils.RoundUpToNearest05(tax);
        }
    }
}
