namespace ElectronicQueue.Infrastructure.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(EqDbContext context)
        {
            context.Database.EnsureCreated();   
        }
    }
}
