using Order.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.ItemServices.Interfaces
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        void AddNewItem(Item newItem);
        void UpdateItem(Guid itemGuidID, Item item);
    }
}
