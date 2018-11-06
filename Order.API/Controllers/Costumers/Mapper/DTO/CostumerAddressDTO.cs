using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Costumers.Mapper.DTO
{
    public class CostumerAddressDTO
    {
        public string AddressStreetName { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressPostalArea { get; set; }
        public string AddressPostalCode { get; set; }

    }
}
