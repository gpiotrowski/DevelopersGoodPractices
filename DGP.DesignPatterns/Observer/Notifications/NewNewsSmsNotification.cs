using System;
using DGP.DesignPatterns.Observer.Models;

namespace DGP.DesignPatterns.Observer.Notifications
{
    public class NewNewsSmsNotification : INewsObserver
    {
        public void NewsAdded(News news)
        {
            Console.WriteLine("Send notification about news via sms...");
        }
    }
}