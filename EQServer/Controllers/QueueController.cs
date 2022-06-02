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

        public QueueController(IMapper mapper, EqDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _queueServices = new QueueServices(context);
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

        [HttpPut()]
        public IActionResult Put([FromBody] IEnumerable<QueueDto> dtos)
        {
            try
            {
                _queueServices.UpdateQueues(dtos);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [Route("Push")]
        [HttpPost]
        public IActionResult Push([FromBody] TicketCreateDto value)
        {
            try
            {
                return Ok(_mapper.Map<TicketDto>(_queueServices.Push(value)));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [Route("SwitchTicketStatus")]
        [HttpPut()]
        public IActionResult SwitchTicketStatus([FromBody] SwitchTicketStatusDto dto)
        {
            try
            {
                return Ok(_mapper.Map<TicketDto>(_queueServices.SwitchTicketStatus(dto)));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
