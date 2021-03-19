using System;

namespace DIP_good
{
    public class NotifyManager : INotifyManager
    {
        public void NotifyAboutNewUser()
        {
            //It could by sending email, notification, send sms, turn on alarm etc.
            Console.WriteLine("RED ALERT! New user - WoooHooooo~!");
        }
    }
}
