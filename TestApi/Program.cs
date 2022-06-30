using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestApi
{
    internal class Program
    {
        const double ErrorRate = 0.1;
        const int AppearancePeriod = 1 * 60;
        const int ServicedTime = 4 * 60;
        const int ClientWaitTime = 1 * 60;
        private const int TicketCount = 50;

        static void Main(string[] args)
        {
            ConsoleConfiguration();
            Random random = new Random((int)DateTime.Now.Ticks);
            var arra = new String[] { "Полина", "Эдик", "Андрей" };
            Console.WriteLine(arra[random.Next(3)]);
            //DateTime startTime = DateTime.Now.AddDays(-10);
            //DateTime curentTime = startTime;
            //Queue<TiketStatistic> queue = new Queue<TiketStatistic>();
            //List<string> serviceNames = new List<string>() { "Услуга2", "Услуга3", "Услуга1" };
            //List<GenerateObject> generateObjects = new List<GenerateObject>()

            //{
            //    new ClientFlow(serviceNames, ErrorRate, curentTime.AddMinutes(-1), queue, random, AppearancePeriod, 1, TicketCount),
            //    new Point(queue,"Кабинет1",ErrorRate,ClientWaitTime,ServicedTime-2,curentTime,random),
            //    new Point(queue,"Кабинет2",ErrorRate,ClientWaitTime,ServicedTime+2,curentTime,random),
            //    new Point(queue,"Кабинет3",ErrorRate,ClientWaitTime,ServicedTime-1,curentTime,random),
            //    new Point(queue,"Кабинет4",ErrorRate,ClientWaitTime,ServicedTime+1,curentTime,random),
            //};
            //do
            //{
            //    curentTime = curentTime.AddSeconds(1);
            //    foreach (var generateObject in generateObjects.OrderBy(x => x.NextActiveTime))
            //    {
            //        string activeString = generateObject.TickHandler(curentTime);
            //        if (activeString != null)
            //        {
            //            Console.WriteLine($"{curentTime}: {activeString}");
            //        }
            //    }
            //} while (generateObjects.OfType<ClientFlow>().Any(x => x.IsShutDown)
            //      || generateObjects.OfType<Point>().Any(x => x.CurentTicket != null)
            //      || queue.Count != 0);
            //var flow = generateObjects.OfType<ClientFlow>().First();
            //Console.WriteLine($"------------------------------------------------------------------------------------------");
            //Console.WriteLine($"Время начала моделирования {startTime}");
            //Console.WriteLine($"Время окончания моделирования {curentTime}");
            //Console.WriteLine($"Колличество клиентов в очереди {TicketCount}");
            //Console.WriteLine($"Количество точек обслуживания {generateObjects.OfType<Point>().Count()}");
            //Console.WriteLine($"Cреднее время ожидания {flow.Tickets.Sum(x => x.TotalContiniue.Minutes) / TicketCount}");
            //Console.WriteLine($"Время макс время ожидания {flow.Tickets.Max(x => x.TotalContiniue.Minutes)}");
            //Console.WriteLine($"Время мин время ожидания {flow.Tickets.Min(x => x.TotalContiniue.Minutes)}");

        }

        private static void ConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        static private void PrintAddClient(int tiketNumber, DateTime time)
        {
            Console.WriteLine($"Талон С{tiketNumber} добавлен в очередь: {time}");
        }
        static private void PrintClintServiced(int tiketNumber, string pointName, DateTime time)
        {
            Console.WriteLine($"Талон С{tiketNumber} обслужан на точке обслуживания {pointName}: {time}");
        }
        static private void PrintAddClient(string pointName)
        {
            Console.WriteLine($"Точка обслуживания {pointName} запущена");
        }
    }

    class TiketStatistic
    {
        public TiketStatistic(string serviceName, int number, DateTime addTime)
        {
            ServiceName = serviceName;
            Number = number;
            AddTime = addTime;
        }
        public void StartServiced(DateTime time)
        {
            Start = time;
        }
        public void EndServiced(DateTime time)
        {
            End = time;
        }
        public string ServiceName { get; private set; }
        public int Number { get; private set; }
        public DateTime AddTime { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public TimeSpan ServicedContiniue => End - Start;
        public TimeSpan TotalContiniue => End - AddTime;
        public string Name => "C" + Number;
    }
    class Point : GenerateObject
    {
        public Point(Queue<TiketStatistic> queue, string pointName, double errorRate, int clientWaitTime, int servicedTime, DateTime nextActiveTime, Random random)
           : base(queue, random, errorRate, nextActiveTime)
        {
            PointName = pointName;
            ClientWaitTime = clientWaitTime;
            ServicedTime = servicedTime;
        }

        public int ClientWaitTime { get; }
        public int ServicedTime { get; private set; }
        public string PointName { get; set; }
        public TiketStatistic CurentTicket { get; set; }

        public override string TickHandler(DateTime time)
        {
            if (time > NextActiveTime)
            {
                if (CurentTicket == null)
                {
                    if (Queue.Count == 0)
                    {
                        GenerateNextActiveTime(time, 0);
                        return null;
                    }
                    CurentTicket = Queue.Dequeue();
                    GenerateNextActiveTime(time, ClientWaitTime);
                    return GenerateMessage("вызвал");
                }
                if (CurentTicket.Start == default)
                {
                    CurentTicket.StartServiced(time);
                    GenerateNextActiveTime(time, ServicedTime);
                    return GenerateMessage("начал обслуживать");
                }
                if (CurentTicket.End == default)
                {
                    CurentTicket.EndServiced(time);
                    GenerateNextActiveTime(time, 5);
                    string message = GenerateMessage("закночил обслуживать");
                    CurentTicket = null;
                    return message;
                }
            }
            return null;
        }

        private string GenerateMessage(string activeName)
        {
            return $"{PointName} {activeName} талон с номером {CurentTicket.Name}, наименование улсуги \"{CurentTicket.ServiceName}\"";
        }
    }
    class ClientFlow : GenerateObject
    {
        public bool IsShutDown => TicketCount > 0;
        public List<TiketStatistic> Tickets { get; private set; }
        public int TicketCount { get; set; }
        public int NextTicketNumber { get; set; }
        public int AppearancePeriod { get; set; }
        public List<string> ServiceNames { get; set; }

        public ClientFlow(List<string> serviceNames,
                          double errorRate,
                          DateTime nextActiveTime,
                          Queue<TiketStatistic> queue,
                          Random random,
                          int appearancePeriod,
                          int nextTicketNumber = 0,
                          int ticketCount = 300)
            : base(queue, random, errorRate, nextActiveTime)
        {
            ServiceNames = serviceNames;
            AppearancePeriod = appearancePeriod;
            ErrorRate = errorRate;
            NextActiveTime = nextActiveTime;
            NextTicketNumber = nextTicketNumber;
            TicketCount = ticketCount;
            Tickets = new List<TiketStatistic>();
        }

        public override string TickHandler(DateTime time)
        {
            if (time > NextActiveTime && IsShutDown)
            {
                var ticket = new TiketStatistic(ServiceNames[Random.Next(0, ServiceNames.Count)], NextTicketNumber++, time);
                Queue.Enqueue(ticket);
                Tickets.Add(ticket);
                TicketCount--;
                GenerateNextActiveTime(time, AppearancePeriod);
                return $"В очередь на сервис \"Сервис3\" добавлен талон {ticket.Name} на услугу \"{ticket.ServiceName}\"";
            }
            return null;
        }
    }
    abstract class GenerateObject
    {
        public GenerateObject(Queue<TiketStatistic> queue, Random random, double errorRate, DateTime nextActiveTime)
        {
            Queue = queue;
            Random = random;
            ErrorRate = errorRate;
            NextActiveTime = nextActiveTime;
        }

        public Queue<TiketStatistic> Queue { get; protected set; }
        public Random Random { get; protected set; }
        public double ErrorRate { get; protected set; }
        public DateTime NextActiveTime { get; protected set; }
        protected void GenerateNextActiveTime(DateTime time, int waitMinute)
        {
            NextActiveTime = time.AddSeconds(waitMinute + (Random.Next(-waitMinute, waitMinute) * ErrorRate));
        }
        public abstract string TickHandler(DateTime time);
    }
}
