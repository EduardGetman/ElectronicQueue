using AutoMapper;
using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Common.Extansion;
using ElectronicQueue.Data.Domain;
using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.Data.Dto.Maps;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/ServicePoint")]
    [ApiController]
    public class ServicePointController : ControllerBase
    {
        private readonly EqDbContext _context = new EqDbContext();
        private readonly IMapper _mapper = DtoMapperConfiguration.CreateMapper();

        // GET: api/<ServicePoint>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(_context.ServicePoints.Select(x => _mapper.Map<ServicePointDto>(x)));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        // GET api/<ServicePointController>/5
        [HttpGet("{id}")]
        public ServicePointDto Get(long id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ServicePointController>
        [HttpPost]
        public void Post([FromBody] ServicePointDto value)
        {
        }

        // PUT api/<ServicePointController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ServicePointDto value)
        {
        }

        // DELETE api/<ServicePointController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
