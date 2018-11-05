using Order.Domain.Costumers;
using Order.Domain.Items;
using Order.Domain.OrderGroups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.OrderItems
{
    public class OrderGroup
    {
        public Guid OrderId { get; }
        public Guid CostumerID { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime? DateShipped { get; private set; }


        public OrderGroup(Item givenItem, Costumer givenCostumer, int itemAmount)
        {
            OrderId = Guid.NewGuid();
            CostumerID = givenCostumer.Id;
            OrderItems = new OrderItem()
            OrderDate = DateTime.Now.Date;
            DateShipped = null;
        }

        public void SetDateShipped()
        {
            DateShipped = DateTime.Now.Date;
        }

    }
}
