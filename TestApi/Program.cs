using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestApi
{
    internal class Program
    {
        static Random random = new Random((int)DateTime.Now.Ticks);
        static void Main(string[] args)
        {
            Dictionary<int, TiketStatistic> dictinary = new Dictionary<int, TiketStatistic>();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            DateTime startTime = DateTime.Now.AddDays(-3);
            DateTime endTime;
            List<int> pointNumers = new List<int>();
            Queue<int> queue = new Queue<int>();
            DateTime curent = startTime;
            DateTime pointTime = startTime;
            for (int i = 0 ; i < 100; i++)
            {
                curent = curent.AddMinutes(1).AddSeconds(45);
                DateTime tiketTime = curent.AddSeconds(random.Next(45));
                pointTime = tiketTime.AddSeconds(random.Next(7,40));
                dictinary.Add(i, new TiketStatistic() { Number = i, Start = tiketTime});
                if (!pointNumers.Any())
                {
                    pointNumers.AddRange(new[] { 1, 2, 3, 4 });
                }
                PrintAddClient(i, tiketTime);
                queue.Enqueue(i);
                if (random.Next(10) > 3)
                {
                    int pointNumber = pointNumers[random.Next(0, pointNumers.Count)];
                    pointNumers.Remove(pointNumber);

                    int number = queue.Dequeue();
                    dictinary[number].End = pointTime;

                    PrintClintServiced(number, $"Кабинет {pointNumber}", pointTime);
                }
            }
            while (queue.Count > 0)
            {
                if (!pointNumers.Any())
                {
                    pointNumers.AddRange(new[] { 1, 2, 3, 4 });
                }
                curent = curent.AddMinutes(2).AddSeconds(30);
                pointTime = curent.AddSeconds(random.Next(13, 90));

                int pointNumber = pointNumers[random.Next(0, pointNumers.Count)];
                pointNumers.Remove(pointNumber);

                int number = queue.Dequeue();
                dictinary[number].End = pointTime;

                PrintClintServiced(number, $"Кабинет {pointNumber}", pointTime);

                endTime = pointTime;
            }

            Console.WriteLine($"------------------------------------------------------------------------------------------");
            List<TiketStatistic> tiketStatistics = dictinary.Values.ToList();
            Console.WriteLine($"Время начала моделирования {startTime}");
            Console.WriteLine($"Время окончания моделирования {pointTime}");
            Console.WriteLine($"Колличество клиентов в очереди {300}");
            Console.WriteLine($"Количество точек обслуживания {4}");
            Console.WriteLine($"Cреднее время ожидания {tiketStatistics.Sum(x=> x.Continiue.Minutes)/ tiketStatistics.Count}");
            Console.WriteLine($"Время макс время ожидания{tiketStatistics.Max(x=> x.Continiue.Minutes)}");

        }
        static private void PrintAddClient(int tiketNumber, DateTime time )
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
        public int Number { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Continiue => End - Start;
    }
}
