using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Api.Contracts.RequestContracts
{
    public class KlantRequestContract
    {
        [MaxLength(25)]
        public required string Voornaam { get; set; }
        [MaxLength(25)]
        public required string Naam { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
