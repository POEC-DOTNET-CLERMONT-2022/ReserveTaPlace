﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveTaPlace.Data.ApplicationContext;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    [DbContext(typeof(ReserveTaPlaceContext))]
    [Migration("20220215212100_UserPasswordType")]
    partial class UserPasswordType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GenreEntityMovieEntity", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("MovieGenres", (string)null);
                });

            modelBuilder.Entity("MovieEntityOriginEntity", b =>
                {
                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OriginsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MoviesId", "OriginsId");

                    b.HasIndex("OriginsId");

                    b.ToTable("MovieOrigins", (string)null);
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address1")
                        .HasColumnOrder(2);

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address2")
                        .HasColumnOrder(3);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("City")
                        .HasColumnOrder(5);

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("County")
                        .HasColumnOrder(8);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Number")
                        .HasColumnOrder(7);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("PostalCode")
                        .HasColumnOrder(6);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Street")
                        .HasColumnOrder(4);

                    b.Property<Guid>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TheaterId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.CalendarEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Calendar");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid?>("DicountTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndValidityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("Number");

                    b.Property<short?>("Rate")
                        .HasColumnType("smallint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DicountTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("DiscountType");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.FormatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Format");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.GenreEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.MediaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.MovieEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Actors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CastEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CastStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Genre");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ImdbId");

                    b.Property<bool>("IsMovieOnDisplay")
                        .HasColumnType("bit");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Released")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Released");

                    b.Property<string>("Runtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Runtime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.OriginEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Country");

                    b.HasKey("Id");

                    b.ToTable("Origin");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("Name");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Number");

                    b.Property<Guid>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormatId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.ScheduleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("HourEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HourStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SeatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Number");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Row");

                    b.HasKey("Id");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CalendarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TheaterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("sessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SeatId");

                    b.HasIndex("sessionId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Email")
                        .HasColumnOrder(4);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("FirstName")
                        .HasColumnOrder(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("LastName")
                        .HasColumnOrder(3);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("RoomEntitySeatEntity", b =>
                {
                    b.Property<Guid>("RoomsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomsId", "SeatsId");

                    b.HasIndex("SeatsId");

                    b.ToTable("RoomSeats", (string)null);
                });

            modelBuilder.Entity("ScheduleEntitySeatEntity", b =>
                {
                    b.Property<Guid>("SchedulesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SchedulesId", "SeatsId");

                    b.HasIndex("SeatsId");

                    b.ToTable("ScheduleSeats", (string)null);
                });

            modelBuilder.Entity("ScheduleEntitySessionEntity", b =>
                {
                    b.Property<Guid>("SchedulesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SchedulesId", "SessionsId");

                    b.HasIndex("SessionsId");

                    b.ToTable("SessionSchedule", (string)null);
                });

            modelBuilder.Entity("TheaterEntityUserEntity", b =>
                {
                    b.Property<Guid>("TheatersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TheatersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserTheaters", (string)null);
                });

            modelBuilder.Entity("GenreEntityMovieEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.GenreEntity", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieEntityOriginEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.OriginEntity", null)
                        .WithMany()
                        .HasForeignKey("OriginsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.AddressEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.TheaterEntity", "Theater")
                        .WithOne("Address")
                        .HasForeignKey("ReserveTaPlace.Entities.AddressEntity", "TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.DiscountType", "DiscountType")
                        .WithMany()
                        .HasForeignKey("DicountTypeId");

                    b.HasOne("ReserveTaPlace.Entities.UserEntity", "User")
                        .WithMany("Discounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscountType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.MediaEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.MovieEntity", "Movie")
                        .WithMany("Medias")
                        .HasForeignKey("MovieId");

                    b.HasOne("ReserveTaPlace.Entities.TheaterEntity", "Theater")
                        .WithMany("Medias")
                        .HasForeignKey("TheaterId");

                    b.Navigation("Movie");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.OrderEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoomEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.FormatEntity", "Format")
                        .WithMany()
                        .HasForeignKey("FormatId");

                    b.HasOne("ReserveTaPlace.Entities.TheaterEntity", "Theater")
                        .WithMany("Rooms")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Format");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.CalendarEntity", "Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId");

                    b.HasOne("ReserveTaPlace.Entities.MovieEntity", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("ReserveTaPlace.Entities.RoomEntity", "Room")
                        .WithMany("Sessions")
                        .HasForeignKey("RoomId");

                    b.Navigation("Calendar");

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TicketEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.OrderEntity", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderId");

                    b.HasOne("ReserveTaPlace.Entities.ScheduleEntity", "Schedule")
                        .WithMany("Tickets")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("ReserveTaPlace.Entities.SeatEntity", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId");

                    b.HasOne("ReserveTaPlace.Entities.SessionEntity", "Session")
                        .WithMany()
                        .HasForeignKey("sessionId");

                    b.Navigation("Order");

                    b.Navigation("Schedule");

                    b.Navigation("Seat");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomEntitySeatEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.RoomEntity", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.SeatEntity", null)
                        .WithMany()
                        .HasForeignKey("SeatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleEntitySeatEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.ScheduleEntity", null)
                        .WithMany()
                        .HasForeignKey("SchedulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.SeatEntity", null)
                        .WithMany()
                        .HasForeignKey("SeatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleEntitySessionEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.ScheduleEntity", null)
                        .WithMany()
                        .HasForeignKey("SchedulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.SessionEntity", null)
                        .WithMany()
                        .HasForeignKey("SessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheaterEntityUserEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.TheaterEntity", null)
                        .WithMany()
                        .HasForeignKey("TheatersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.MovieEntity", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.OrderEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoomEntity", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.ScheduleEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TheaterEntity", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Medias");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.UserEntity", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
