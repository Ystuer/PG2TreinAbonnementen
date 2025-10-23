using TA.Persistence.Entities;
using TA.Persistence.Exceptions;
using TA.Persistence.Interfaces;

namespace TA.Persistence
{
    public class KlantRepository(TreinabonnementContext _dbContext) : IKlantRepository
    {
        public Klant CreateKlant(Klant klant)
        {
            _dbContext.Klants.Add(klant);
            _dbContext.SaveChanges();
            return klant;
        }

        public void DeleteKlant(int id)
        {
            var existing = _dbContext.Klants.Find(id);
            if (existing == null) { throw new KlantNotFoundException(id); };
            _dbContext.Klants.Remove(existing);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Klant> GetAllKlanten()
        {
            return _dbContext.Klants.ToList();
        }

        public Klant GetKlant(int id)
        {
            return _dbContext.Klants.Find(id) ?? throw new KlantNotFoundException(id);
        }

        public Klant UpdateKlant(Klant klant, int id)
        {
            var existing = _dbContext.Klants.Find(id);
            if (existing == null) { throw new KlantNotFoundException(id); };

            existing.Naam = klant.Naam;
            existing.Voornaam = klant.Voornaam;
            existing.Email = klant.Email;

            _dbContext.SaveChanges();
            return existing;
        }
    }
}
