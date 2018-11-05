using Order.Database;
using Order.Domain.Costumers;
using Order.Domain.Costumers.Exceptions;
using Order.Services.CostumerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Services.CostumerServices
{
    public class CostumerService : ICostumerService
    {
        public List<Costumer> GetAllCostumers()
        {
            return CustomerDatabase.CostumerDB;
        }

        public void Register(Costumer newCostumer)
        {
            var doesCostumerMailExist = CustomerDatabase.CostumerDB.Any(DBCostumer => DBCostumer.Email == newCostumer.Email);
            if (doesCostumerMailExist)
            { throw new CostumerException("The costumer Email is already used. no duplicated is possible"); }

            CustomerDatabase.CostumerDB.Add(newCostumer);
        }
    }
}
