using System.Collections.Generic;
using SalesTaxApp.Models;

namespace SalesTaxApp.Entities
{
    public class Cart
    {
        public List<Item> Items { get; set; }

        public Cart()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

    }
}