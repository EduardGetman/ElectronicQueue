using ElectronicQueue.Core.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerStatisticController : ControllerBase
    {
        // GET: api/<WorkerStatistcController>
        [HttpGet]
        public IEnumerable<WorkerStatisticDto> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<WorkerStatistcController>/5
        [HttpGet("{id}")]
        public WorkerStatisticDto Get(long id)
        {
            throw new NotImplementedException();
        }

        // POST api/<WorkerStatistcController>
        [HttpPost]
        public void Post([FromBody] WorkerStatisticDto value)
        {
        }

        // PUT api/<WorkerStatistcController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] WorkerStatisticDto value)
        {
        }

        // DELETE api/<WorkerStatistcController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
