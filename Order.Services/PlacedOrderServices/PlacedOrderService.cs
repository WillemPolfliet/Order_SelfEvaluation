using Order.Database;
using Order.Domain.Costumers;
using Order.Domain.Items;
using Order.Domain.PlacedOrders;
using Order.Domain.PlacedOrders.Exceptions;
using Order.Services.PlacedOrderServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Services.PlacedOrderServices
{
    public class PlacedOrderService : IPlacedOrderService
    {
        public void RegisterNewOrder(Dictionary<Guid, int> allGivenItemsAndAmount, Guid givenCostumerID)
        {
            var DictionaryWithItemObject = GetDictionaryWithItemObject(allGivenItemsAndAmount);

            PlacedOrder newOrder = new PlacedOrder(DictionaryWithItemObject, givenCostumerID);
            PlacedOrderDatabase.OrderDB.Add(newOrder);

            foreach (var item in DictionaryWithItemObject)
            {
                if (item.Key.Amount < item.Value)
                { item.Key.Amount = 0; }
                else
                { item.Key.Amount -= item.Value; }
            }
        }

        private static Dictionary<Item, int> GetDictionaryWithItemObject(Dictionary<Guid, int> allGivenItemsAndAmount)
        {
            var DictionaryWithItemObject = new Dictionary<Item, int>();
            foreach (var item in allGivenItemsAndAmount)
            {
                var selectedItem = ItemDatabase.ItemDB.SingleOrDefault(orderedItem => orderedItem.Id == item.Key);

                if (selectedItem == null)
                { throw new ItemGroupException($"Book with ID {item.Key} does not exist"); }

                DictionaryWithItemObject.Add(selectedItem, item.Value);
            }
            return DictionaryWithItemObject;
        }

        public List<PlacedOrder> GetAllOrders()
        {
            return PlacedOrderDatabase.OrderDB;
        }
    }
}
