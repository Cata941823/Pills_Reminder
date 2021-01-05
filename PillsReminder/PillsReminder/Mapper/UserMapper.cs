using PillsReminder.Entities;
using PillsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(RegisterRequest request)
        {
            return new User
            {
                Nume = request.Nume,
                Prenume = request.Prenume,
                Email = request.Email,
                Parola = request.Parola
            };
        }

        public static User ToUserExtension(this RegisterRequest request)
        {
            return new User
            {
                Nume = request.Nume,
                Prenume = request.Prenume,
                Email = request.Email,
                Parola = request.Parola
            };
        }
    }
}
