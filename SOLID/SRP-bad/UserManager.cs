using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_bad
{
    public class UserManager
    {
        public List<User> Users { get; set; }

        public void AddUser(string name)
        {
            Users.Add(new User(name));

            //It could by sending email, notification, send sms, turn on alarm etc.
            Console.WriteLine("RED ALERT! New user - WoooHooooo~!");
        }
    }
}
