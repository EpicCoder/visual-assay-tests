using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace android_test.Entity
{
    class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string userName, string userPass)
        {
            Name = userName;
            Password = userPass;
        }
    }
}
