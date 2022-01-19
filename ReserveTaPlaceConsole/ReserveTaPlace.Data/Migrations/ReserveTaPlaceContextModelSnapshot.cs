﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveTaPlace.Data.ApplicationContext;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    [DbContext(typeof(ReserveTaPlaceContext))]
    partial class ReserveTaPlaceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("GenreEntityMovieEntity");
                });

            modelBuilder.Entity("MovieEntityOriginEntity", b =>
                {
                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OriginsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MoviesId", "OriginsId");

                    b.HasIndex("OriginsId");

                    b.ToTable("MovieEntityOriginEntity");
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

                    b.Property<Guid?>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TheaterId")
                        .IsUnique()
                        .HasFilter("[TheaterId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiscountTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndValidityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiscountTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Rate")
                        .HasColumnType("smallint");

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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.MovieEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CastEndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastStartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMovieOnDisplay")
                        .HasColumnType("bit");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid>("UserId")
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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormatEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormatEntityId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SeatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionHourEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionHour");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TheaterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SeatId");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Password")
                        .HasColumnOrder(5);

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

                    b.ToTable("RoleEntityUserEntity");
                });

            modelBuilder.Entity("RoomEntitySeatEntity", b =>
                {
                    b.Property<Guid>("RoomsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomsId", "SeatsId");

                    b.HasIndex("SeatsId");

                    b.ToTable("RoomEntitySeatEntity");
                });

            modelBuilder.Entity("TheaterEntityUserEntity", b =>
                {
                    b.Property<Guid>("TheatersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TheatersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TheaterEntityUserEntity");
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
                        .HasForeignKey("ReserveTaPlace.Entities.AddressEntity", "TheaterId");

                    b.HasOne("ReserveTaPlace.Entities.UserEntity", "User")
                        .WithOne("Address")
                        .HasForeignKey("ReserveTaPlace.Entities.AddressEntity", "UserId");

                    b.Navigation("Theater");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.DiscountType", "DiscountType")
                        .WithMany("Discounts")
                        .HasForeignKey("DiscountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.OrderEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoomEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.FormatEntity", null)
                        .WithMany("Rooms")
                        .HasForeignKey("FormatEntityId");

                    b.HasOne("ReserveTaPlace.Entities.MovieEntity", "Movie")
                        .WithMany("Rooms")
                        .HasForeignKey("MovieId");

                    b.HasOne("ReserveTaPlace.Entities.TheaterEntity", "Theater")
                        .WithMany("Rooms")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.RoomEntity", "Room")
                        .WithMany("Sessions")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionHourEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.SessionEntity", "Session")
                        .WithMany("SessionHours")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TicketEntity", b =>
                {
                    b.HasOne("ReserveTaPlace.Entities.OrderEntity", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.SeatEntity", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.SessionEntity", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveTaPlace.Entities.UserEntity", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Seat");

                    b.Navigation("Session");

                    b.Navigation("User");
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

            modelBuilder.Entity("ReserveTaPlace.Entities.DiscountType", b =>
                {
                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.FormatEntity", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.MovieEntity", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.OrderEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.RoomEntity", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.SessionEntity", b =>
                {
                    b.Navigation("SessionHours");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.TheaterEntity", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ReserveTaPlace.Entities.UserEntity", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Discounts");

                    b.Navigation("Orders");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
