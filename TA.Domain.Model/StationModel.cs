﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Domain.Model
{
    public class StationModel
    {
        public int Id { get; set; }
        public required string Naam { get; set; }
        public bool VerwarmdeWachtruimte { get; set; }
    }
}
