using System;
using SalesTaxApp.Interface;
using SalesTaxApp.Models;
using SalesTaxApp.Utils;
namespace SalesTaxApp.Services
{
    public class ShoppingCart : IShoppingCart
    {   
        private readonly Cart cart;
        private readonly IReceiptService receiptService;

        public ShoppingCart(IReceiptService _receiptService)
        {
            cart = new Cart(); // Instantiate new Cart
            this.receiptService = _receiptService ?? throw new ArgumentNullException(nameof(_receiptService));
        }

        #region Public Method
        //Reads User input
        public void ReadUserInput(){

            Console.WriteLine("Enter items (or press Enter x2 to finish):");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                Item item = ParseLogic.StringParser(input);  // Parsing Input
                AddItem(item);  //Adding Item to List
            }
            PrintReceipt(cart);  //Printing Receipt of the cart
        }
        #endregion

        #region Private Method

        private void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            cart.AddItem(item);
        }
        private void PrintReceipt(Cart cart)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart), "Cart cannot be null.");
            string receipt = receiptService.GenerateReceipt(cart);
            Console.WriteLine(receipt);
        }
        #endregion
    }

}