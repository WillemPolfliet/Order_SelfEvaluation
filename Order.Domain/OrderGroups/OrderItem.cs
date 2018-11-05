using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.OrderGroups
{
    public class OrderItem
    {
        public Guid ItemID { get; private set; }
        public int ItemAmount { get; private set; }
        public float PriceOfOrder { get; private set; }
        public DateTime ShippingDate { get; private set; }

        public OrderItem()
        {
            ItemID = givenItem.Id;
            ItemAmount = itemAmount;
            PriceOfOrder = givenItem.Price * itemAmount;

            if (givenItem.Amount == 0)
            { ShippingDate = OrderDate.AddDays(7); }
            else
            { ShippingDate = OrderDate.AddDays(1); }
        }
    }
}
