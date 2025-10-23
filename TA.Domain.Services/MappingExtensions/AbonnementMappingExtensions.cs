using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Model;
using TA.Persistence;
using TA.Persistence.Entities;
using TA.Persistence.Interfaces;

namespace TA.Domain.Services.MappingExtensions
{
    public static class AbonnementMappingExtensions
    {
        public static AbonnementModel AsModel(this AbonnementRequestContract abonnementRequestContract)
        {
            return new AbonnementModel
            {
                KlantId = abonnementRequestContract.KlantId,
                VertrekStationId = abonnementRequestContract.VertrekStationId,
                AankomstStationId = abonnementRequestContract.AankomstStationId,
                Startdatum = abonnementRequestContract.Startdatum,
                Einddatum = abonnementRequestContract.Einddatum,
                Klasse = abonnementRequestContract.Klasse
            };
        }

        public static Abonnement AsEntity(this AbonnementModel abonnementModel)
        {
            return new Abonnement
            {
                KlantId = abonnementModel.KlantId,
                VertrekStationId = abonnementModel.VertrekStationId,
                AankomstStationId = abonnementModel.AankomstStationId,
                Startdatum = abonnementModel.Startdatum,
                Einddatum = abonnementModel.Einddatum,
                Klasse = abonnementModel.Klasse
            };
        }

        public static AbonnementModel AsModel(this Abonnement abonnement)
        {
            return new AbonnementModel
            {
                Id = abonnement.Id,
                KlantId = abonnement.KlantId,
                VertrekStationId = abonnement.VertrekStationId,
                AankomstStationId = abonnement.AankomstStationId,
                Startdatum = abonnement.Startdatum,
                Einddatum = abonnement.Einddatum,
                Klasse = abonnement.Klasse
            };
        }

        public static AbonnementResponseContract AsContract(this AbonnementModel abonnementModel, IKlantRepository klantRepository, IStationRepository stationRepository)
        {
            return new AbonnementResponseContract
            {
                Id = abonnementModel.Id,
                Klant = klantRepository.GetKlant(abonnementModel.KlantId).Voornaam + " " + klantRepository.GetKlant(abonnementModel.KlantId).Naam,
                VertrekStation = stationRepository.GetStation(abonnementModel.VertrekStationId).Naam,
                AankomstStation = stationRepository.GetStation(abonnementModel.AankomstStationId).Naam,
                Startdatum = abonnementModel.Startdatum,
                Einddatum = abonnementModel.Einddatum,
                Klasse = abonnementModel.Klasse,
            };
        }
    }
}
