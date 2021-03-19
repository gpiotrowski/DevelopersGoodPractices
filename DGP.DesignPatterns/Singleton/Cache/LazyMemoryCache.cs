namespace DGP.DesignPatterns.Singleton.Cache
{
    public class LazyMemoryCache
    {
        private static LazyMemoryCache _instance;

        private LazyMemoryCache() { }

        public static LazyMemoryCache GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LazyMemoryCache();
            }

            return _instance;
        }
    }
}