using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.EQServer.Interfaces;
using ElectronicQueue.EQServer.Services;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/Queue")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueServices _queueServices;
        private readonly EqDbContext _context;
        private readonly IMapper _mapper;

        public QueueController(IMapper mapper)
        {
            _mapper = mapper;
            _context = EqDbContextFactory.GetContext();
            _queueServices = new QueueServices();

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var domains = _context.Queues.Include(x => x.Tickets)
                                             .Include(x => x.Provider)
                                             .AsNoTracking()
                                             .ToList();
                var dtos = new List<QueueDto>();

                foreach (var domain in domains)
                {
                    var dto = _mapper.Map<QueueDto>(domain);
                    dto.Tickets = domain.Tickets.Select(x => _mapper.Map<TicketDto>(x)).ToList();
                    dtos.Add(dto);
                }

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpGet("{providerId}")]
        public IActionResult GetByProviderId(long providerId)
        {
            try
            {
                var domain = _context.Queues.Include(x => x.Tickets)
                                            .Include(x => x.Provider)
                                            .Where(x => x.ProviderId == providerId)
                                            .AsNoTracking()
                                            .FirstOrDefault();
                var dto = _mapper.Map<QueueDto>(domain);

                dto.Tickets = domain.Tickets.Select(x => _mapper.Map<TicketDto>(x)).ToList();

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [Route("Push")]
        [HttpPost]
        public IActionResult Push([FromBody] TicketDto value)
        {
            throw new NotImplementedException();
        }


        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] QueueDto value)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
