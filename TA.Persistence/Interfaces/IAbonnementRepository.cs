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
        Abonnement CreateAbonnement(Abonnement abonnement);
        Abonnement GetAbonnement(int id);
        IEnumerable<Abonnement> GetAllAbonnements();
        //Abonnement UpdateAbonnement(Abonnement abonnement, int id);
        void DeleteAbonnement(int id);
    }
}
