using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.EQServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ElectronicQueue.EQServer.Controllers
{
    [ApiController]
    [Route("api/ServiceProvider")]
    public class ServiceProviderController : ControllerBase
    {
        // GET: api/<ServiceStatistcController>
        [HttpGet]
        public IEnumerable<ServiceProviderDto> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ServiceStatistcController>/5
        [HttpGet("{id}")]
        public ServiceProviderDto Get(long id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ServiceStatistcController>
        [HttpPost]
        public void Post([FromBody] ServiceProviderDto value)
        {
        }

        // PUT api/<ServiceStatistcController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ServiceProviderDto value)
        {
        }

        // DELETE api/<ServiceStatistcController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }

        [HttpPost]
        public IActionResult Save([FromBody] IEnumerable<ServiceProviderDto> toAdd, 
                                  [FromBody] IEnumerable<ServiceProviderDto> toUpdate )
        {
            try
            {
                var serviceProviders = _serviceProviderService.GetAllWithServices();
                string json = JsonSerializer.Serialize(serviceProviders);
                return base.Ok(serviceProviders);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
