using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Api.Contracts.RequestContracts
{
    public class AbonnementRequestContract
    {
        public required int KlantId { get; set; }
        public required int VertrekStationId { get; set; }
        public required int AankomstStationId { get; set; }
        public required DateTime Startdatum { get; set; }
        public required DateTime Einddatum { get; set; }
        public required string Klasse { get; set; }
    }
}
