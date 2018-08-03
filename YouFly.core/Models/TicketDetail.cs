using System;
using System.Collections.Generic;
using System.Text;

namespace YouFly.core
{
    public class TicketDetail
    {
        public int ID { get; set; }
        public string TransactionIDFK { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string SeatType { get; set; }
    }
}
