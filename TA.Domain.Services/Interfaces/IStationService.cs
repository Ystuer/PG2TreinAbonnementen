using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;

namespace TA.Domain.Services.Interfaces
{
    public interface IStationService
    {
        Task<StationResponseContract> CreateStation(StationRequestContract stationRequestContract);
        Task<StationResponseContract> GetStation(int id);
        Task<IEnumerable<StationResponseContract>> GetAllStations();
        Task<StationResponseContract> UpdateStation(StationRequestContract stationRequestContract, int id);
        Task DeleteStation(int id);
    }
}
