using ElectronicQueue.Core.Application.Helpers;
using ElectronicQueue.Core.Domain;
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

        public void StopQueue(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public void StartQueue(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public TicketDomain Dequeu(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public TicketDomain Peek(long ServiceProviderId)
        {
            throw new NotImplementedException();
        }

        public void Push(long ServiceProviderId, TicketDomain ticket)
        {
            throw new NotImplementedException();
        }
    }
}
