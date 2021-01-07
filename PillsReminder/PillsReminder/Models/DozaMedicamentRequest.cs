using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Models
{
    public class DozaMedicamentRequest
    {
        public int Cantitate_pastila { get; set; }
        public string DataInceput { get; set; }
        public int NumarZile { get; set; }
        public string Ora { get; set; }
        public int IdPastila { get; set; }

    }
}
