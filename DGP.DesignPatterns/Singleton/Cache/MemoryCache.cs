namespace DGP.DesignPatterns.Singleton.Cache
{
    public class MemoryCache
    {
        public static MemoryCache Instance { get; } = new MemoryCache();

        private MemoryCache() { }
    }
}
