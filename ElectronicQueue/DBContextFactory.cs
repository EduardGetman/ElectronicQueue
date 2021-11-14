namespace ElectronicQueue.Data
{
    public static class ContextFactory
    {
        static public EqDbContext CreateContext()
        {
            return new EqDbContext();
        }
    }
}