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
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        private readonly AirlineContext _context;

        public FlightsController(AirlineContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<object> GetFlights()
        {
            var flights = await _context.Flights
                .Include(Airport => Airport.AirportStart)
                .Include(Airport => Airport.AirportEnd)
                .ToListAsync();

            return flights;
            // return _context.Flights;
        }

        // GET: api/Flights/routes?startCity=Miami&endCity=Boston
        [HttpGet("routes")]
        public async Task<object> GetFlightsByCity(string startCity, string endCity)
        {
            var flights = await _context.Flights
                    .Include(Airport => Airport.AirportStart).Where(m => m.AirportStart.City == startCity)
                    .Include(Airport => Airport.AirportEnd).Where(m => m.AirportEnd.City == endCity)
                    .ToListAsync();

            return flights;
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flight = await _context.Flights.SingleOrDefaultAsync(m => m.FlightId == id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        //// PUT: api/Flights/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFlight([FromRoute] int id, [FromBody] Flight flight)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != flight.FlightId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(flight).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FlightExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Flights
        //[HttpPost]
        //public async Task<IActionResult> PostFlight([FromBody] Flight flight)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Flights.Add(flight);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFlight", new { id = flight.FlightId }, flight);
        //}

        //// DELETE: api/Flights/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFlight([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var flight = await _context.Flights.SingleOrDefaultAsync(m => m.FlightId == id);
        //    if (flight == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Flights.Remove(flight);
        //    await _context.SaveChangesAsync();

        //    return Ok(flight);
        //}

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }
    }
}
