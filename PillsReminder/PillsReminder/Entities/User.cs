using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }

        public virtual Adresa Adresa { get; set; }
        public virtual ICollection<DozaMedicament> DozaMedicament { get; set; }
        public virtual ListaMedicament ListaMedicament { get; set; }
    }

}
