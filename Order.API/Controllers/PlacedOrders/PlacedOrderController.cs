using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Controllers.PlacedOrders.Mapper.DTO;
using Order.API.Controllers.PlacedOrders.Mapper.Interface;
using Order.Services.PlacedOrderServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.PlacedOrders
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class PlacedOrderController : ControllerBase
    {
        private readonly IPlacedOrderService _placedOrderService;
        private readonly IPlacedOrderMapper _placedOrderMapper;

        public PlacedOrderController(IPlacedOrderService Service, IPlacedOrderMapper Mapper)
        {
            _placedOrderService = Service;
            _placedOrderMapper = Mapper;
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpGet]
        public ActionResult<List<PlacedOrderDTO>> GetAllOrders()
        {
            return Ok(_placedOrderMapper.ListOfPlacedOrdersToDTO(_placedOrderService.GetAllOrders()));
        }

        [Authorize(Policy = "MustBeCostumer")]
        [HttpPost]
        public ActionResult RegisterANewOrder([FromBody] NewPlacedOrderDTO newOrder)
        {
            Dictionary<Guid, int> dict = new Dictionary<Guid, int>();
            foreach (var item in newOrder.Order_ItemIDAndAmount)
            { dict.Add(item.ItemID, item.ItemAmount); }
            try
            {
                _placedOrderService.RegisterNewOrder(dict, newOrder.givenCostumer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }



    }
}