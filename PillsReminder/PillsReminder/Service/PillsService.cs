using PillsReminder.Entities;
using PillsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsReminder.Service
{
#pragma warning disable IDE1006 // Naming Styles
    public interface PillsService
#pragma warning restore IDE1006 // Naming Styles
    {
        bool CreateDoza(DozaMedicamentRequest dozaMedicament, int idUser);
        List<DozaMedicament> GetDoze(int Id);
        List<Medicament> GetPastile();
        bool UpdateDoza(int IdDoza, bool Luata);
        bool DeleteDoza(int IdDoza);
    }
}
