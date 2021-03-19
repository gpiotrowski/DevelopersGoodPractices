using System.Collections.Generic;

namespace SRP_good
{
    public class UserManager
    {
        private NotifyManager _notifyManager;
        public List<User> Users { get; set; }

        public UserManager(NotifyManager notifyManager)
        {
            _notifyManager = notifyManager;
        }

        public void AddUser(string name)
        {
            Users.Add(new User(name));

            _notifyManager.NotifyAboutNewUser();
        }
    }
}
