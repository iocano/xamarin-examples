using AppNavigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppNavigation.Services
{
    internal class UserActivityService
    {
        public static ObservableCollection<UserActivity> Activities = new ObservableCollection<UserActivity>
        {
            new UserActivity { UserId = 1, Description = "Your contact Name A is active" },
            new UserActivity { UserId = 2, Description = "Your contact Name B is active" },
            new UserActivity { UserId = 3, Description = "Your contact Name C is active" },
            new UserActivity { UserId = 4, Description = "Your contact Name D is active" },
            new UserActivity { UserId = 5, Description = "Your contact Name E is active" },
            new UserActivity { UserId = 6, Description = "Your contact Name F is active" },
            new UserActivity { UserId = 7, Description = "Your contact Name G is active" },
            new UserActivity { UserId = 8, Description = "Your contact Name H is active" },
            new UserActivity { UserId = 9, Description = "Your contact Name I is active" },
        };
    }
}
