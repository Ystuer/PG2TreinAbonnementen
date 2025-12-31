using Microsoft.AspNetCore.Mvc;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Services.Interfaces;

namespace TA.Api.Controllers
{
    [ApiController]
    [Route("abonnementen")]
    public class AbonnementController(IAbonnementService abonnementService) : Controller
    {
        [HttpPost]
        public async Task<ActionResult<AbonnementResponseContract>> CreateAbonnement(AbonnementRequestContract abonnementRequestContract)
        {
            var createdAbonnement = await abonnementService.CreateAbonnement(abonnementRequestContract);
            return CreatedAtAction(nameof(GetAbonnement), new { createdAbonnement.Id }, createdAbonnement);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbonnementResponseContract>> GetAbonnement(int id)
        {
            var foundAbonnement = await abonnementService.GetAbonnement(id);
            if (foundAbonnement is null) return NotFound();
            return Ok(foundAbonnement);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbonnementResponseContract>>> GetAllAbonnements()
        {
            var abonnementen = await abonnementService.GetAllAbonnements();
            return Ok(abonnementen);
        }
    }
}
