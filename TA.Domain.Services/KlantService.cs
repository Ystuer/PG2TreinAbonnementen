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
        public async Task<KlantResponseContract> CreateKlant(KlantRequestContract klantRequestContract)
        {
            Klant newKlant = klantRequestContract.AsModel().AsEntity();
            await klantRepository.CreateKlant(newKlant);
            return newKlant.AsModel().AsContract();
        }

        public async Task DeleteKlant(int id)
        {
            await klantRepository.DeleteKlant(id);
        }

        public async Task<IEnumerable<KlantResponseContract>> GetAllKlanten()
        {
            var foundKlanten = await klantRepository.GetAllKlanten();
            return foundKlanten.Select(k => k.AsModel().AsContract());
        }

        public async Task<KlantResponseContract>? GetKlant(int id)
        {
            var foundKlant = await klantRepository.GetKlant(id);
            return foundKlant.AsModel().AsContract();
        }

        public async Task<KlantResponseContract>? UpdateKlant(KlantRequestContract klantRequestContract, int id)
        {
            var updateKlant = klantRequestContract.AsModel().AsEntity();
            await klantRepository.UpdateKlant(updateKlant, id);
            return updateKlant.AsModel().AsContract();
        }
    }
}
