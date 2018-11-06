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
        public Item DTOToItem(NewItemDTO givenItemDTO)
        {
            return new Item(
                givenItemDTO.Name,
                givenItemDTO.Price,
                givenItemDTO.Amount,
                givenItemDTO.Description
                );
        }





        public ItemDTO ItemToDTO(Item givenItem)
        {
            return new ItemDTO()
            {
                Id = givenItem.Id,
                Name = givenItem.Name,
                Price = givenItem.Price,
                Amount = givenItem.Amount,
                Description = givenItem.Description
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
