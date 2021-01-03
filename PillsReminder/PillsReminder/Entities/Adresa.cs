using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Entities
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Locatie { get; set; }
        public int IdUtilizator { get; set; }
        public virtual User User { get; set; }
    }
}
