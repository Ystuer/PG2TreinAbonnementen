using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Persistence.Dapper
{
    public class Klant
    {
        public int Id { get; set; }

        public string Voornaam { get; set; } = null!;

        public string Naam { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
