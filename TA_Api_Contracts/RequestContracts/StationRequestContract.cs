using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Api.Contracts.RequestContracts
{
    public class StationRequestContract
    {
        [MaxLength(50)]
        public required string Naam { get; set; }
        [Required]
        public required bool VerwarmdeWachtruimte { get; set; }
    }
}
