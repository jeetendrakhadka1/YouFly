using System;
using System.Collections.Generic;
using System.Text;

namespace YouFly.core.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CCNumber { get; set; }
        public int CCExp { get; set; }
        public int TotalPrice { get; set; }
        public int ConfimationNum { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
