using Order.Domain.Items;
using Order.Domain.PlacedOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.PlacedOrders
{
    public class PlacedOrder
    {
        public Guid OrderId { get; }
        public Guid CostumerID { get; private set; }
        public List<ItemGroup> OrderItems { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime? DateShipped { get; private set; }

        public decimal TotalPriceOfOrder
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in OrderItems)
                { totalPrice += item.PriceOf_OrderItemGroup; }
                return totalPrice;
            }
        }


        public PlacedOrder(Dictionary<Item, int> allGivenItemsAndAmount, Guid givenCostumerID)
        {
            OrderId = Guid.NewGuid();
            CostumerID = givenCostumerID;
            OrderDate = DateTime.Now.Date;
            DateShipped = null;

            OrderItems = new List<ItemGroup>();
            foreach (var keyValuePair in allGivenItemsAndAmount)
            { OrderItems.Add(new ItemGroup(keyValuePair.Key, keyValuePair.Value, OrderDate)); }
        }

        public void SetDateShipped()
        {
            DateShipped = DateTime.Now.Date;
        }

    }
}
