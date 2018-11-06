using Order.Database;
using Order.Domain.Items;
using Order.Domain.PlacedOrders;
using Order.Services.PlacedOrderServices;
using Order.Services.PlacedOrderServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Order.Services.Tests.PlacedOrederServices
{
    public class PlacedOrderTests
    {
        IPlacedOrderService placedOrderService;

        public PlacedOrderTests()
        {
            PlacedOrderDatabase.OrderDB.Clear();
            Dictionary<Item, int> dict1 = new Dictionary<Item, int>();
            dict1.Add(new Item("test1", 12.1m, 15, "lalalala"), 3);
            dict1.Add(new Item("test2", 1.1m, 17, "lalalala"), 1);
            dict1.Add(new Item("test3", 8.1m, 0, "lalalala"), 1);
            var temp = new List<PlacedOrder>() { new PlacedOrder(dict1, Guid.NewGuid()) };
            PlacedOrderDatabase.OrderDB.AddRange(temp);

            placedOrderService = new PlacedOrderService();
        }

    }
}
