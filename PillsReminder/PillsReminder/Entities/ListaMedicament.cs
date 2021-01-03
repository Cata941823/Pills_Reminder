using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Entities
{
    public class ListaMedicament
    {
        public int Id { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
