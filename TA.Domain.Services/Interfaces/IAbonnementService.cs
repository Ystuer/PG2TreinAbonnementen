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
        Task<AbonnementResponseContract> CreateAbonnement(AbonnementRequestContract abonnementRequestContract);
        Task<AbonnementResponseContract> GetAbonnement(int id);
        Task<IEnumerable<AbonnementResponseContract>> GetAllAbonnements();
        //AbonnementResponseContract UpdateAbonnement(AbonnementRequestContract abonnementRequestContract, int id);
        Task DeleteAbonnement(int id);
    }
}
