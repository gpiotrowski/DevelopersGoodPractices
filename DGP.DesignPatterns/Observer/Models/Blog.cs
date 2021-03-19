using System.Collections.Generic;

namespace DGP.DesignPatterns.Observer.Models
{
    public class Blog : INewsObservable
    {
        private readonly List<INewsObserver> _newsObservers = new List<INewsObserver>();

        public void AddObserver(INewsObserver observer)
        {
            _newsObservers.Add(observer);
        }

        public void RemoveObserver(INewsObserver observer)
        {
            _newsObservers.Remove(observer);
        }

        public void AddNews()
        {
            var news = new News();

            foreach (var newsObserver in _newsObservers)
            {
                newsObserver.NewsAdded(news);
            }
        }
    }
}