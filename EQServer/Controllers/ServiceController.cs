using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ElectronicService.EQServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        // GET: api/<ServiceStatistcController>
        [HttpGet]
        public IEnumerable<ServiceDto> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ServiceStatistcController>/5
        [HttpGet("{id}")]
        public ServiceDto Get(long id)
        {
            throw new NotImplementedException();
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
