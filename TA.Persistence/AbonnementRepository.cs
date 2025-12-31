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
    public class AbonnementRepository(TreinabonnementContext _dbContext) : IAbonnementRepository
    {
        public async Task<Abonnement> CreateAbonnement(Abonnement abonnement)
        {
            _dbContext.Abonnements.Add(abonnement);
            await _dbContext.SaveChangesAsync();
            return await GetAbonnement(abonnement.Id);
        }

        public async Task DeleteAbonnement(int id)
        {
            var existingAbonnement = await _dbContext.Abonnements.FindAsync(id);
            if (existingAbonnement is null) { throw new AbonnementNotFoundException(id); };
            _dbContext.Abonnements.Remove(existingAbonnement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Abonnement> GetAbonnement(int id)
        {
            return await _dbContext.Abonnements
                .Include(a => a.Klant)
                .Include(a => a.VertrekStation)
                .Include(a => a.AankomstStation)
                .SingleOrDefaultAsync(a => a.Id == id)
                ?? throw new AbonnementNotFoundException(id);
        }

        public async Task<IEnumerable<Abonnement>> GetAllAbonnements()
        {
            return await _dbContext.Abonnements
                .Include(a => a.Klant)
                .Include(a => a.AankomstStation)
                .Include(a => a.VertrekStation)
                .OrderByDescending(a => a.Id).
                ToListAsync();
        }

        //public Abonnement UpdateAbonnement(Abonnement abonnement, int id)
        //{
        //    var existingAbonnement = _dbContext.Abonnements.Find(id);
        //    if (existingAbonnement is null) { throw new AbonnementNotFoundException(id); };

        //    existingAbonnement.KlantId = abonnement.KlantId;
        //    existingAbonnement.AankomstStationId = abonnement.AankomstStationId;
        //    existingAbonnement.VertrekStationId = abonnement.VertrekStationId;
        //    existingAbonnement.Startdatum = abonnement.Startdatum;
        //    existingAbonnement.Einddatum = abonnement.Einddatum;
        //    existingAbonnement.Klasse = abonnement.Klasse;

        //    _dbContext.SaveChanges();

        //    return existingAbonnement;
        //}
    }
}
