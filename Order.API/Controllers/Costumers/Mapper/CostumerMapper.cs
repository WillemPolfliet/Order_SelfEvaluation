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
                GUID = givenCostumer.Id.ToString(),
                Firstname = givenCostumer.Firstname,
                LastName = givenCostumer.LastName,
                Email = givenCostumer.Email,
                Password = givenCostumer.Password,
                Phonenumber = givenCostumer.Phonenumber,
                AddressStreetName = givenCostumer.Address.StreetName,
                AddressStreetNumber = givenCostumer.Address.StreetNumber,
                AddressPostalArea = givenCostumer.Address.PostalArea,
                AddressPostalCode = givenCostumer.Address.PostalNumber
            };
        }

        public Costumer DTOToCostumer(RegisteringNewCostumerDTO givenCostumerDTO)
        {
            return new Costumer(
                givenCostumerDTO.Firstname,
                givenCostumerDTO.LastName,
                givenCostumerDTO.Email,
                givenCostumerDTO.Phonenumber,
                givenCostumerDTO.Password,
                new Adderss(
                    givenCostumerDTO.AddressStreetName,
                    givenCostumerDTO.AddressStreetNumber,
                    givenCostumerDTO.AddressPostalArea,
                    givenCostumerDTO.AddressPostalCode
                )
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
