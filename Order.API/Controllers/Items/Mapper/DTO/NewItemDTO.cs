using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Items.Mapper.DTO
{
    public class NewItemDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
