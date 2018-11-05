using Order.Domain.Costumers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services.CostumerServices.Interfaces
{
    public interface ICostumerService
    {
        void Register(Costumer newCostumer);
        List<Costumer> GetAllCostumers();
    }
}
