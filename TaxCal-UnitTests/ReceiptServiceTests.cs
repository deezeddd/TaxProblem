using NSubstitute;
using SalesTaxApp.Models;
using SalesTaxApp.Services;

namespace SalesTaxApp.Tests
{
    public class ReceiptServiceTests
    {
        private readonly ITaxCalculator taxCalculator;
        private readonly IReceiptService receiptService;

        public ReceiptServiceTests()
        {
            taxCalculator = Substitute.For<ITaxCalculator>();
            receiptService = Substitute.For<ReceiptService>(taxCalculator);
        }

        [Fact]
        public void GenerateReceipt_ShouldReturnCorrectTotalAndTaxes_ForRegularItems()
        {
            // Arrange
            taxCalculator.CalculateTax(Arg.Any<Item>(), Arg.Any<bool>()).Returns(1.50m);

            List<Item> items = new List<Item>
            {
                new Item("book", 12.49m, false),
                new TaxableItem("music CD", 14.99m, false)
            };

            // Act
            string result = receiptService.GenerateReceipt(items);

            // Assert
            Assert.Contains("Sales Taxes: 3.00", result);
            Assert.Contains("Total: 30.48", result);
        }

        [Fact]
        public void GenerateReceipt_ShouldReturnCorrectTotalAndTaxes()
        {
            // Arrange
            taxCalculator.CalculateTax(Arg.Any<Item>(), Arg.Any<bool>()).Returns(1.50m);

            List<Item> items = new List<Item>
            {
                new TaxableItem("1 imported bottle of perfume", 47.50m, true),
                new ImportedItem("1 imported box of chocolates", 10.00m)
            };

            // Act
            string result = receiptService.GenerateReceipt(items);

            // Assert
            Assert.Contains("Sales Taxes: 3.00", result);
            Assert.Contains("Total: 60.50", result);
        }
    }
}
