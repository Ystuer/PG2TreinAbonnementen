using Microsoft.EntityFrameworkCore;
using TA.Persistence.Entities;
using TA.Persistence.Exceptions;
using TA.Persistence.Interfaces;

namespace TA.Persistence
{
    public class KlantRepository(TreinabonnementContext _dbContext) : IKlantRepository
    {
        public async Task<Klant> CreateKlant(Klant klant)
        {
            _dbContext.Klants.Add(klant);
            await _dbContext.SaveChangesAsync();
            return klant;
        }

        public async Task DeleteKlant(int id)
        {
            var existing = await _dbContext.Klants.FindAsync(id);
            if (existing == null) { throw new KlantNotFoundException(id); };
            _dbContext.Klants.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Klant>> GetAllKlanten()
        {
            return await _dbContext.Klants.ToListAsync();
        }

        public async Task<Klant> GetKlant(int id)
        {
            return await _dbContext.Klants.FindAsync(id) ?? throw new KlantNotFoundException(id);
        }

        public async Task<Klant> UpdateKlant(Klant klant, int id)
        {
            var existing = await _dbContext.Klants.FindAsync(id);
            if (existing == null) { throw new KlantNotFoundException(id); };

            existing.Naam = klant.Naam;
            existing.Voornaam = klant.Voornaam;
            existing.Email = klant.Email;

            await _dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
