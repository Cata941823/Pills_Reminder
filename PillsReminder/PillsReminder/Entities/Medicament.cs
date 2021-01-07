using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Entities
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Denumire { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<DozaMedicament> DozaMedicaments { get; set; }

    }
}
