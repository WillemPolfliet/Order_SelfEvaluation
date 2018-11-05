using Order.Domain.OrderItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.OrderItemServices.Interfaces
{
    public interface IOrderItemService
    {
        List<List<OrderGroup>> GetAllItems();
        void AddNewItem(List<OrderGroup> newItem);
    }
}
