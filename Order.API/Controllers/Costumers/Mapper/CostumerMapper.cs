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
        public CostumerOverViewDTO CostumerToCostumerOverViewDTO(Costumer givenCostumer)
        {
            var address = new CostumerAddressDTO()
            {
                AddressStreetName = givenCostumer.Address.StreetName,
                AddressStreetNumber = givenCostumer.Address.StreetNumber,
                AddressPostalArea = givenCostumer.Address.PostalArea,
                AddressPostalCode = givenCostumer.Address.PostalNumber
            };
            return new CostumerOverViewDTO()
            {
                GUID = givenCostumer.Id.ToString(),
                Firstname = givenCostumer.Firstname,
                LastName = givenCostumer.LastName,
                Email = givenCostumer.Email,
                Password = givenCostumer.Password,
                Phonenumber = givenCostumer.Phonenumber,
                Role = givenCostumer.Role.ToString(),
                Address = address
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

        public List<CostumerDTO> ListOfCustomersToListDTO(List<Costumer> givenListOfCostumer)
        {
            List<CostumerDTO> DTOList = new List<CostumerDTO>();

            foreach (var costumer in givenListOfCostumer)
            { DTOList.Add(CostumerToDTO(costumer)); }

            return DTOList;
        }

        public CostumerDTO CostumerToDTO(Costumer givenCostumer)
        {
            return new CostumerDTO()
            {
                GUID = givenCostumer.Id.ToString(),
                Name = givenCostumer.Firstname + " " + givenCostumer.LastName,
                Email = givenCostumer.Email,
                Role = givenCostumer.Role.ToString(),
            };
        }


    }
}
