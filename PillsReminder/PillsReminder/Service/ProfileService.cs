using PillsReminder.Entities;
using PillsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Service
{
#pragma warning disable IDE1006 // Naming Styles
    public interface ProfileService
#pragma warning restore IDE1006 // Naming Styles
    {
        //List<User> GetAll();
        User GetUserById(int id);
        bool EditProfile(UserProfileResponse request, int Id);
        bool DeleteUserById(int id);
    }
}
