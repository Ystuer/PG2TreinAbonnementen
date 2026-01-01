using Dapper;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
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
    public class StationRepository() : IStationRepository
    {
        public string ConnectionString = "server=127.0.0.1;port=3306;database=treinabonnement;user=tauser;password=tauser";

        public async Task<Station> CreateStation(Station station)
        {
            const string query = @"Insert into treinabonnement.station (naam, verwarmde_wachtruimte) Values (@naam, @verwarmdewachtruimte); Select LAST_INSERT_ID()";
            using var connection = new MySqlConnection(ConnectionString);
            var id = await connection.ExecuteScalarAsync<int>(query, station);
            return await GetStation(id) ?? throw new StationNotFoundException(id);
        }

        public async Task DeleteStation(int id)
        {
            const string query = "Delete from treinabonnement.station where id = @id";
            using var connection = new MySqlConnection(ConnectionString);
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            const string query = "Select * from treinabonnement.station";
            using var connection = new MySqlConnection(ConnectionString);
            var result = await connection.QueryAsync<Station>(query);
            return result;
        }

        public async Task<Station> GetStation(int id)
        {
            const string query = "Select * from treinabonnement.station Where id = @id";
            using var connection = new MySqlConnection(ConnectionString);
            var result = await connection.QuerySingleOrDefaultAsync<Station>(query, new { Id = id });
            return result ?? throw new StationNotFoundException(id);
        }

        public async Task<Station> UpdateStation(Station station, int id)
        {
            const string query = @"Update treinabonnement.station Set naam = @Naam, verwarmde_wachtruimte = @VerwarmdeWachtruimte Where id = @Id";
            var connection = new MySqlConnection(ConnectionString);
            await connection.ExecuteAsync(query, new {station.Naam, station.VerwarmdeWachtruimte, Id = id});
            return await GetStation(id) ?? throw new StationNotFoundException(id);
        }
    }
}
