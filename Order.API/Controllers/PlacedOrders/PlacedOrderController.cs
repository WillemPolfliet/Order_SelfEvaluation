using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Controllers.PlacedOrders.Mapper.DTO;
using Order.API.Controllers.PlacedOrders.Mapper.Interface;
using Order.Domain.PlacedOrders.Exceptions;
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
        [HttpGet]
        [Route("{CostumerGuid}")]
        public ActionResult<List<PlacedOrderDTO>> GetReportOfAllOrders([FromRoute] Guid CostumerGuid)
        {
            try
            {
                var result = _placedOrderMapper.ListOfPlacedOrdersToDTO(_placedOrderService.GetAllOrders(CostumerGuid));

                return Ok(result);
            }
            catch (PlacedOrderException PlacedEx)
            { return BadRequest(PlacedEx.Message); }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

        }

        [Authorize(Policy = "MustBeCostumer")]
        [HttpPost]
        public ActionResult RegisterANewOrder([FromBody] NewPlacedOrderDTO newOrder)
        {
            try
            {
                _placedOrderService.RegisterNewOrder(_placedOrderMapper.DTOToItemGroup(newOrder.Order_ItemIDAndAmount), newOrder.givenCostumer);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok();
        }


    }
}