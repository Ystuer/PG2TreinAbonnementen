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
        public ActionResult<AbonnementResponseContract> CreateAbonnement(AbonnementRequestContract abonnementRequestContract)
        {
            var createdAbonnement = abonnementService.CreateAbonnement(abonnementRequestContract);
            return CreatedAtAction(nameof(GetAbonnement), new { createdAbonnement.Id }, createdAbonnement);
        }

        [HttpGet("{id}")]
        public ActionResult<AbonnementResponseContract> GetAbonnement(int id)
        {
            var foundAbonnement = abonnementService.GetAbonnement(id);
            if (foundAbonnement is null) return NotFound();
            return Ok(foundAbonnement);
        }
    }
}
