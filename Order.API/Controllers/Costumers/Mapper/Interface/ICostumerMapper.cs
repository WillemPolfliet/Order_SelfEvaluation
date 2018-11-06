using Order.API.Controllers.Costumers.Mapper.DTO;
using Order.Domain.Costumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Costumers.Mapper.Interface
{
    public interface ICostumerMapper
    {
        CostumerOverViewDTO CostumerToCostumerOverViewDTO(Costumer givenCostumer);
        Costumer DTOToCostumer(RegisteringNewCostumerDTO givenCostumerDTO);
        List<CostumerDTO> ListOfCustomersToListDTO(List<Costumer> givenListOfCostumer);
        CostumerDTO CostumerToDTO(Costumer givenCostumer);
    }
}
