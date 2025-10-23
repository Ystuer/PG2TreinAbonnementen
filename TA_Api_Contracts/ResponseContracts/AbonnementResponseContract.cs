﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Api.Contracts.ResponseContracts
{
    public record AbonnementResponseContract
    {
        public int Id { get; set; }
        public string Klant { get; set; }
        public string VertrekStation { get; set; }
        public string AankomstStation { get; set; }
        public DateOnly Startdatum { get; set; }
        public DateOnly Einddatum { get; set; }
        public string Klasse { get; set; }
    }
}
