using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Persistence.Entities;
using TA.Persistence.Exceptions;
using TA.Persistence.Interfaces;

namespace TA.Persistence
{
    public class StationRepository(TreinabonnementContext _dbContext) : IStationRepository 
    {
        public Station CreateStation(Station station)
        {
            _dbContext.Stations.Add(station);
            _dbContext.SaveChanges();
            return station;
        }

        public void DeleteStation(int id)
        {
            var existingStation = _dbContext.Stations.Find(id);
            if (existingStation == null) { throw new StationNotFoundException(); }
            _dbContext.Stations.Remove(existingStation);
        }

        public IEnumerable<Station> GetAllStations()
        {
            return _dbContext.Stations.ToList();
        }

        public Station GetStation(int id)
        {
            return _dbContext.Stations.Find(id) ?? throw new StationNotFoundException(id);
        }

        public Station UpdateStation(Station station, int id)
        {
            var existingStation = _dbContext.Stations.Find(id);
            if (existingStation == null) { throw new StationNotFoundException(id); }
            
            existingStation.Naam = station.Naam;
            existingStation.VerwarmdeWachtruimte = station.VerwarmdeWachtruimte;
            _dbContext.SaveChanges();

            return existingStation;
        }
    }
}
