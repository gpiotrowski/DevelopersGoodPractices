using System.Text;
using DGP.DesignPatterns.Observer.Models;

namespace DGP.DesignPatterns.Observer
{
    public interface INewsObserver
    {
        void NewsAdded(News news);
    }
}
