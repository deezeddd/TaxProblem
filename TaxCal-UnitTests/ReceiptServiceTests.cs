using SalesTaxApp.Models;
using SalesTaxApp.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SalesTaxApp.Tests
{
    public class ReceiptServiceTests
    {
        private readonly ReceiptService _receiptService;

        public ReceiptServiceTests()
        {
            _receiptService = new ReceiptService();
        }

        [Fact]
        public void GenerateReceipt_ValidCart_ReturnsReceipt()
        {
            // Arrange
            var cart = new Cart();
            cart.AddItem(new Item("book", 1, 12.49m,  false,  false));
            cart.AddItem(new Item("music CD", 1, 14.99m,  false,  true));
            cart.AddItem(new Item("imported chocolate", 1, 10.00m,  true,  false));

            // Act
            string receipt = _receiptService.GenerateReceipt(cart);

            // Assert
            Assert.Contains("book: ", receipt);
            Assert.Contains("music CD:", receipt);
            Assert.Contains("imported chocolate: ", receipt);
            Assert.Contains("Sales Taxes: ", receipt);
            Assert.Contains("Total: 39.48", receipt);
        }

        [Fact]
        public void GenerateReceipt_EmptyCart_ThrowsArgumentException()
        {
            // Arrange
            var cart = new Cart();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _receiptService.GenerateReceipt(cart));
            Assert.Equal("Cart cannot be empty. (Parameter 'cart')", exception.Message);
        }

    }
}