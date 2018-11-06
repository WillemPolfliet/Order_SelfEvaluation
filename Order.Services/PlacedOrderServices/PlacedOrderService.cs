using Order.Database;
using Order.Domain.Costumers;
using Order.Domain.Costumers.Exceptions;
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
        public void RegisterNewOrder(List<ItemGroup> OrderGroup, Guid givenCostumerID)
        {
            Dictionary<Guid, int> dict = new Dictionary<Guid, int>();
            foreach (var item in OrderGroup)
            {
                if (dict.ContainsKey(item.ItemID))
                {
                    var dictResult = dict.Single(itemInDict => itemInDict.Key == item.ItemID);
                    dict.Remove(dictResult.Key);
                    dict.Add(dictResult.Key, dictResult.Value + item.ItemAmount);
                }
                else
                { dict.Add(item.ItemID, item.ItemAmount); }
            }


            var DictionaryWithItemObject = GetDictionaryWithItemObject(dict);
            CheckCostumerID(givenCostumerID);

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

        private void CheckCostumerID(Guid givenCostumerID)
        {
            var Excist = Database.CustomerDatabase.CostumerDB.Any(costumer => costumer.Id == givenCostumerID);
            if (!Excist)
            {
                throw new CostumerException("Costumer cannot be found");
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

        public List<PlacedOrder> GetAllOrders(Guid costumerGuid)
        {
            throw new NotImplementedException();
        }
    }
}
