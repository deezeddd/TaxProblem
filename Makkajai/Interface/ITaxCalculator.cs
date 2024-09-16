using SalesTaxApp.Models;

namespace SalesTaxApp.Services
{
    public interface ITaxCalculator
    {
        public decimal CalculateTax(Item item, bool isTaxable = false);
    }
}