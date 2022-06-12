using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication1.Services;
using System.Threading.Tasks;
using Cw3.Models.DTO;
using System;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IDbService _dbService;

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            try {
                var trips = await _dbService.GetTrips();
                return Ok(trips);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveTrip(int id)
        {
            await _dbService.RemoveTrip(id);
            return Ok("removed Trip");
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddTripToClient([FromRoute] int idTrip, [FromBody] SomeSortOfRequest dto)
        {
            try
            {
                await AddTripToClient(idTrip, dto);
                return Ok("succes");
            }

            catch (Exception e)
                {
                return NotFound(e.Message);
            }
        }
    }
}
