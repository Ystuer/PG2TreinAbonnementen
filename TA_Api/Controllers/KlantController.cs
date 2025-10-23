using Microsoft.AspNetCore.Mvc;
using System.Net;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Services.Interfaces;
using TA.Persistence.Exceptions;

namespace TA.Api.Controllers
{
    [ApiController]
    [Route("klanten")]
    public class KlantController(IKlantService klantService) : Controller
    {
        [HttpPost]
        public ActionResult<KlantResponseContract> CreateKlant([FromBody] KlantRequestContract klantRequestContract)
        {
            var createdKlant = klantService.CreateKlant(klantRequestContract);
            return CreatedAtAction(nameof(GetKlant), new { createdKlant.Id }, createdKlant);
        }

        [HttpGet("{id}")]
        public ActionResult<KlantResponseContract> GetKlant([FromRoute] int id)
        {
            var foundKlant = klantService.GetKlant(id);
            if(foundKlant is null) return NotFound();
            return Ok(foundKlant);
        }

        [HttpGet]
        public IActionResult GetKlanten()
        {
            return Ok(klantService.GetAllKlanten());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKlant([FromRoute] int id)
        {
            try
            {
                klantService.DeleteKlant(id);
            }
            catch(EntityNotFoundException enfe)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = enfe.Message
                });
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<KlantResponseContract> UpdateKlant([FromBody] KlantRequestContract klantRequestContract, [FromRoute] int id)
        {
            var updatedKlant = klantService.UpdateKlant(klantRequestContract, id);
            if (updatedKlant is null) return NotFound();
            return updatedKlant;
        }
    }
}
