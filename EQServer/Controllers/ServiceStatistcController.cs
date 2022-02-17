using ElectronicQueue.Core.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicQueue.EQServer.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStatistcController : ControllerBase
    {
        // GET: api/<ServiceStatistcController>
        [HttpGet]
        public IEnumerable<ServiceStatisticDto> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ServiceStatistcController>/5
        [HttpGet("{id}")]
        public ServiceStatisticDto Get(long id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ServiceStatistcController>
        [HttpPost]
        public void Post([FromBody] ServiceStatisticDto value)
        {
        }

        // PUT api/<ServiceStatistcController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ServiceStatisticDto value)
        {
        }

        // DELETE api/<ServiceStatistcController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
