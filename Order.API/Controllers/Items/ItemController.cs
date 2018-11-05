using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Controllers.Items.Mapper.DTO;
using Order.API.Controllers.Items.Mapper.Interface;
using Order.Domain.Items.Exceptions;
using Order.Services.ItemServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Items
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemService _itemService;
        private readonly IItemMapper _itemMapper;

        public ItemController(IItemService Service, IItemMapper Mapper)
        {
            _itemService = Service;
            _itemMapper = Mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<ItemDTO>> GetAllItems()
        {
            return Ok(_itemMapper.ListOfCustomersToDTO(_itemService.GetAllItems()));
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpPost]
        public ActionResult AddNewItem([FromBody]AddNewItemDTO givenItem)
        {
            try
            {
                _itemService.AddNewItem(_itemMapper.DTOToItem(givenItem));
                return Ok();
            }
            catch (ItemException ItemEx)
            { return BadRequest(ItemEx.Message); }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

    }
}