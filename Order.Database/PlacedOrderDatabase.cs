using Order.Domain.PlacedOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Database
{
    public class PlacedOrderDatabase
    {
        public static List<PlacedOrder> OrderDB = new List<PlacedOrder>()
        {
            new PlacedOrder(generateDatabase(),Guid.NewGuid())
        };


        private static Dictionary<Domain.Items.Item, int> generateDatabase()
        {
            Dictionary<Domain.Items.Item, int> dict = new Dictionary<Domain.Items.Item, int>();
            dict.Add(new Domain.Items.Item("test1", 12.1m, 15, "lalalala"), 3);
            dict.Add(new Domain.Items.Item("test2", 1.1m, 17, "lalalala"), 1);
            dict.Add(new Domain.Items.Item("test3", 8.1m, 0, "lalalala"), 1);
            return dict;
        }
    }
}
