using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouFly.core.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        
        public Airport AirportStart { get; set; }
        
        public Airport AirportEnd { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime FlightDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:T}")]
        public DateTime FlightTime { get; set; }

        public double TravelDistance { get; set; }
        public int NumFCSeats { get; set; }
        public int FCSeatPrice { get; set; }
        public int NumBusSeats { get; set; }
        public int BusSeatPrice { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
