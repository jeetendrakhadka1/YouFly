using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouFly.core.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using CryptoHelper;

namespace YouFly.web.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly AirlineContext _context;

        public UsersController(AirlineContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Users/a
        [HttpPost]
        [Route("postUsers")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {

            //return Ok(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User ObjectFromDatabase = _context.Users.FirstOrDefault(s => (s.UserName.Equals(user.UserName) || (s.Email.Equals(user.Email))));
            if (ObjectFromDatabase != null)
            {
                return BadRequest();
            }

            else
            {
                var entity = _context.Users.Add(new core.Models.User
                {
                    Email = user.Email,        
                    Password = Crypto.HashPassword(user.Password),
                    UserName = user.UserName,
                    Role = "User"

                }
                );
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = entity.Entity.ID }, new { entity.Entity.ID, entity.Entity.Email });
            }
        }

        // DELETE: api/Users/5
        [Route("delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }


        //LogIn 
        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn([FromBody] User user)
        {         
            //Check if the User is registered. 
            User CheckUser =  _context.Users.FirstOrDefault(s => s.UserName.Equals(user.UserName));
            try
            {
                if (CheckUser != null)
                {
                    bool a = Crypto.VerifyHashedPassword(CheckUser.Password, user.Password);
                    if (a == true)
                    {
                        return CreatedAtAction("GetUser", new { id = CheckUser.ID }, new { CheckUser.ID, CheckUser.UserName, CheckUser.Role });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}    
