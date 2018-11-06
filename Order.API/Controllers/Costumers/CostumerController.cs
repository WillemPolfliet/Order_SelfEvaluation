using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Controllers.Costumers.Mapper.DTO;
using Order.API.Controllers.Costumers.Mapper.Interface;
using Order.Domain.Costumers.Exceptions;
using Order.Services.CostumerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers.Costumers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService _costumerService;
        private readonly ICostumerMapper _costumerMapper;

        public CostumerController(ICostumerService Service, ICostumerMapper Mapper)
        {
            _costumerService = Service;
            _costumerMapper = Mapper;
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpGet]
        public ActionResult<List<CostumerDTO>> GetAllCostumers()
        {
            try
            {
                var toReturn = _costumerMapper.ListOfCustomersToListDTO(_costumerService.GetAllCostumers());
                return Ok(toReturn);
            }
            catch (CostumerException costumerEx)
            { return BadRequest(costumerEx.Message); }
            catch (Exception Ex)
            { return BadRequest(Ex.Message); }
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpGet]
        [Route("{CostumerGuidID}")]
        public ActionResult<CostumerOverViewDTO> GetSpecificCostumer([FromRoute] Guid CostumerGuidID)
        {
            try
            {
                var toReturn = _costumerMapper.CostumerToCostumerOverViewDTO(_costumerService.GetSpecificCostumer(CostumerGuidID));
                return Ok(toReturn);
            }
            catch (CostumerException costumerEx)
            { return BadRequest(costumerEx.Message); }
            catch (Exception Ex)
            { return BadRequest(Ex.Message); }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterCostumer([FromBody]RegisteringNewCostumerDTO givenCostumer)
        {
            try
            {
                _costumerService.Register(_costumerMapper.DTOToCostumer(givenCostumer));
                return Ok();
            }
            catch (CostumerException CostumerEx)
            { return BadRequest(CostumerEx.Message); }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }


    }
}