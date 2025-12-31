using Microsoft.AspNetCore.Mvc;
using System.Net;
using TA.Api.Contracts.RequestContracts;
using TA.Api.Contracts.ResponseContracts;
using TA.Domain.Services.Interfaces;
using TA.Persistence.Exceptions;

namespace TA.Api.Controllers
{
    [ApiController]
    [Route("Stations")]
    public class StationController(IStationService stationService) : Controller
    {
        [HttpPost]
        public async Task<ActionResult<StationResponseContract>> CreateStation([FromBody] StationRequestContract stationRequestContract)
        {
            StationResponseContract newStation = await stationService.CreateStation(stationRequestContract);
            return CreatedAtAction(nameof(GetStation), new { newStation.Id }, newStation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StationResponseContract>> GetStation(int id)
        {
            StationResponseContract foundStation = await stationService.GetStation(id);
            if (foundStation is null) return NotFound();
            return Ok(foundStation);
        }

        [HttpGet]
        public async Task<ActionResult<List<StationResponseContract>>> GetAllStations()
        {
            return Ok(await stationService.GetAllStations());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStation(int id)
        {
            try
            {
                await stationService.DeleteStation(id);
            }
            catch (StationNotFoundException snfe)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = snfe.Message
                }
                );
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StationResponseContract>> UpdateStation([FromBody] StationRequestContract stationRequestContract, [FromRoute] int id)
        {
            var updatedStation = await stationService.UpdateStation(stationRequestContract, id);
            if (updatedStation is null) return NotFound();
            return Ok(updatedStation);
        }
    }
}
