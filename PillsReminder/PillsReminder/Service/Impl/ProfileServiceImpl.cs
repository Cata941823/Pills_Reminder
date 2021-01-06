using Microsoft.Extensions.Options;
using PillsReminder.Entities;
using PillsReminder.Helpers;
using PillsReminder.Models;
using PillsReminder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Service.Impl
{
    public class ProfileServiceImpl : ProfileService
    {
        private readonly UserRepository userRepository;
        private readonly AppSettings appSettings;

        public ProfileServiceImpl(UserRepository userRepository, IOptions<AppSettings> options)
        {
            this.userRepository = userRepository;
            this.appSettings = options.Value;
        }

        public bool DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditProfile(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
