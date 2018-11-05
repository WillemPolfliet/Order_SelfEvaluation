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


        [HttpGet]
        public ActionResult<List<CostumerDTO>> GetAllBooks()
        {
            return Ok(_costumerMapper.ListOfCustomersToDTO(_costumerService.GetAllCostumers()));
        }

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