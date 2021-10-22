using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrippiBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private IBL _bl;
        public RouteController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<RouteController>
        [HttpGet("{latitude} {longitude} {distance}")]
        public async Task<IActionResult> Get(decimal latitude, decimal longitude, int distance)
        {
            List<List<Decimal>> NSEW = _bl.GetNSEW(latitude, longitude, distance);
            return Ok(NSEW);
        }

        // GET api/<RouteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RouteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RouteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RouteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
