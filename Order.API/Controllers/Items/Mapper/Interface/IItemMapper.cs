using Order.API.Controllers.Items.Mapper.DTO;
using Order.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Items.Mapper.Interface
{
    public interface IItemMapper
    {
        List<ItemDTO> ListOfCustomersToDTO(List<Item> givenListOfItems);
        Item DTOToItem(NewItemDTO givenItemDTO);
        ItemDTO ItemToDTO(Item givenItem);
    }
}
