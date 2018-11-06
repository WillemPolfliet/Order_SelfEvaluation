using Order.Database;
using Order.Domain.Items;
using Order.Domain.Items.Exceptions;
using Order.Services.ItemServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpdateItem(Guid itemGuidID, Item givenItem)
        {
            try
            {
                var itemToUpdate = ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Id == itemGuidID);
                ItemDatabase.ItemDB.Remove(itemToUpdate);
                itemToUpdate.UpdateItemWithGivenItem(givenItem);
                ItemDatabase.ItemDB.Add(itemToUpdate);

            }
            catch
            {
                throw new ItemException("Item to update cannot be found.");
            }
        }
    }
}
