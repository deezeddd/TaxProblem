using NSubstitute;
using SalesTaxApp.Services;
using SalesTaxApp.Interface;
using SalesTaxApp.Models;
using Xunit;
using System.IO;

public class ShoppingCartTests
{
    private readonly ShoppingCart _shoppingCart;
    private readonly IReceiptService _receiptService;

    public ShoppingCartTests()
    {
        _receiptService = Substitute.For<IReceiptService>();
        _shoppingCart = new ShoppingCart(_receiptService);
    }


    [Fact]
    public void ReadUserInput_ShouldGenerateReceipt_WhenInputIsValid()
    {
        // Arrange
        var input = "1 book at 12.49\n\n";
        var expectedReceipt = "1 book: 12.49\nSales Taxes: 0.00\nTotal: 12.49";
        _receiptService.GenerateReceipt(Arg.Any<Cart>()).Returns(expectedReceipt);

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);

                // Act
                _shoppingCart.ReadUserInput();

                // Assert
                Assert.Contains(expectedReceipt, sw.ToString());
            }
        }
    }
}
