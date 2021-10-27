using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrippiBL;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripInvitesController : Controller
    {
        private IBL _bl;
        public TripInvitesController(IBL bl)
        {
            _bl = bl;
        }

        // POST: TripInvitesController/Create
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TripInvites newInvite)
        {
            TripInvites addedInvite = await _bl.PostInviteAsync(newInvite);
            return Created("api/[controller]", addedInvite);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TripInvites> foundInvites = await _bl.GetAllTripInvitesAsync();
            if (foundInvites.Count != 0)
            {
                return Ok(foundInvites);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
