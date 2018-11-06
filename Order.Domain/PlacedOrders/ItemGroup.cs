using Order.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.PlacedOrders
{
    public class ItemGroup
    {
        public Guid ItemID { get; private set; }
        public int ItemAmount { get; private set; }
        public decimal PricePerItem { get; private set; }
        public DateTime ShippingDate { get; private set; }

        public decimal PriceOf_OrderItemGroup { get { return PricePerItem * ItemAmount; } }


        public ItemGroup(Item givenItem, int orderingAmount, DateTime orderDate)
        {
            ItemID = givenItem.Id;
            ItemAmount = orderingAmount;
            PricePerItem = givenItem.Price;

            if (givenItem.Amount == 0)
            { ShippingDate = orderDate.AddDays(7); }
            else if (givenItem.Amount == orderingAmount)
            { ShippingDate = orderDate.AddDays(7); }
            else
            { ShippingDate = orderDate.AddDays(1); }
        }
    }
}
