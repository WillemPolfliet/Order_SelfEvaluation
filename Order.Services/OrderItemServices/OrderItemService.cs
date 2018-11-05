using Order.Domain.OrderItems;
using Order.Services.OrderItemServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        public void AddNewItem(List<OrderGroup> newItemGroup)
        {
            Database.OrderGroupDatabase.OrderDB.Add(newItemGroup);
        }

        public List<List<OrderGroup>> GetAllItems()
        {
            return Database.OrderGroupDatabase.OrderDB;
        }
    }
}
