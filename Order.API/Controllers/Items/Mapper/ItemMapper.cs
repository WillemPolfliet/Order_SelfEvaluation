using Order.API.Controllers.Items.Mapper.DTO;
using Order.API.Controllers.Items.Mapper.Interface;
using Order.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Items.Mapper
{
    public class ItemMapper : IItemMapper
    {
        public Item DTOToItem(AddNewItemDTO givenItem)
        {
            return new Item(
                givenItem.Name,
                givenItem.Price,
                givenItem.Amount,
                givenItem.Description
                );
        }

        public ItemDTO ItemToDTO(Item givenItemDTO)
        {
            return new ItemDTO()
            {
                Id = givenItemDTO.Id,
                Name = givenItemDTO.Name,
                Price = givenItemDTO.Price,
                Amount = givenItemDTO.Amount,
                Description = givenItemDTO.Description
            };
        }

        public List<ItemDTO> ListOfCustomersToDTO(List<Item> givenListOfItems)
        {
            List<ItemDTO> DTOList = new List<ItemDTO>();

            foreach (var item in givenListOfItems)
            { DTOList.Add(ItemToDTO(item)); }

            return DTOList;
        }



    }
}
