using ElectronicQueue.Data.Dto.Entitys.Queue;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        // GET: api/<ServiceStatistcController>
        [HttpGet]
        public IEnumerable<QueueDto> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ServiceStatistcController>/5
        [HttpGet("{id}")]
        public QueueDto Get(long id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ServiceStatistcController>
        [HttpPost]
        public void Post([FromBody] QueueDto value)
        {
        }

        // PUT api/<ServiceStatistcController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] QueueDto value)
        {
        }

        // DELETE api/<ServiceStatistcController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
