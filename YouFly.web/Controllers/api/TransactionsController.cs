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
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly AirlineContext _context;

        public TransactionsController(AirlineContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions;
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await _context.Transactions.SingleOrDefaultAsync(m => m.TransactionId == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction([FromRoute] int id, [FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        [HttpPost("placeOrder")]
        public async Task<IActionResult> PostTransaction([FromBody] myTransaction transaction)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Ticket> ttickets = null;
            float subTotal = 0;

            Transaction newTransaction = new Transaction();
            newTransaction.CCExp = transaction.ccExp;
            newTransaction.CCNumber = transaction.ccNumber;
            newTransaction.ConfimationNum = 000;
            newTransaction.TotalPrice = (int) subTotal;
            newTransaction.User = _context.Users.First(m => m.ID == transaction.userid);

            _context.Transactions.Add(newTransaction);
            await _context.SaveChangesAsync();
            
            int myId = newTransaction.TransactionId;
            int myFlightId = transaction.flightid;

            if (transaction.numOfBusTks == 0)
            {
                //Do nothing
               
            }
            else
            {
                //create that number of records in the ticket table
                //for loop to add subTotal

                for (int i = 0; i < transaction.numOfBusTks; i++ )
                {
                    Ticket newTicket = new Ticket();
                    newTicket.Flight = _context.Flights.First(m => m.FlightId == myFlightId);
                    newTicket.SeatClass = "Business";
                    newTicket.Transaction = newTransaction;
                    newTicket.Price = newTicket.Flight.BusSeatPrice;
                    subTotal = subTotal + newTicket.Price;

                    _context.Tickets.Add(newTicket);
                    await _context.SaveChangesAsync();

                }
                

                // var startAirport = _context.Airports.First(m => m.IATA == AirportStart);

            }

            if (transaction.numOfFCTks == 0)
            {
                //Do nothing
            }
            else
            {
                //create the number of records in the ticket table
                ///for loop to add subtotal
                ///
                for (int i = 0; i < transaction.numOfFCTks; i++)
                {
                    Ticket newTicket = new Ticket();
                    newTicket.Flight = _context.Flights.First(m => m.FlightId == myFlightId);
                    newTicket.SeatClass = "First Class";
                    newTicket.Transaction = newTransaction;
                    newTicket.Price = newTicket.Flight.FCSeatPrice;
                    subTotal = subTotal + newTicket.Price;

                    _context.Tickets.Add(newTicket);
                    await _context.SaveChangesAsync();

                }
            }

            newTransaction.TotalPrice = (int) subTotal;
            newTransaction.ConfimationNum = newTransaction.TransactionId * 137;
            _context.Transactions.Update(newTransaction);
            await _context.SaveChangesAsync();


            CreatedAtActionResult result = CreatedAtAction("GetTransaction", new { id = newTransaction.TransactionId }, newTransaction);
            return result;
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await _context.Transactions.SingleOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }

        public class myTransaction
        {
            public int id { get; set; }
            public int ccNumber { get; set; }
            public int ccExp { get; set; }
            public int userid { get; set; }
            public int flightid { get; set; }
            public int numOfBusTks { get; set; }
            public int numOfFCTks { get; set; }
            public int total { get; set; }
        }
    }
}