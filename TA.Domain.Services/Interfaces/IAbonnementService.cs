using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;

namespace TA.Domain.Services.Interfaces
{
    public interface IAbonnementService
    {
        AbonnementResponseContract CreateAbonnement(AbonnementRequestContract abonnementRequestContract);
        AbonnementResponseContract GetAbonnement(int id);
        IEnumerable<AbonnementResponseContract> GetAllAbonnements();
        //AbonnementResponseContract UpdateAbonnement(AbonnementRequestContract abonnementRequestContract, int id);
        void DeleteAbonnement(int id);
    }
}
