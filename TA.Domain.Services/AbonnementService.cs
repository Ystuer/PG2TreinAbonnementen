using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Services.Interfaces;
using TA.Domain.Services.MappingExtensions;
using TA.Persistence.Interfaces;

namespace TA.Domain.Services
{
    public class AbonnementService(IAbonnementRepository abonnementRepository, IKlantRepository klantRepository, IStationRepository stationRepository) : IAbonnementService
    {
        public async Task<AbonnementResponseContract> CreateAbonnement(AbonnementRequestContract abonnementRequestContract)
        {
            var createdAbonnement = await abonnementRepository.CreateAbonnement(abonnementRequestContract.AsModel().AsEntity());
            return createdAbonnement.AsModel().AsContract(klantRepository, stationRepository);
        }

        public async Task DeleteAbonnement(int id)
        {
            await abonnementRepository.DeleteAbonnement(id);
        }

        public async Task<AbonnementResponseContract> GetAbonnement(int id)
        {
            var foundAbonnement = await abonnementRepository.GetAbonnement(id);
            return foundAbonnement.AsModel().AsContract(klantRepository, stationRepository);
        }

        public async Task<IEnumerable<AbonnementResponseContract>> GetAllAbonnements()
        {
            var foundAbonnements = await abonnementRepository.GetAllAbonnements();
            return foundAbonnements.Select(abonnement => abonnement.AsModel().AsContract(klantRepository, stationRepository));
        }

        //public AbonnementResponseContract UpdateAbonnement(AbonnementRequestContract abonnementRequestContract, int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
