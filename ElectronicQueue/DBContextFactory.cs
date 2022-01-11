namespace ElectronicQueue.Data.Domain
{
    public static class ContextFactory
    {
        static public EqDbContext CreateContext()
        {
            return new EqDbContext();
        }
    }
}