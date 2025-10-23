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
        KlantResponseContract CreateKlant(KlantRequestContract klantRequestContract);
        KlantResponseContract? GetKlant(int id);
        IEnumerable<KlantResponseContract> GetAllKlanten();
        KlantResponseContract? UpdateKlant(KlantRequestContract klantRequestContract, int id);
        void DeleteKlant(int id);
    }
}
