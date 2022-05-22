using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Controllers
{
    [ApiController]
    [Route("api/ServiceProvider")]
    public class ServiceProviderController : ControllerBase
    {
        private readonly EqDbContext _context;
        private readonly IMapper _mapper;

        public ServiceProviderController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new EqDbContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var domains = _context.ServiceProviders.Include(x => x.Services)
                                                       .AsNoTracking()
                                                       .ToList();
                var dtos = new List<ServiceProviderDto>();

                foreach (var domain in domains)
                {
                    var dto = _mapper.Map<ServiceProviderDto>(domain);
                    dto.Services = domain.Services.Select(x => _mapper.Map<ServiceDto>(x)).ToList();
                    dtos.Add(dto);
                }

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var domain = _context.ServiceProviders.Include(x => x.Services)
                                                      .Include(x => x.ServicePoints).Where(x => x.Id == id)
                                                      .AsNoTracking()
                                                      .FirstOrDefault();
                var dto = _mapper.Map<ServiceProviderDto>(domain);

                dto.Services = domain.Services.Select(x => _mapper.Map<ServiceDto>(x)).ToList();
                dto.ServicePoints = domain.ServicePoints.Select(x => _mapper.Map<ServicePointDto>(x)).ToList();

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] IEnumerable<ServiceProviderDto> dtos)
        {
            try
            {
                _context.AddRange(dtos.Select(x => _mapper.Map<ServiceProviderDomain>(x)));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPost]
        [Route("AddWithService")]
        public IActionResult AddWithService([FromBody] IEnumerable<ServiceProviderDto> dtos)
        {
            try
            {
                foreach (var dto in dtos)
                {
                    var domain = _mapper.Map<ServiceProviderDomain>(dto);
                    domain.Services = dto.Services.Select(x => _mapper.Map<ServiceDomain>(x)).ToList();
                    _context.Add(domain);
                }
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] IEnumerable<ServiceProviderDto> value)
        {
            try
            {
                _context.UpdateRange(value.Select(x => _mapper.Map<ServiceProviderDomain>(x)));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(IEnumerable<long> ids)
        {
            try
            {
                _context.RemoveRange(_context.ServiceProviders.Where(x => ids.Contains(x.Id)));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
