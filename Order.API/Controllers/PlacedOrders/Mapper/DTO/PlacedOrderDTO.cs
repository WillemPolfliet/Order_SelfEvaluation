using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders.Mapper.DTO
{
    public class PlacedOrderDTO
    {
        public Guid OrderId { get; set; }
        public Guid CostumerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DateShipped { get; set; }
        public List<ItemGroupDTO> OrderItems { get; set; }
        public decimal TotalPriceOfOrder { get; set; }
    }
}
