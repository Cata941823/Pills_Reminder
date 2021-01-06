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
            User user = userRepository.FindById(id);
            userRepository.Delete(user);
            userRepository.SaveChanges();

            if (userRepository.FindById(id) == null)
            {
                return true;
            }

            return false;
        }

        public bool EditProfile(UserProfileResponse request, int id)
        {
            User user = userRepository.FindById(id);
            user.Nume = request.Nume;
            user.Prenume = request.Prenume;

            userRepository.Update(user);
            return userRepository.SaveChanges();

        }

        /*public List<User> GetAll()
        {
            return userRepository.GetAll();
        }*/

        public User GetUserById(int id)
        {
            User response = userRepository.FindById(id);
            response.Parola = null;
            return response;
        }
    }
}
