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
    internal static class KlantMappingExtensions
    {
        public static KlantModel AsModel(this KlantRequestContract klantRequestContract)
        {
            return new KlantModel
            {
                Naam = klantRequestContract.Naam,
                Voornaam = klantRequestContract.Voornaam,
                Email = klantRequestContract.Email,
            };
        }

        public static Klant AsEntity(this KlantModel klantModel)
        {
            return new Klant
            {
                Voornaam = klantModel.Voornaam,
                Naam = klantModel.Naam,
                Email = klantModel.Email
            };
        }

        public static KlantModel AsModel(this Klant klant)
        {
            return new KlantModel
            {
                Id = klant.Id,
                Voornaam = klant.Voornaam,
                Naam = klant.Naam,
                Email = klant.Email
            };
        }

        public static KlantResponseContract AsContract(this KlantModel klantModel)
        {
            return new KlantResponseContract
            {
                Id = klantModel.Id,
                Voornaam = klantModel.Voornaam,
                Naam = klantModel.Naam,
                Email = klantModel.Email
            };
        }
    }
}
