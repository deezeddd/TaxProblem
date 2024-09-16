using NSubstitute;
using SalesTaxApp.Models;
using SalesTaxApp.Services;

namespace SalesTaxApp.Tests
{
    public class TaxCalculatorTests
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxCalculatorTests()
        {
            _taxCalculator = Substitute.For<TaxCalculator>(0.10m, 0.05m);
        }

        [Fact]
        public void CalculateTax_ForNonImportedTaxableItem_ShouldReturnCorrectTax()
        {
            // Arrange
            var item = new TaxableItem("music CD", 14.99m, false);

            // Act
            var tax = _taxCalculator.CalculateTax(item, true);
            

            // Assert
            Assert.Equal(1.50m, tax);
        }

        [Fact]
        public void CalculateTax_ForImportedNonTaxableItem_ShouldReturnImportDuty()
        {
            // Arrange
            var item = new ImportedItem("imported chocolate", 10.00m);

            // Act
            var tax = _taxCalculator.CalculateTax(item, false);

            // Assert
            Assert.Equal(0.50m, tax); 
        }
    }
}
