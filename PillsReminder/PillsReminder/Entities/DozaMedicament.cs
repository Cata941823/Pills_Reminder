using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Entities
{
    public class DozaMedicament
    {
        public int Id { get; set; }
        public int Cantitate_pastila{ get; set; }
        public DateTime Data { get; set; }
        public DateTime Ora { get; set; }
        public bool Luata { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
