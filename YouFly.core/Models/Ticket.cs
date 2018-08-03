using System;
using System.Collections.Generic;
using System.Text;

namespace YouFly.core.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string SeatClass { get; set; }
        public float Price { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
