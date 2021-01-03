using PillsReminder.Repository;
using PillsReminder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillsReminder.Data;
using AppContext = PillsReminder.Data.AppContext;

namespace PillsReminder.Repository.Impl
{
    public class UserRepositoryImpl : GenericRepositoryImpl<User>, UserRepository
    {
        public UserRepositoryImpl(AppContext context) : base(context)
        {
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _table.Where(x => x.Email == email && x.Parola == password).FirstOrDefault();
        }
    }
}
