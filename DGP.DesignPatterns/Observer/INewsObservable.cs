namespace DGP.DesignPatterns.Observer
{
    public interface INewsObservable
    {
        void AddObserver(INewsObserver observer);
        void RemoveObserver(INewsObserver observer);
    }
}