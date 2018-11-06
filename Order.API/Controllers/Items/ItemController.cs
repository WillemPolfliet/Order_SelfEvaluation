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

        [Authorize(Policy = "MustBeCostumer")]
        [HttpGet]
        public ActionResult<List<ItemDTO>> GetAllItems()
        {
            try
            {
                var result = _itemMapper.ListOfCustomersToDTO(_itemService.GetAllItems());
                return Ok(result);
            }
            catch (ItemException ItemEx)
            { return BadRequest(ItemEx.Message); }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpPost]
        public ActionResult AddNewItem([FromBody]NewItemDTO givenItem)
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

        [Authorize(Policy = "MustBeAdmin")]
        [HttpPut]
        [Route("{ItemGuidID}")]
        public ActionResult UpdateItem([FromRoute] Guid ItemGuidID, [FromBody] NewItemDTO ItemWithUpdateValues)
        {
            try
            {
                _itemService.UpdateItem(ItemGuidID, _itemMapper.DTOToItem(ItemWithUpdateValues));
                return Ok();
            }
            catch (ItemException ItemEx)
            { return BadRequest(ItemEx.Message); }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
    }
}