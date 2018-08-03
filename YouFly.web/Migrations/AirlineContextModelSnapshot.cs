using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using YouFly.core.Models;

namespace YouFly.web.Migrations
{
    [DbContext(typeof(AirlineContext))]
    partial class AirlineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YouFly.core.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AirportName");

                    b.Property<int>("Altitude");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("DST");

                    b.Property<string>("IATA");

                    b.Property<string>("ICAO");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Source");

                    b.Property<string>("TimeZone");

                    b.Property<string>("Type");

                    b.Property<int>("UTC");

                    b.HasKey("Id");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("YouFly.core.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AirportEndId");

                    b.Property<int?>("AirportStartId");

                    b.Property<int>("BusSeatPrice");

                    b.Property<int>("FCSeatPrice");

                    b.Property<DateTime>("FlightDate");

                    b.Property<DateTime>("FlightTime");

                    b.Property<int>("NumBusSeats");

                    b.Property<int>("NumFCSeats");

                    b.Property<double>("TravelDistance");

                    b.HasKey("FlightId");

                    b.HasIndex("AirportEndId");

                    b.HasIndex("AirportStartId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("YouFly.core.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlightId");

                    b.Property<float>("Price");

                    b.Property<string>("SeatClass");

                    b.Property<int>("TransactionId");

                    b.HasKey("TicketId");

                    b.HasIndex("FlightId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("YouFly.core.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CCExp");

                    b.Property<int>("CCNumber");

                    b.Property<int>("ConfimationNum");

                    b.Property<int>("TotalPrice");

                    b.Property<int>("UserId");

                    b.HasKey("TransactionId");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("YouFly.core.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("YouFly.core.TicketDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("SeatType");

                    b.Property<string>("TransactionIDFK");

                    b.HasKey("ID");

                    b.ToTable("TicketDetails");
                });

            modelBuilder.Entity("YouFly.core.Models.Flight", b =>
                {
                    b.HasOne("YouFly.core.Models.Airport", "AirportEnd")
                        .WithMany("EndFlights")
                        .HasForeignKey("AirportEndId");

                    b.HasOne("YouFly.core.Models.Airport", "AirportStart")
                        .WithMany("StartFlights")
                        .HasForeignKey("AirportStartId");
                });

            modelBuilder.Entity("YouFly.core.Models.Ticket", b =>
                {
                    b.HasOne("YouFly.core.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YouFly.core.Models.Transaction", "Transaction")
                        .WithMany("Tickets")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouFly.core.Models.Transaction", b =>
                {
                    b.HasOne("YouFly.core.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
