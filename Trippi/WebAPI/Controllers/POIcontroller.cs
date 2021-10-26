using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrippiBL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class POIcontroller : ControllerBase
    {
        private IBL _bl; 
        public POIcontroller(IBL bl)
        {
            _bl = bl;
        }

        [HttpGet("{address} {days} {hours}")]
        public async Task<IActionResult> Get(string address, int days, int hours)
        {
            List<string> POIs = await _bl.AddressToNSEWToPOI(address, days, hours);
            return Ok(POIs);
        }
        
    }
}