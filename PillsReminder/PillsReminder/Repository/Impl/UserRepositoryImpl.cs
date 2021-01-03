using Lab4_451.Data.Interfaces;
using Lab4_451.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Repository.Impl
{
    public class UserRepositoryImpl : GenericRepository<User>, UserRepository
    {
        public UserRepositoryImpl(UserDbContext context) : base(context)
        {
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _table.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
