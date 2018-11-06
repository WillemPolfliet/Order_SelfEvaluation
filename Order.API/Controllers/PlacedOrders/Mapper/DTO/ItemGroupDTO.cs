using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders.Mapper.DTO
{
    public class ItemGroupDTO
    {
        public Guid ItemID { get; set; }
        public int ItemAmount { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal PriceOf_OrderItemGroup { get; set; }

    }
}
