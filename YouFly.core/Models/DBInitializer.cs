using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using CsvHelper;
using CsvHelper.TypeConversion;
using CryptoHelper;
using YouFly.core.Tools;

namespace YouFly.core.Models
{
    public static class DBInitializer
    {
        public static void Initialize(AirlineContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User{UserName="admin", Password= Crypto.HashPassword("password"), Email="admin@selu.edu", Role="admin"}
                };
                foreach (User s in users)
                {
                    context.Users.Add(s);
                }
                context.SaveChanges();
            }

            if (!context.Airports.Any())
            {
                var csv = new CsvReader((TextReader)File.OpenText("Data\\us_airports.csv"));

                try
                {
                    while (csv.Read())
                    {
                        context.Airports.Add(new Airport
                        {
                            AirportName = csv.GetField<string>("AirportName"),
                            City = csv.GetField<string>("City"),
                            Country = csv.GetField<string>("Country"),
                            IATA = csv.GetField<string>("IATA"),
                            ICAO = csv.GetField<string>("ICAO"),
                            Latitude = csv.GetField<double>(5),
                            Longitude = csv.GetField<double>(6),
                            Altitude = csv.GetField<int>(7),
                            UTC = csv.GetField<int>(8),
                            DST = csv.GetField<string>("DST"),
                            TimeZone = csv.GetField<string>("TimeZone"),
                            Type = csv.GetField<string>("Type"),
                            Source = csv.GetField<string>("Source")
                        });
                    }
                }
                catch (CsvTypeConverterException ex)
                {
                    Console.WriteLine(ex.Data.Values);
                    //ex.Data.Values has more info...
                }
                context.SaveChanges();
            }
            
            if (!context.Flights.Any())
            {
                // Fake test data...should be removed once we have data entry ready
                var flightCsv = new CsvReader((TextReader)File.OpenText("Data\\rand_flights.csv"));

                try
                {
                    while (flightCsv.Read())
                    {
                        var startAirport = context.Airports.First(m => m.IATA == flightCsv.GetField<string>(0));
                        var endAirport = context.Airports.First(m => m.IATA == flightCsv.GetField<string>(1));
                        double latStart = startAirport.Latitude;
                        double lonStart = startAirport.Longitude;
                        double latEnd = endAirport.Latitude;
                        double lonEnd = endAirport.Longitude;

                        context.Flights.Add(new Flight
                        {
                            AirportStart = startAirport,
                            AirportEnd = endAirport,
                            FlightDate = flightCsv.GetField<DateTime>(2).Date,
                            FlightTime = flightCsv.GetField<DateTime>(3),
                            TravelDistance = GeoDistance.Calculate(latStart, lonStart, latEnd, lonEnd, 'M'), // flightCsv.GetField<int>(4),
                            NumFCSeats = flightCsv.GetField<int>(4),
                            FCSeatPrice = flightCsv.GetField<int>(5),
                            NumBusSeats = flightCsv.GetField<int>(6),
                            BusSeatPrice = flightCsv.GetField<int>(7)
                        });
                    }
                }
                catch (CsvTypeConverterException ex)
                {
                    Console.WriteLine(ex.Data.Values);
                    //ex.Data.Values has more info...
                }
                context.SaveChanges();
            }
            
        }

    //    // Haversine formula to calculate distances
    //    // Lifted from this site: http://www.geodatasource.com/developers/c-sharp
    //    // "The sample code is licensed under LGPLv3"
    //    private static double distance(double lat1, double lon1, double lat2, double lon2, char unit)
    //    {
    //        double theta = lon1 - lon2;
    //        double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
    //        dist = Math.Acos(dist);
    //        dist = rad2deg(dist);
    //        dist = dist * 60 * 1.1515;
    //        if (unit == 'K')
    //        {
    //            dist = dist * 1.609344;
    //        }
    //        else if (unit == 'N')
    //        {
    //            dist = dist * 0.8684;
    //        }
    //        return (dist);
    //    }

    //    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //    //::  This function converts decimal degrees to radians             :::
    //    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //    private static double deg2rad(double deg)
    //    {
    //        return (deg * Math.PI / 180.0);
    //    }

    //    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //    //::  This function converts radians to decimal degrees             :::
    //    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //    private static double rad2deg(double rad)
    //    {
    //        return (rad / Math.PI * 180.0);
    //    }

    }
}
