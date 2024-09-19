using SalesTaxApp.Interface;
using SalesTaxApp.Services;
using System;

namespace SalesTaxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IReceiptService receiptService = new ReceiptService();
                IShoppingCart shoppingCart = new ShoppingCart(receiptService);
                shoppingCart.ReadUserInput();                

            }
            catch (Exception e)
            {
                Console.WriteLine("An Exception Occured: " + e.Message);
            }

        }
    }
}
