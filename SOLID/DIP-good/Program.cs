using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_good
{
    class Program
    {
        static void Main(string[] args)
        {
            INotifyManager notifyManager = new NotifyManager(); //Here could be factory or we could receive this object from somewhere else

            UserManager userManager = new UserManager(notifyManager);
        }
    }
}
