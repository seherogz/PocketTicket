using Microsoft.AspNetCore.Mvc;
using PocketTicket.Data.Services;
using PocketTicket.Models;

namespace PocketTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IPassengersService _passengersService;

        public PassengersController(IPassengersService passengersService)
        {
            _passengersService = passengersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetAllPassengers()
        {
            var passengers = await _passengersService.GetAllAsync();
            return Ok(passengers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(int id)
        {
            var passenger = await _passengersService.GetByIdAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger);
        }

        [HttpPost]
        public async Task<ActionResult<Passenger>> CreatePassenger(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                await _passengersService.AddAsync(passenger);
                return CreatedAtAction(nameof(GetPassenger), new { id = passenger.Id }, passenger);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassenger(int id, Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return BadRequest("Passenger ID mismatch");
            }

            if (ModelState.IsValid)
            {
                var existingPassenger = await _passengersService.GetByIdAsync(id);
                if (existingPassenger == null)
                {
                    return NotFound();
                }

                await _passengersService.UpdateAsync(passenger);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var passenger = await _passengersService.GetByIdAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            await _passengersService.DeleteAsync(passenger);
            return NoContent();
        }
    }
}

