using System;

namespace SalesTaxApp.Utils
{
    public static class TaxUtils
    {
        public static decimal RoundUpToNearest05(decimal amount)
        {
            return Math.Ceiling(amount * 20) / 20;
        }

        public static decimal ImportDuty(decimal price)
        {
            return price * 0.05m;
        }
    }
}
