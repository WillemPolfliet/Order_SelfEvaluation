using Order.Database;
using Order.Domain.Items;
using Order.Services.ItemServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.ItemServices
{
    public class ItemService : IItemService
    {
        public void AddNewItem(Item newItem)
        {
            ItemDatabase.ItemDB.Add(newItem);
        }

        public List<Item> GetAllItems()
        {
            return ItemDatabase.ItemDB;
        }
    }
}
