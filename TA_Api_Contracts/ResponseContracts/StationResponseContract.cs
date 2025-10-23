using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Api.Contracts.ResponseContracts
{
    public record StationResponseContract
    {
        public int Id { get; set; }
        public required string Naam { get; set; }
        public bool VerwarmdeWachtruimte { get; set; }
    }
}
