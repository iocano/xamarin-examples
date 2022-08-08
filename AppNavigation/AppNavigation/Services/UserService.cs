using AppNavigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppNavigation.Services
{
    internal class UserService
    {
        private static readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Description = "Description for Name A", Name = "Name A" },
            new User { Id = 2, Description = "Description for Name B", Name = "Name B" },
            new User { Id = 3, Description = "Description for Name C", Name = "Name C" },
            new User { Id = 4, Description = "Description for Name D", Name = "Name D" },
            new User { Id = 5, Description = "Description for Name E", Name = "Name E" },
            new User { Id = 6, Description = "Description for Name F", Name = "Name F" },
            new User { Id = 7, Description = "Description for Name G", Name = "Name G" },
            new User { Id = 8, Description = "Description for Name H", Name = "Name H" },
            new User { Id = 9, Description = "Description for Name I", Name = "Name I" },
        };

        public static User GetUser(int id) => _users.SingleOrDefault(u => u.Id == id);
    }
}
