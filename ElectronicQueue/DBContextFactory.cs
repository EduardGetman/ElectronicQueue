using Microsoft.EntityFrameworkCore;

namespace ElectronicQueue.Data
{
    public static class DBContextFactory
    {
        static public Context CreateDbContext()
        {
            return new Context();
        }
    }
}