
using SalesTaxApp.Models;

namespace SalesTaxApp.Services
{
    public interface IReceiptService
    {
        public string GenerateReceipt(Cart items);
    }
}