using System;
using DGP.DesignPatterns.Observer.Models;

namespace DGP.DesignPatterns.Observer.Notifications
{
    public class NewNewsEmailNotification : INewsObserver
    {
        public void NewsAdded(News news)
        {
            Console.WriteLine("Send news via email...");
        }
    }
}