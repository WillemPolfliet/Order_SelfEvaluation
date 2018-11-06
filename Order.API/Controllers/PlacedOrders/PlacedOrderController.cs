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
            return Ok(_placedOrderMapper.ListOfCustomersToDTO(_placedOrderService.GetAllOrders()));
        }


    }
}