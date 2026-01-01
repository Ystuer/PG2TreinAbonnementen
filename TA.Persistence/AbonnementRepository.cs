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
    public class AbonnementRepository(TreinabonnementContext _dbContext) : IAbonnementRepository
    {
        public readonly string ConnectionString = "server=127.0.0.1;port=3306;database=treinabonnement;user=tauser;password=tauser";

        public async Task<Abonnement> CreateAbonnement(Abonnement abonnement)
        {
            const string query = @"Insert into treinabonnement.abonnement (klant_id, vertrek_station_id, aankomst_station_id, startdatum, einddatum, klasse) Values (@KlantId, @VertrekStationId, @AankomstStationId, @Startdatum, @Einddatum, @Klasse); Select LAST_INSERT_ID();";
            var connection = new MySqlConnection(ConnectionString);
            var id = await connection.ExecuteScalarAsync<int>(query, abonnement);
            return await GetAbonnement(id) ?? throw new AbonnementNotFoundException(id);
        }

        public async Task DeleteAbonnement(int id)
        {
            var exists = await GetAbonnement(id);

            const string query = "Delete * from treinabonnement.abonnement Where id = @Id";
            var connection = new MySqlConnection(ConnectionString);
            await connection.ExecuteAsync(query);
        }

        public async Task<Abonnement> GetAbonnement(int id)
        {
            var query = @"Select a.id, a.klant_id, a.vertrek_station_id, a.aankomst_station_id,  a.startdatum, a.einddatum, a.klasse, k.id, k.voornaam, k.naam, k.email, vs.id, vs.naam, vs.verwarmde_wachtruimte, as2.id, as2.naam, as2.verwarmde_wachtruimte
                          From treinabonnement.abonnement a
                            Inner join treinabonnement.klant k on k.id = a.klant_id
                            Inner join treinabonnement.station vs on vs.id = a.vertrek_station_id
                            Inner join treinabonnement.station as2 on as2.id = a.aankomst_station_id
                                Where a.id = @Id";
            var connection = new MySqlConnection(ConnectionString);
            var result = await connection.QueryAsync<Abonnement, Klant, Station, Station, Abonnement>(
                sql: query,
                map: (abonnement, klant, vertrekStation, aankomstStation) =>
                {
                    abonnement.KlantId = klant.Id;
                    abonnement.VertrekStationId = vertrekStation.Id;
                    abonnement.AankomstStationId = aankomstStation.Id;
                    return abonnement;
                },
                param: new { Id = id },
                splitOn: "id,id,id"
                );
            return result.FirstOrDefault() ?? throw new AbonnementNotFoundException(id);
        }

        public async Task<IEnumerable<Abonnement>> GetAllAbonnements()
        {
            var query = @"Select a.id, a.klant_id, a.vertrek_station_id, a.aankomst_station_id,  a.startdatum, a.einddatum, a.klasse, k.id, k.voornaam, k.naam, k.email, vs.id, vs.naam, vs.verwarmde_wachtruimte, as2.id, as2.naam, as2.verwarmde_wachtruimte
                          From treinabonnement.abonnement a
                            Inner join treinabonnement.klant k on k.id = a.klant_id
                            Inner join treinabonnement.station vs on vs.id = a.vertrek_station_id
                            Inner join treinabonnement.station as2 on as2.id = a.aankomst_station_id
                                Order by a.id DESC";
            var connection = new MySqlConnection(ConnectionString);
            var result = await connection.QueryAsync<Abonnement, Klant, Station, Station, Abonnement>(
                sql: query,
                map: (abonnement, klant, vertrekStation, aankomstStation) =>
                {
                    abonnement.KlantId = klant.Id;
                    abonnement.VertrekStationId = vertrekStation.Id;
                    abonnement.AankomstStationId = aankomstStation.Id;
                    return abonnement;
                },
                splitOn: "id,id,id"
                );
            return result;
        }
    }
}
