using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Costumers.Mapper.DTO
{
    public class CostumerDTO
    {
        public string GUID { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public string Role { get; set; }

        public string AddressStreetName { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressPostalArea { get; set; }
        public string AddressPostalCode { get; set; }
    }
}
