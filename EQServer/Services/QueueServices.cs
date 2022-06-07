using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.Core.Application.Helpers;
using ElectronicQueue.Core.Domain;
using ElectronicQueue.Data.Common.Enums;
using ElectronicQueue.Data.Common.Extansion;
using ElectronicQueue.EQServer.Interfaces;
using ElectronicQueue.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.EQServer.Services
{
    public class QueueServices : IQueueServices
    {
        private readonly EqDbContext _context;
        private readonly QueueLettersConverter _lettersConverter;
        public QueueServices() 
        { 
            _context = EqDbContextFactory.GetContext();
            _lettersConverter = new QueueLettersConverter();
        }

        public QueueDomain CreateQueue(List<string> existedLetters)
        {
            var exsistLetters = _context.Queues.Select(x => x.Letters)
                                   .Distinct()
                                   .ToList()
                                   .Concat(existedLetters)
                                   .Select(x => _lettersConverter.LettersToNumber(x));
            var letters = _lettersConverter.NumberToLetters(exsistLetters.Any() ? exsistLetters.Max() + 1 : 0);

            return new QueueDomain()
            {
                IsEnabled = false,
                Letters = letters,
                NextTicketNumber = 0
            };
        }

        public TicketDomain Pull(long ServiceProviderId)
        {
            var ticket = GetFirstTicket(ServiceProviderId);
            _context.Remove(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public TicketDomain Push(TicketCreateDto dto)
        {
            var queue = _context.Queues.First(x => x.ProviderId == dto.ProviderId);
            var service = _context.Services.First(x => x.Id == dto.ServiceId);
            if (!queue.IsEnabled)
            {
                throw new Exception($"Очередь на сервис \"{queue.Provider.Name}\" выключена");
            }
            if (!service.IsProvided)
            {
                throw new Exception($"Услуга \"{service.Name}\" не предоставляется");
            }
            var result = new TicketDomain()
            {
                CreateTime = DateTime.Now,
                Name = queue.Letters + queue.NextTicketNumber++,
                QueueId = queue.Id,
                ServiceId = service.Id,
                State = TicketState.Waiting
            };
            _context.Add(result);
            _context.SaveChanges();
            return result;
        }

        private TicketDomain GetFirstTicket(long ServiceProviderId)
        {
            var firstTicketTime = _context.Tickets.Where(x => x.Queue.ProviderId == ServiceProviderId)
                                                  .Max(x => x.CreateTime);
            return _context.Tickets.First(x => x.Queue.ProviderId == ServiceProviderId
                                            && x.CreateTime == firstTicketTime);
        }

        public void UpdateQueues(IEnumerable<QueueDto> dtos)
        {
            var ids = dtos.Select(x => x.Id);
            var domains = _context.Queues.Where(x => ids.Contains(x.Id));
            foreach (var id in ids)
            {
                var dto = dtos.First(x => x.Id == id);
                var domain = domains.First(x => x.Id == id);

                if (domain.IsEnabled && dto.Letters != domain.Letters)
                {
                    throw new Exception($"Невозможно изменить идентификатор({domain.Letters}->{dto.Letters})" +
                        $" очереди когда она включена");
                }

                if (dto.IsEnabled != domain.IsEnabled)
                {
                    if (dto.IsEnabled)
                    {
                        if (!_context.Services.Any(x => x.ProviderId == domain.ProviderId && x.IsProvided))
                        {
                            throw new Exception($"Не возможно запустить очередь не имеющую предоставляемых услуг");
                        }
                        domain.NextTicketNumber = 1;
                    }
                    else
                    {
                        foreach (var ticket in _context.Tickets.Where(x => x.QueueId == id))
                        {
                            //TODO: При сохранении логов менять талон на необслужен
                            _context.Remove(ticket);
                        }
                    }
                }
                domain.IsEnabled = dto.IsEnabled;
                domain.Letters = dto.Letters;
                _context.Update(domain);
            }
            _context.SaveChanges();
        }

        public TicketDomain SwitchTicketStatus(SwitchTicketStatusDto dto)
        {
            var ticket = GetFirstTicket(dto.ProviderId);

            if (ticket is null)
            {
                throw new Exception($"Очередь на данный сервис пуста");
            }
            if (ticket.СallingServicePoint != null && ticket.СallingServicePointId != dto.ServicePointId)
            {
                throw new Exception($"Данный талон уже обслуживается на другой точке обслуживания");
            }

            var statusSwitcher = new TicketStatusSwitcher(ticket.State);

            if (!statusSwitcher.NextTicketStates.Contains(dto.NewState))
            {
                throw new Exception($"Нельзя изменить состояние талона с \"{ticket.State.ToName()}\" " +
                    $"на \"{dto.NewState.ToName()}\" ");
            }

            ticket.State = dto.NewState;
            ticket.СallingServicePointId = dto.ServicePointId;
            _context.Update(ticket);
            _context.SaveChanges();
            return ticket;
        }
    }
}
