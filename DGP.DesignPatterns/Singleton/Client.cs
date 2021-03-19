using DGP.DesignPatterns.Singleton.Cache;

namespace DGP.DesignPatterns.Singleton
{
    class Client
    {
        public void Execute()
        {
            var memoryCache = MemoryCache.Instance;
            var lazyMemoryCache = LazyMemoryCache.GetInstance();
        }
    }
}
