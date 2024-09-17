using SalesTaxApp.Models;

namespace dotnetcore.Utils
{
    public class ParseLogic
    {
        public static Item StringParser(string input){
            input = input.ToLower();
            string[] inputArray = input.Split("at");
            if (inputArray.Length != 2) return null;
            return new Item(inputArray[0], decimal.Parse(inputArray[1]), IsImported(input), IsTaxable(input));
        }
        public static bool IsImported(string input){
            if (input.Contains("imported"))
            {
                return true;
            }
            return false;
        }
        public static bool IsTaxable(string input){
            if (input.Contains("book") || input.Contains("chocolate") || input.Contains("food") || input.Contains("medical") || input.Contains("pills")){
                return false;
            }
            return true;
        }
    }
}