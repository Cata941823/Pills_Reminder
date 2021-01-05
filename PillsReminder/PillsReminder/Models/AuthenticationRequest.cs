using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Models
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Parola { get; set; }
    }
}
