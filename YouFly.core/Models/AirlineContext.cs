using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YouFly.core.Models
{
    public class AirlineContext : DbContext
    {
        //public AirlineContext()
        //{
        //}

        public AirlineContext(DbContextOptions<AirlineContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDetail> TicketDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.AirportStart)
                .WithMany(a => a.StartFlights);
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.AirportEnd)
                .WithMany(a => a.EndFlights);
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions);
            modelBuilder.Entity<Ticket>()
                .HasOne(k => k.Transaction)
                .WithMany(t => t.Tickets);
            modelBuilder.Entity<Ticket>()
                .HasOne(k => k.Flight)
                .WithMany(f => f.Tickets);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Airport>().ToTable("Airport");
            modelBuilder.Entity<Flight>().ToTable("Flight");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");

        }
    }
}
