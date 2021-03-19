using System;

namespace DIP_bad
{
    public class NotifyManager
    {
        public void NotifyAboutNewUser()
        {
            //It could by sending email, notification, send sms, turn on alarm etc.
            Console.WriteLine("RED ALERT! New user - WoooHooooo~!");
        }
    }
}
