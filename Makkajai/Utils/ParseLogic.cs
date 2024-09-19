using System;
using SalesTaxApp.Models;

namespace SalesTaxApp.Utils
{
    public class ParseLogic
    {
        #region  Public Method
        public static Item StringParser(string input){
            input = input.ToLower();
            int atIndex = input.LastIndexOf("at");
            if (atIndex == -1) return null;
            string name = input[..atIndex];
            string price = input[(atIndex + 2)..];
            int quantity = input[0] - '0';
            return new Item(name, quantity , decimal.Parse(price), IsImported(input), IsTaxable(input));
        }
        #endregion

        #region Private Method
        private static bool IsImported(string input){
            if (input.Contains("imported"))
            {
                return true;
            }
            return false;
        }
        private static bool IsTaxable(string input){
            if (input.Contains("book") || input.Contains("chocolate") || input.Contains("food") || input.Contains("medical") || input.Contains("pills")){
                return false;
            }
            return true;
        }
        #endregion
    }
}