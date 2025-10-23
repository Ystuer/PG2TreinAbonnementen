using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Model;
using TA.Persistence.Entities;

namespace TA.Domain.Services.MappingExtensions
{
    public static class StationMappingExtensions
    {
        public static StationModel AsModel(this StationRequestContract stationRequestContract)
        {
            return new StationModel
            {
                Naam = stationRequestContract.Naam,
                VerwarmdeWachtruimte = stationRequestContract.VerwarmdeWachtruimte
            };
        }

        public static Station AsEntity(this StationModel stationModel)
        {
            return new Station
            {
                Naam = stationModel.Naam,
                VerwarmdeWachtruimte = stationModel.VerwarmdeWachtruimte
            };
        }

        public static StationModel AsModel(this Station station)
        {
            return new StationModel
            {
                Id = station.Id,
                Naam = station.Naam,
                VerwarmdeWachtruimte = station.VerwarmdeWachtruimte
            };
        }

        public static StationResponseContract AsContract(this StationModel stationModel)
        {
            return new StationResponseContract
            {
                Id = stationModel.Id,
                Naam = stationModel.Naam,
                VerwarmdeWachtruimte = stationModel.VerwarmdeWachtruimte
            };
        }
    }
}
