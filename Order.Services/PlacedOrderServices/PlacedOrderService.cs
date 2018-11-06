using Order.Domain.Costumers;
using Order.Domain.Items;
using Order.Domain.PlacedOrders;
using Order.Domain.PlacedOrders.Exceptions;
using Order.Services.PlacedOrderServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.PlacedOrderServices
{
    public class PlacedOrderService : IPlacedOrderService
    {
        public void RegisterNewOrder(Dictionary<Item, int> allGivenItemsAndAmount, Costumer givenCostumer)
        {
            PlacedOrder newOrder = new PlacedOrder(allGivenItemsAndAmount, givenCostumer.Id);
            Database.PlacedOrderDatabase.OrderDB.Add(newOrder);

            foreach (var item in allGivenItemsAndAmount)
            {
                if (item.Key.Amount < item.Value)
                { item.Key.Amount = 0; }
                else
                { item.Key.Amount -= item.Value; }
            }
        }

        public List<PlacedOrder> GetAllOrders()
        {
            return Database.PlacedOrderDatabase.OrderDB;
        }
    }
}
