using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Dto.Maps;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/ServicePoint")]
    [ApiController]
    public class ServicePointController : ControllerBase
    {
        private readonly EqDbContext _context = new EqDbContext();
        private readonly IMapper _mapper = DtoMapperConfiguration.CreateMapper();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(_context.ServicePoints.Select(x => _mapper.Map<ServicePointDto>(x)));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<ServicePointDto> value)
        {
            try
            {
                _context.AddRange(value.Select(x => _mapper.Map<ServicePointDomain>(x)));
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        public IActionResult Put([FromBody] IEnumerable<ServicePointDto> value)
        {
            try
            {
                _context.UpdateRange(value.Select(x => _mapper.Map<ServicePointDomain>(x)));
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] IEnumerable<long> ids)
        {
            try
            {
                _context.ServicePoints.RemoveRange(_context.ServicePoints.Find(ids.ToArray()));
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
