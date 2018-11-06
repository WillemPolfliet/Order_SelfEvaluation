using Order.API.Controllers.PlacedOrders.Mapper.DTO;
using Order.Domain.PlacedOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders.Mapper.Interface
{
    public interface IPlacedOrderMapper
    {
        List<PlacedOrderDTO> ListOfPlacedOrdersToDTO(List<PlacedOrder> givenListOfOrders);
        PlacedOrderDTO OrderToPlacedOrderDTO(PlacedOrder givenOrder);
        List<ItemGroup> DTOToItemGroup(List<NewItemGroupDTO> ListOfDTOs);
        ItemGroup ItemGRoupDTOToItemGroup(NewItemGroupDTO item);
    }
}
