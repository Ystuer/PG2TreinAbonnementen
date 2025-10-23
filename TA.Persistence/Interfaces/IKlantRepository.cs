using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Persistence.Entities;

namespace TA.Persistence.Interfaces
{
    public interface IKlantRepository
    {
        Klant CreateKlant(Klant klant);
        Klant GetKlant(int id);
        IEnumerable<Klant> GetAllKlanten();
        Klant UpdateKlant(Klant klant, int id);
        void DeleteKlant(int id);
    }
}
