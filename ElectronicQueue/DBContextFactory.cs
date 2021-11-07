using Microsoft.EntityFrameworkCore;
namespace ElectronicQueue.Data
{
    class DBContextFactory:IDbContextFactory<Context>
    {
        public Context CreateDbContext()
        {
            return new Context();
        }
    }
}