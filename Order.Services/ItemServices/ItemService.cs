using Order.Database;
using Order.Database.Exceptions;
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
            if (ItemDatabase.ItemDB.Count == 0)
            {
                throw new DatabaseException("Items Database is empty");
            }
            return ItemDatabase.ItemDB;
        }

        public void UpdateItem(Guid itemGuidID, Item givenItem)
        {
            var itemToUpdate = ItemDatabase.ItemDB.SingleOrDefault(itemFromDB => itemFromDB.Id == itemGuidID);
            if (itemToUpdate == null)
            { throw new ItemException("Item to update cannot be found."); }

            try
            {
                ItemDatabase.ItemDB.Remove(itemToUpdate);
                itemToUpdate.UpdateItemWithGivenItem(givenItem);
                ItemDatabase.ItemDB.Add(itemToUpdate);
            }
            catch
            { throw new ItemException("Cannot update item."); }
        }
    }
}
