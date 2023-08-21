﻿// <auto-generated />
using System;
using Cinema.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cinema.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cinema.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Director")
                        .HasColumnType("text")
                        .HasColumnName("director");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("integer")
                        .HasColumnName("duration_minutes");

                    b.Property<string>("Genre")
                        .HasColumnType("text")
                        .HasColumnName("genre");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Cinema.Models.Showtime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AvailableSeatsJson")
                        .HasColumnType("text")
                        .HasColumnName("available_seats");

                    b.Property<DateTime>("DateTimeUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datetime_utc");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid")
                        .HasColumnName("movie_id");

                    b.Property<decimal>("PriceForOneSeatUsd")
                        .HasColumnType("numeric")
                        .HasColumnName("price_for_one_seat_usd");

                    b.Property<Guid>("TheaterId")
                        .HasColumnType("uuid")
                        .HasColumnName("theater_id");

                    b.HasKey("Id");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("Cinema.Models.Theater", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("SeatingArrangementJson")
                        .HasColumnType("text")
                        .HasColumnName("seating_arrangement");

                    b.HasKey("Id");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("Cinema.Models.UserReservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("ReservationTimeUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reservation_time_utc");

                    b.Property<int[]>("ReservedPlaceNumberSeats")
                        .HasColumnType("integer[]")
                        .HasColumnName("reserved_place_number_seats");

                    b.Property<int[]>("ReservedRowNumberSeats")
                        .HasColumnType("integer[]")
                        .HasColumnName("reserved_row_number_seats");

                    b.Property<Guid>("ShowTimeId")
                        .HasColumnType("uuid")
                        .HasColumnName("show_time_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPriceUsd")
                        .HasColumnType("numeric")
                        .HasColumnName("total_price_usd");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("UserReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
