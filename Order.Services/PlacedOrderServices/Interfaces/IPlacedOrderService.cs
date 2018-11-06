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


        void RegisterNewOrder(Dictionary<Guid, int> allGivenItemsAndAmount, Guid givenCostumerID);
        List<PlacedOrder> GetAllOrders();

    }
}
