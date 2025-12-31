using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Persistence.Entities;

namespace TA.Persistence.Interfaces
{
    public interface IAbonnementRepository
    {
        Task<Abonnement> CreateAbonnement(Abonnement abonnement);
        Task<Abonnement> GetAbonnement(int id);
        Task<IEnumerable<Abonnement>> GetAllAbonnements();
        //Abonnement UpdateAbonnement(Abonnement abonnement, int id);
        Task DeleteAbonnement(int id);
    }
}
