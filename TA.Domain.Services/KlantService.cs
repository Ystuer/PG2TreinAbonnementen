using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Model;
using TA.Domain.Services.Interfaces;
using TA.Domain.Services.MappingExtensions;
using TA.Persistence.Entities;
using TA.Persistence.Interfaces;

namespace TA.Domain.Services
{
    public class KlantService(IKlantRepository klantRepository) : IKlantService
    {
        public KlantResponseContract CreateKlant(KlantRequestContract klantRequestContract)
        {
            Klant newKlant = klantRequestContract.AsModel().AsEntity();
            klantRepository.CreateKlant(newKlant);
            return newKlant.AsModel().AsContract();
        }

        public void DeleteKlant(int id)
        {
            klantRepository.DeleteKlant(id);
        }

        public IEnumerable<KlantResponseContract> GetAllKlanten()
        {
            return klantRepository.GetAllKlanten().Select(k => k.AsModel().AsContract());
        }

        public KlantResponseContract? GetKlant(int id)
        {
            return klantRepository.GetKlant(id).AsModel().AsContract();
        }

        public KlantResponseContract? UpdateKlant(KlantRequestContract klantRequestContract, int id)
        {
            var updateKlant = klantRequestContract.AsModel().AsEntity();
            klantRepository.UpdateKlant(updateKlant, id);
            return updateKlant.AsModel().AsContract();
        }
    }
}
