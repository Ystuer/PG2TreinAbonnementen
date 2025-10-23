using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Model;
using TA.Domain.Services.Interfaces;
using TA.Domain.Services.MappingExtensions;
using TA.Persistence.Interfaces;

namespace TA.Domain.Services
{
    public class AbonnementService(IAbonnementRepository abonnementRepository, IKlantRepository klantRepository, IStationRepository stationRepository) : IAbonnementService
    {
        public AbonnementResponseContract CreateAbonnement(AbonnementRequestContract abonnementRequestContract)
        {
            var createdAbonnement = abonnementRepository.CreateAbonnement(abonnementRequestContract.AsModel().AsEntity());
            return createdAbonnement.AsModel().AsContract(klantRepository, stationRepository);
        }

        public void DeleteAbonnement(int id)
        {
            throw new NotImplementedException();
        }

        public AbonnementResponseContract GetAbonnement(int id)
        {
            return abonnementRepository.GetAbonnement(id).AsModel().AsContract(klantRepository, stationRepository);
        }

        public IEnumerable<AbonnementResponseContract> GetAllAbonnements()
        {
            throw new NotImplementedException();
        }

        //public AbonnementResponseContract UpdateAbonnement(AbonnementRequestContract abonnementRequestContract, int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
