using System.Collections.Generic;
using SalesTaxApp.Entities;
using SalesTaxApp.Models;

namespace SalesTaxApp.Services
{
    public interface IReceiptService
    {
        public string GenerateReceipt(List<Item> items);
    }
}