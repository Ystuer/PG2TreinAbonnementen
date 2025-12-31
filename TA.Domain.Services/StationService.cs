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
        public async Task<StationResponseContract> CreateStation(StationRequestContract stationRequestContract)
        {
            Station newStation = stationRequestContract.AsModel().AsEntity();
            await stationRepository.CreateStation(newStation);
            return newStation.AsModel().AsContract();
        }

        public async Task DeleteStation(int id)
        {
            await stationRepository.DeleteStation(id);
        }

        public async Task<IEnumerable<StationResponseContract>> GetAllStations()
        {
            var foundStations = await stationRepository.GetAllStations();
            return foundStations.Select(s => s.AsModel().AsContract());
        }

        public async Task<StationResponseContract> GetStation(int id)
        {
            var foundStation = await stationRepository.GetStation(id);
            return foundStation.AsModel().AsContract();
        }

        public async Task<StationResponseContract> UpdateStation(StationRequestContract stationRequestContract, int id)
        {
            var updatedStation = await stationRepository.UpdateStation(stationRequestContract.AsModel().AsEntity(), id);
            return updatedStation.AsModel().AsContract();
        }
    }
}
