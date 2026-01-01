using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Persistence.Dapper
{
    public class Station
    {
        public int Id { get; set; }

        public string Naam { get; set; } = null!;

        public bool VerwarmdeWachtruimte { get; set; }
    }
}
