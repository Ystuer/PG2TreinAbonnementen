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
        public ActionResult<StationResponseContract> CreateStation([FromBody] StationRequestContract stationRequestContract)
        {
            StationResponseContract newStation = stationService.CreateStation(stationRequestContract);
            return CreatedAtAction(nameof(GetStation), new { newStation.Id }, newStation);
        }

        [HttpGet("{id}")]
        public ActionResult<StationResponseContract> GetStation(int id)
        {
            StationResponseContract foundStation = stationService.GetStation(id);
            if (foundStation is null) return NotFound();
            return Ok(foundStation);
        }

        [HttpGet]
        public ActionResult<List<StationResponseContract>> GetAllStations()
        {
            return Ok(stationService.GetAllStations());
        }

        [HttpDelete]
        public IActionResult DeleteStation(int id)
        {
            try
            {
                stationService.DeleteStation(id);
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
        public ActionResult<StationResponseContract> UpdateStation([FromBody] StationRequestContract stationRequestContract, [FromRoute] int id)
        {
            var updatedStation = stationService.UpdateStation(stationRequestContract, id);
            if (updatedStation is null) return NotFound();
            return Ok(updatedStation);
        }
    }
}
