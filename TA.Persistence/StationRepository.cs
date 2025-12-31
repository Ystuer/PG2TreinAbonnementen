using Microsoft.EntityFrameworkCore;
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
        public async Task<Station> CreateStation(Station station)
        {
            _dbContext.Stations.Add(station);
            await _dbContext.SaveChangesAsync();
            return station;
        }

        public async Task DeleteStation(int id)
        {
            var existingStation = await _dbContext.Stations.FindAsync(id);
            if (existingStation == null) { throw new StationNotFoundException(); }
            _dbContext.Stations.Remove(existingStation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            return await _dbContext.Stations.ToListAsync();
        }

        public async Task<Station> GetStation(int id)
        {
            return await _dbContext.Stations.FindAsync(id) ?? throw new StationNotFoundException(id);
        }

        public async Task<Station> UpdateStation(Station station, int id)
        {
            var existingStation = await _dbContext.Stations.FindAsync(id);
            if (existingStation == null) { throw new StationNotFoundException(id); }
            
            existingStation.Naam = station.Naam;
            existingStation.VerwarmdeWachtruimte = station.VerwarmdeWachtruimte;
            await _dbContext.SaveChangesAsync();

            return existingStation;
        }
    }
}
