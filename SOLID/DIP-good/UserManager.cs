using System.Collections.Generic;

namespace DIP_good
{
    public class UserManager
    {
        private INotifyManager _notifyManager;
        public List<User> Users { get; set; }

        public UserManager(INotifyManager notifyManager)
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
