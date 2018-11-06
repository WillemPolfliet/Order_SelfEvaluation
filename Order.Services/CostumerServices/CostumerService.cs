using Order.Database;
using Order.Database.Exceptions;
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
            var costumer = await Task.Run(() => CostumerDatabase.CostumerDB.SingleOrDefault(CostumerToLogin => CostumerToLogin.Email == username && CostumerToLogin.Password == password));

            if (costumer == null)
            { return null; }

            return costumer;
        }

        public List<Costumer> GetAllCostumers()
        {
            if (CostumerDatabase.CostumerDB.Count == 0)
            {
                throw new DatabaseException("Costumers Database is empty");
            }
            return CostumerDatabase.CostumerDB;
        }

        public Costumer GetSpecificCostumer(Guid costumerGuidID)
        {
            try
            {
                var costumer = CostumerDatabase.CostumerDB.Single(person => person.Id == costumerGuidID);
                return costumer;
            }
            catch
            { throw new CostumerException("costumer not found"); }
        }

        public void Register(Costumer newCostumer)
        {
            var doesCostumerMailExist = CostumerDatabase.CostumerDB.Any(DBCostumer => DBCostumer.Email == newCostumer.Email);
            if (doesCostumerMailExist)
            { throw new CostumerException("The costumer Email is already used. no duplicated is possible"); }

            CostumerDatabase.CostumerDB.Add(newCostumer);
        }
    }
}
