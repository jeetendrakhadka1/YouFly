using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YouFly.core.Models;
using YouFly.core.Tools;

namespace YouFly.web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AirlineContext _context;

        public FlightsController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Flights.Include(Airport => Airport.AirportStart).Include(Airport => Airport.AirportEnd).ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }
            
            var flight = await _context.Flights
                .SingleOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            
            
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,AirportStart,AirportEnd,FlightDate,FlightTime,NumFCSeats,FCSeatPrice,NumBusSeats,BusSeatPrice")] Flight flight, string AirportStart, string AirportEnd)
        {
            if (ModelState.IsValid)
            {              
                
                var startAirport = _context.Airports.First(m => m.IATA == AirportStart);
                var stopAirport = _context.Airports.First(m => m.IATA == AirportEnd);
                double latStart = startAirport.Latitude;
                double lonStart = startAirport.Longitude;
                double latEnd = stopAirport.Latitude;
                double lonEnd = stopAirport.Longitude;
                flight.TravelDistance = GeoDistance.Calculate(latStart, lonStart, latEnd, lonEnd, 'M');

                flight.AirportStart = startAirport;
                flight.AirportEnd = stopAirport;
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.Message = "Flight Added!";
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.SingleOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,AirportStart,AirportEnd,FlightDate,FlightTime,NumFCSeats,FCSeatPrice,NumBusSeats,BusSeatPrice")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.Include(Airport => Airport.AirportStart).Include(Airport => Airport.AirportEnd)
                .SingleOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.SingleOrDefaultAsync(m => m.FlightId == id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }

        //public class Dropdown
        //{
        //    private readonly List<Airport> IATAList;

        //    public int AirportID { get; set; }

        //    public IEnumerable<SelectListItem> AirportItems
        //    {
        //        get { return new SelectList(IATAList, "Id", "IATA"); }
        //    }


        //}
        //public class MyModel
        //{
        //    public int Id { get; set; }
        //    public string IATA { get; set; }
        //    public List<Airport> AirportsListFromModel { get; set; }
        //}
    }
}
