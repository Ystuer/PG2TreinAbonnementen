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
        Task<Klant> CreateKlant(Klant klant);
        Task<Klant> GetKlant(int id);
        Task<IEnumerable<Klant>> GetAllKlanten();
        Task<Klant> UpdateKlant(Klant klant, int id);
        Task DeleteKlant(int id);
    }
}
