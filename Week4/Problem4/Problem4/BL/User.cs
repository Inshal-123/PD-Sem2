using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    internal class User
    {
        public User()
        {
        }

        public User(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public string username;
        public string password;
        public string role;

        public bool SignIn(List<User> users, User user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (user.username == users[i].username && user.password == users[i].password && user.role == users[i].role)
                    return true;
            }
            return false;
        }

    }
}
