using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using TrippiBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private IBL _bl;
        public TripController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Trip> foundTrips = await _bl.GetAllTripsAsync();
            if(foundTrips.Count > 0)
            {
                return Ok(foundTrips);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Trip foundTrip = await _bl.GetTripAsync(id);
            if(foundTrip != null)
            {
                return Ok(foundTrip);
            }
            else
            {
                return NoContent();
            }
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Trip newTrip)
        {
            Trip addedTrip = await _bl.CreateTripAsync(newTrip);
            return Created("api/[controller]", addedTrip);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteTripAsync(id);
        }
    }
}
