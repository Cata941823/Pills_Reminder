using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Models
{
    public class RegisterRequest
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal object ToUserEntity()
        {
            throw new NotImplementedException();
        }
    }
}
