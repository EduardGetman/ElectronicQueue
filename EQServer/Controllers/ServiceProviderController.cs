using ElectronicQueue.Data.Dto.Entitys.OrganizationInfo;
using ElectronicQueue.EQServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using AutoMapper;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicQueue.EQServer.Controllers
{
    [ApiController]
    [Route("api/ServiceProvider")]
    public class ServiceProviderController : ControllerBase
    {
        private readonly EqDbContext _context;
        private readonly IMapper _mapper;

        public ServiceProviderController()
        {
            _context = new EqDbContext();
            _mapper = DtoMapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var domain = _context.ServiceProviders.Include(x=> x.Services);
                var serviceProviders = _mapper.Map<IEnumerable<ServiceProviderDto>>(domain);
                return base.Ok(serviceProviders);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ServiceProviderDto Get(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] IEnumerable<ServiceProviderDto> value)
        {

        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] IEnumerable<ServiceProviderDto> value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {

        }
    }
}
