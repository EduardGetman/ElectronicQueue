using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Helpers;
using ElectronicQueue.Core.Application.Interfaces;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Controllers
{
    [Route("api/Worker")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly EqDbContext _context = EqDbContextFactory.GetContext();
        private readonly IHashFunction _hashFunction = HashFunctionFactory.GetDefoultHashFunction();
        private readonly IMapper _mapper;

        public WorkerController(IMapper mapper, EqDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(_context.Worker.Include(x => x.Account)
                                              .Include(x => x.Point)
                                              .AsNoTracking()
                                              .Select(x => _mapper.Map<WorkerDto>(x)));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<WorkerDto> dtos)
        {
            try
            {
                foreach (var domain in dtos.Select(x => _mapper.Map<WorkerDomain>(x)))
                {
                    domain.Account.PasswordHash = _hashFunction.GetHash(domain.Account.PasswordHash);
                    _context.Add(domain.Account);
                    _context.Add(domain);

                    _context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] IEnumerable<WorkerDto> dtos)
        {
            try
            {
                foreach (var domain in dtos.Select(x => _mapper.Map<WorkerDomain>(x)))
                {
                    domain.Account.PasswordHash = _hashFunction.GetHash(domain.Account.PasswordHash);
                    _context.Update(domain.Account);
                    _context.Update(domain);
                }

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
                _context.Accounts.RemoveRange(_context.Worker.Where(x => ids.Contains(x.Id)).Select(x=> x.Account));
                _context.Worker.RemoveRange(_context.Worker.Where(x => ids.Contains(x.Id)));
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
