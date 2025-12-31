using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;

namespace TA.Domain.Services.Interfaces
{
    public interface IKlantService
    {
        Task<KlantResponseContract> CreateKlant(KlantRequestContract klantRequestContract);
        Task<KlantResponseContract?> GetKlant(int id);
        Task<IEnumerable<KlantResponseContract>> GetAllKlanten();
        Task<KlantResponseContract?> UpdateKlant(KlantRequestContract klantRequestContract, int id);
        Task DeleteKlant(int id);
    }
}
