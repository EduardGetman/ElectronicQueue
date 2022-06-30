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
    [Route("api/ServicePoint")]
    [ApiController]
    public class ServicePointController : ControllerBase
    {
        private readonly EqDbContext _context = EqDbContextFactory.GetContext();
        private readonly IMapper _mapper;

        public ServicePointController(IMapper mapper, EqDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dtos = _context.ServicePoints.AsNoTracking().Select(x => _mapper.Map<ServicePointDto>(x)).ToList();
                return base.Ok(dtos);
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
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] IEnumerable<ServicePointDto> value)
        {
            try
            {
                _context.UpdateRange(value.Select(x => _mapper.Map<ServicePointDomain>(x)));
                _context.SaveChanges();
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
                _context.ServicePoints.RemoveRange(_context.ServicePoints.Where(x => ids.Contains(x.Id)));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
        [HttpPut]
        [Route("PointStateChange")]
        public IActionResult Put([FromBody] PointStateChangeDto dto)
        {
            try
            {
                var point = _context.ServicePoints.First(x => x.Id == dto.ServicePointId);
                var worker = _context.Worker.First(x => x.Id == dto.WorkerId);

                switch (dto.ServicePointState)
                {
                    case Data.Common.Enums.ServicePointState.Free:
                        point.ProviderId = dto.ProviderId;
                        worker.PointId = dto.ServicePointId;
                        break;
                    case Data.Common.Enums.ServicePointState.Closed:
                        point.ProviderId = null;
                        worker.PointId = null;
                        break;
                    case Data.Common.Enums.ServicePointState.Paused:
                        point.ProviderId = dto.ProviderId;
                        worker.PointId = dto.ServicePointId;
                        break;
                    default:
                        throw new Exception("Неизветсная команада");
                }
                point.ServicePointState = dto.ServicePointState; 
                _context.Update(point);
                _context.Update(worker);
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
