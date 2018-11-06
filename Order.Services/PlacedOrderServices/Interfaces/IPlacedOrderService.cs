using Order.Domain.Costumers;
using Order.Domain.Items;
using Order.Domain.PlacedOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.PlacedOrderServices.Interfaces
{
    public interface IPlacedOrderService
    {


        void RegisterNewOrder(List<ItemGroup> allGivenItemsAndAmount, Guid givenCostumerID);
        List<PlacedOrder> GetAllOrders();
        List<PlacedOrder> GetAllOrders(Guid costumerGuid);
    }
}
