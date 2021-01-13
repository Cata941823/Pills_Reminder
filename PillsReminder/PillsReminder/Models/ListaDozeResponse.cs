using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Models
{
    public class ListaDozeResponse
    {
        public int Id { get; set; }
        public int Cantitate_pastila { get; set; }
        public DateTime Data { get; set; }
        public DateTime Ora { get; set; }
        public bool Luata { get; set; }
        public int IdMedicament { get; set; }
        public string DenumireMedicament { get; set; }
        public int IdUser { get; set; }
    }
}
