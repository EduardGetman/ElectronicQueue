using ElectronicQueue.Core.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        [HttpGet("{id}")]
        public QueueDto Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public QueueDto GetByProviderId(long id)
        {
            throw new NotImplementedException();
        }

        [Route("Push")]
        [HttpPost]
        public void Push([FromBody] TicketDto value)
        {
        }


        [HttpPut("{id}")]
        public void Put(long id, [FromBody] QueueDto value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
