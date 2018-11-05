using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Costumers.Mapper.DTO
{
    public class CostumerDTO
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
    }
}
