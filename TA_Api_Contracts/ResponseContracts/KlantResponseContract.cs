﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Api.Contracts.ResponseContracts
{
    public record KlantResponseContract
    {
        public int Id { get; set; }
        public required string Voornaam { get; set; }
        public required string Naam { get; set; }
        public required string Email { get; set; }
    }
}
