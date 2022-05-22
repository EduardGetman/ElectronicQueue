using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ElectronicService.EQServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly EqDbContext _context;
        private readonly IMapper _mapper;

        public ServiceController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new EqDbContext();
        }

        [HttpGet("providerId")]
        public IActionResult Get(long providerId)
        {
            try
            {
                return Ok(_context.Services.Where(x => x.ProviderId == providerId).Select(x => _mapper.Map<ServiceDto>(x)));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        // POST api/<ServiceStatistcController>
        [HttpPost]
        public void Post([FromBody] ServiceDto value)
        {
        }

        // PUT api/<ServiceStatistcController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ServiceDto value)
        {
        }

        // DELETE api/<ServiceStatistcController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
