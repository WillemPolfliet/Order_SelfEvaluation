using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders.Mapper.DTO
{
    public class NewItemGroupDTO
    {
        public Guid ItemID { get; set; }
        public int ItemAmount { get; set; }
    }
}
