using Order.Database;
using Order.Domain.Costumers;
using Order.Domain.Costumers.Exceptions;
using Order.Services.CostumerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.CostumerServices
{
    public class CostumerService : ICostumerService
    {
        public async Task<Costumer> Authenticate(string username, string password)
        {
            var costumer = await Task.Run(() => CustomerDatabase.CostumerDB.SingleOrDefault(CostumerToLogin => CostumerToLogin.Email == username && CostumerToLogin.Password == password));

            if (costumer == null)
            { return null; }

            return costumer;
        }

        public List<Costumer> GetAllCostumers()
        {
            return CustomerDatabase.CostumerDB;
        }

        public Costumer GetSpecificCostumer(Guid costumerGuidID)
        {
            try
            {
                var costumer = CustomerDatabase.CostumerDB.Single(person => person.Id == costumerGuidID);
                return costumer;
            }
            catch
            { throw new CostumerException("costumer not found"); }
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
