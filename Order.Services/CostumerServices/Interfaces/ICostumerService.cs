using Order.Domain.Costumers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.CostumerServices.Interfaces
{
    public interface ICostumerService
    {
        void Register(Costumer newCostumer);//
        List<Costumer> GetAllCostumers();//
        Task<Costumer> Authenticate(string username, string password);
        Costumer GetSpecificCostumer(Guid costumerGuidID);
    }
}
