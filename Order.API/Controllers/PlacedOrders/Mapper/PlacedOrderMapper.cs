using Order.API.Controllers.PlacedOrders.Mapper.DTO;
using Order.API.Controllers.PlacedOrders.Mapper.Interface;
using Order.Domain.PlacedOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders.Mapper
{
    public class PlacedOrderMapper : IPlacedOrderMapper
    {
        public List<PlacedOrderDTO> ListOfPlacedOrdersToDTO(List<PlacedOrder> givenListOfOrders)
        {
            List<PlacedOrderDTO> DTOList = new List<PlacedOrderDTO>();

            foreach (var item in givenListOfOrders)
            { DTOList.Add(OrderToPlacedOrderDTO(item)); }

            return DTOList;
        }

        public PlacedOrderDTO OrderToPlacedOrderDTO(PlacedOrder givenOrder)
        {
            List<ItemGroupDTO> DTOList = new List<ItemGroupDTO>();
            foreach (var item in givenOrder.OrderItems)
            {
                DTOList.Add(new ItemGroupDTO()
                {
                    ItemID = item.ItemID,
                    ItemAmount = item.ItemAmount,
                    ShippingDate = item.ShippingDate,
                    PriceOf_OrderItemGroup = item.PriceOf_OrderItemGroup,
                    PricePerItem = item.PricePerItem
                });
            }
            return new PlacedOrderDTO()
            {
                OrderId = givenOrder.OrderId,
                CostumerID = givenOrder.CostumerID,
                OrderDate = givenOrder.OrderDate,
                DateShipped = givenOrder.DateShipped,
                OrderItems = DTOList,
                TotalPriceOfOrder = givenOrder.TotalPriceOfOrder
            };
        }

        public List<ItemGroup> DTOToItemGroup(List<NewItemGroupDTO> ListOfDTOs)
        {
            List<ItemGroup> DTOList = new List<ItemGroup>();

            foreach (var item in ListOfDTOs)
            { DTOList.Add(ItemGRoupDTOToItemGroup(item)); }

            return DTOList;
        }

        public ItemGroup ItemGRoupDTOToItemGroup(NewItemGroupDTO item)
        {
            return new ItemGroup(item.ItemID, item.ItemAmount);
        }
    }
}
