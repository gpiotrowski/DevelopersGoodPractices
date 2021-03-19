using DGP.DesignPatterns.Observer.Models;
using DGP.DesignPatterns.Observer.Notifications;

namespace DGP.DesignPatterns.Observer
{
    class Client
    {
        public void Execute()
        {
            var blog = new Blog();

            var smsNotifier = new NewNewsSmsNotification();
            var emailNotifier = new NewNewsEmailNotification();

            blog.AddObserver(smsNotifier);
            blog.AddObserver(emailNotifier);

            blog.AddNews();
        }
    }
}
