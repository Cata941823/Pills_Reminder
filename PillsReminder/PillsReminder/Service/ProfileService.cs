using PillsReminder.Entities;
using PillsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Service
{
    public interface ProfileService
    {
        List<User> GetAll();
        User GetUserById(int id);
        bool EditProfile(AuthenticationRequest request);
        bool DeleteUserById(int id);
    }
}
