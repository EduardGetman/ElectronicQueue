using Microsoft.EntityFrameworkCore;

namespace ElectronicQueue.Infrastructure.Persistence
{
    public class EqDbContextFactory
    {
        private static EqDbContext instance;
        public static EqDbContext GetContext()
        {
            if (instance == null)
                instance = new EqDbContext();
            return instance;
        }
    }

    public class GlobalConfig
    {
        public static string SqlConnectionString { get; set; }
    }
}
