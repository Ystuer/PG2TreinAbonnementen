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
        StationResponseContract CreateStation(StationRequestContract stationRequestContract);
        StationResponseContract GetStation(int id);
        IEnumerable<StationResponseContract> GetAllStations();
        StationResponseContract UpdateStation(StationRequestContract stationRequestContract, int id);
        void DeleteStation(int id);
    }
}
