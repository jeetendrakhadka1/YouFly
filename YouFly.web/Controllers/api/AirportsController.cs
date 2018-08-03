using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouFly.core.Models;

namespace YouFly.web.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Airports")]
    public class AirportsController : Controller
    {
        private readonly AirlineContext _context;

        public AirportsController(AirlineContext context)
        {
            _context = context;
        }

        // GET: api/Airports
        [HttpGet]
        public IEnumerable<Airport> GetAirports()
        {
            return _context.Airports;
        }

        // GET: api/Airports/5
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airport = await _context.Airports.SingleOrDefaultAsync(m => m.Id == id);

            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        //GET: api/Airports/city
        //[Route("api/Airports/City")]
       
        [HttpGet("city/{City}")]
        public IEnumerable<Airport> GetAirportByCity([FromRoute] string City)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var airport = _context.Airports.Where(m => m.City == City); //.FirstOrDefaultAsync(m => m.City == City);

            //if (airport == null)
            //{
            //    return NotFound();
            //}

            return _context.Airports.Where(m => m.City == City); //Ok(airport);
        }

        // PUT: api/Airports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport([FromRoute] int id, [FromBody] Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airport.Id)
            {
                return BadRequest();
            }

            _context.Entry(airport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(id))
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



        // POST: api/Airports
        [HttpPost]
        public async Task<IActionResult> PostAirport([FromBody] Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirport", new { id = airport.Id }, airport);
        }

        // DELETE: api/Airports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airport = await _context.Airports.SingleOrDefaultAsync(m => m.Id == id);
            if (airport == null)
            {
                return NotFound();
            }

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();

            return Ok(airport);
        }

        private bool AirportExists(int id)
        {
            return _context.Airports.Any(e => e.Id == id);
        }
    }
}