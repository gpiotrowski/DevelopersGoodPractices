using System.Collections.Generic;

namespace DIP_bad
{
    public class UserManager
    {
        private NotifyManager _notifyManager;
        public List<User> Users { get; set; }

        public UserManager()
        {
            _notifyManager = new NotifyManager();
        }

        public void AddUser(string name)
        {
            Users.Add(new User(name));

            _notifyManager.NotifyAboutNewUser();
        }
    }
}
