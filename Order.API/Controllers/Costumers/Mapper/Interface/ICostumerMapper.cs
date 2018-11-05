using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order.API.Controllers.Costumers.Mapper.DTO;
using Order.Domain.Costumers;

namespace Order.API.Controllers.Costumers.Mapper.Interface
{
    public interface ICostumerMapper
    {
        CostumerDTO CostumerToDTO(Costumer givenCostumer);
        Costumer DTOToCostumer(CostumerDTO givenCostumerDTO);
        List<CostumerDTO> ListOfCustomersToDTO(List<Costumer> givenCostumer);
    }
}
