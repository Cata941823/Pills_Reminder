using PillsReminder.Entities;
using PillsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Service
{
    public interface UserService
    {
        bool Register(RegisterRequest request);
        AuthenticationResponse Login(AuthenticationRequest request);
    }
}
