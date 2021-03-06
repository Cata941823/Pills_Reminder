using PillsReminder.Entities;
using PillsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Repository
{
    public interface UserRepository : GenericRepository<User>
    {
        User GetByEmailAndPassword(string email, string password);
        User FindByEmail(string email);
    }
}
