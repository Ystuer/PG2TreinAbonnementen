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
using TA.Persistence.Entities;
using TA.Persistence.Interfaces;

namespace TA.Domain.Services
{
    public class StationService(IStationRepository stationRepository) : IStationService
    {
        public StationResponseContract CreateStation(StationRequestContract stationRequestContract)
        {
            Station newStation = stationRequestContract.AsModel().AsEntity();
            stationRepository.CreateStation(newStation);
            return newStation.AsModel().AsContract();
        }

        public void DeleteStation(int id)
        {
            stationRepository.DeleteStation(id);
        }

        public IEnumerable<StationResponseContract> GetAllStations()
        {
            return stationRepository.GetAllStations().Select(s => s.AsModel().AsContract());
        }

        public StationResponseContract GetStation(int id)
        {
            return stationRepository.GetStation(id).AsModel().AsContract();
        }

        public StationResponseContract UpdateStation(StationRequestContract stationRequestContract, int id)
        {
            return stationRepository.UpdateStation(stationRequestContract.AsModel().AsEntity(), id).AsModel().AsContract();
        }
    }
}
