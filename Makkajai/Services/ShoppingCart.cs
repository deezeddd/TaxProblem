using System;
using System.Collections.Generic;
using SalesTaxApp.Entities;
using SalesTaxApp.Models;
using SalesTaxApp.Utils;
namespace SalesTaxApp.Services
{
    public class ShoppingCart
    {   
        public Cart Cart;
        
        public ShoppingCart(){
            Cart = new Cart(); // Instantiate new Cart
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
                Cart.AddItem(item);  //Adding Item to List
            }
            PrintReceipt();  //Printing Receipt of the cart
        }
        #endregion
        
        #region Private Method

        //Prints the receipt
        private void PrintReceipt()
        {
            var receiptService = new ReceiptService();
            string receipt = receiptService.GenerateReceipt(Cart.Items);
            Console.WriteLine(receipt);
        }
        #endregion

    }
}