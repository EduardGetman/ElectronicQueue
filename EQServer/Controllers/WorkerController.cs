using ElectronicQueue.Core.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        // GET: api/<WorkerStatistcController>
        [HttpGet]
        public IEnumerable<WorkerDto> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<WorkerStatistcController>/5
        [HttpGet("{id}")]
        public WorkerDto Get(long id)
        {
            throw new NotImplementedException();
        }

        // POST api/<WorkerStatistcController>
        [HttpPost]
        public void Post([FromBody] WorkerDto value)
        {
        }

        // PUT api/<WorkerStatistcController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] WorkerDto value)
        {
        }

        // DELETE api/<WorkerStatistcController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
