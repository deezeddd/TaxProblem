using System;
using System.Collections.Generic;
using dotnetcore.Utils;
using SalesTaxApp.Models;
namespace SalesTaxApp.Services
{
    public class ShoppingCart
    {
        private List<Item> Items { get; set; }

        public ShoppingCart(){
            Items = new List<Item>();
        }

        public void AddItem(Item item){
            Items.Add(item);
        }
        public void PrintReceipt(){
            var receiptService = new ReceiptService();
            string receipt = receiptService.GenerateReceipt(Items);
            Console.WriteLine(receipt);
        }

        public void ReadUserInput(){

            Console.WriteLine("Enter items (or press Enter to finish):");
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
            PrintReceipt();  //Printing Receipt of the cart
        }

    }
}