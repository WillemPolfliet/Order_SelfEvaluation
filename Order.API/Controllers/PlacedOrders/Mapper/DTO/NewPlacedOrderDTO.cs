using Order.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders.Mapper.DTO
{
    public class NewPlacedOrderDTO
    {
        public Guid givenCostumer { get; set; }
        public List<NewItemGroupDTO> Order_ItemIDAndAmount { get; set; }
    }
}
