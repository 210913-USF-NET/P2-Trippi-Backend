using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using TrippiBL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IBL _bl; 
        public UserController(IBL bl)
        {
            _bl = bl;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User newUser)
        {
            User addedUser = await _bl.CreateUserAsync(newUser);
            return Created("api/[controller]", addedUser);
        }

        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] Friends newFriend)
        {
            Friends addedFriend = await _bl.AddFriendAsync(newFriend);
            return Created("api/[controller]", addedFriend);
        }*/

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> foundUsers = await _bl.GetAllUsersAsync();
            if (foundUsers.Count != 0)
            {
                return Ok(foundUsers);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User foundUser = await _bl.GetOneUserByIdAsync(id);
            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
            }// GET api/<UserController>/5
        [HttpGet("Username/{username}")]
        public async Task<IActionResult> Get(string username)
            {
            User foundUser = await _bl.GetOneUserByUsernameAsync(username);
            if (foundUser != null)
                {
                return Ok(foundUser);
                }
            else
                {
                return NoContent();
                }
            }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteUserAsync(id);
        }


    }
}
