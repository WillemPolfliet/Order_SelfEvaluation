using Order.API.Controllers.Costumers.Mapper.DTO;
using Order.API.Controllers.Costumers.Mapper.Interface;
using Order.Domain.Costumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Costumers.Mapper
{
    public class CostumerMapper : ICostumerMapper
    {
        public CostumerDTO CostumerToDTO(Costumer givenCostumer)
        {
            return new CostumerDTO()
            {
                Firstname = givenCostumer.Firstname,
                LastName = givenCostumer.LastName,
                Email = givenCostumer.Email,
                Address = givenCostumer.Address,
                Phonenumber = givenCostumer.Phonenumber
            };
        }

        public Costumer DTOToCostumer(CostumerDTO givenCostumerDTO)
        {
            return new Costumer(
                givenCostumerDTO.Firstname,
                givenCostumerDTO.LastName,
                givenCostumerDTO.Email,
                givenCostumerDTO.Address,
                givenCostumerDTO.Phonenumber
            );
        }

        public List<CostumerDTO> ListOfCustomersToDTO(List<Costumer> givenListOfCostumer)
        {
            List<CostumerDTO> DTOList = new List<CostumerDTO>();

            foreach (var costumer in givenListOfCostumer)
            { DTOList.Add(CostumerToDTO(costumer)); }

            return DTOList;
        }
    }
}
