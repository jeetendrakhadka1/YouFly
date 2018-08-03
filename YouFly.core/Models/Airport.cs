using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouFly.core.Models
{
    public class Airport
    {
        // Fields to map {ID,AirportName,City,Country,IATA,ICAO,Latitude,Longitude,Altitude:int,UTC:int,DST:char,TimeZone:string,Type:string,Source:string}
        public int Id { get; set; }
        public string AirportName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public int UTC { get; set; }
        public string DST { get; set; }
        public string TimeZone { get; set; }
        public string Type { get; set; }
        public string Source{ get; set; }

        public List<Flight> StartFlights { get; set; }
        public List<Flight> EndFlights { get; set; }
        
    }
}
