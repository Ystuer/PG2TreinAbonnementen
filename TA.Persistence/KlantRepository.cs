using Dapper;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using TA.Persistence.Entities;
using TA.Persistence.Exceptions;
using TA.Persistence.Interfaces;

namespace TA.Persistence
{
    public class KlantRepository() : IKlantRepository
    {
        public string ConnectionString = "server=127.0.0.1;port=3306;database=treinabonnement;user=tauser;password=tauser";

        public async Task<Klant> CreateKlant(Klant klant)
        {
            const string query = @"Insert into treinabonnement.klant (naam, voornaam, email) Values (@Naam, @Voornaam, @Email); Select LAST_INSERT_ID();";
            var connection = new MySqlConnection(ConnectionString);
            var id = await connection.ExecuteScalarAsync<int>(query, klant);
            return await GetKlant(id) ?? throw new KlantNotFoundException(id);
        }

        public async Task DeleteKlant(int id)
        {
            const string query = "Delete from treinabonnement.klant where id = @Id";
            var connection = new MySqlConnection(ConnectionString);
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Klant>> GetAllKlanten()
        {
            const string query = "Select * from treinabonnement.klant";
            var connection = new MySqlConnection(ConnectionString);
            var result = await connection.QueryAsync<Klant>(query);
            return result;
        }

        public async Task<Klant> GetKlant(int id)
        {
            const string query = "Select * from treinabonnement.klant where id = @Id";
            var connection = new MySqlConnection(ConnectionString);
            var result = await connection.QuerySingleOrDefaultAsync<Klant>(query, new { Id = id });
            return result ?? throw new KlantNotFoundException(id);
        }

        public async Task<Klant> UpdateKlant(Klant klant, int id)
        {
            const string query = @"Update treinabonnement.klant Set naam = @Naam, voornaam = @Voornaam, email = @Email Where id = @Id";
            var connection = new MySqlConnection(ConnectionString);
            var result = await connection.ExecuteAsync(query, new { klant.Naam, klant.Voornaam, klant.Email, Id = id });
            return await GetKlant(id) ?? throw new KlantNotFoundException(id);
        }
    }
}
