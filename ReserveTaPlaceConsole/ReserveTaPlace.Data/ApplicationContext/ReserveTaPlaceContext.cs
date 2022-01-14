using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.ApplicationContext
{
    public class ReserveTaPlaceContext : DbContext
    {
        public ReserveTaPlaceContext()
        {

        }

        public virtual DbSet<AddressEntity> Address { get; set; }
        public virtual DbSet<DiscountEntity> Discounts { get; set; }
        public virtual DbSet<DiscountTypeEntity> DiscountTypes { get; set; }
        public virtual DbSet<GenreEntity> Genres { get; set; }
        public virtual DbSet<MediaEntity> Medias { get; set; }
        public virtual DbSet<MovieEntity> Movies { get; set; }
        public virtual DbSet<MovieGenreEntity> MoviesGenres { get; set; }
        public virtual DbSet<MovieOriginEntity> MoviesOrigins { get; set; }
        public virtual DbSet<RoomEntity> Rooms { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; } 
        public virtual DbSet<OriginEntity> Origins { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<FormatEntity> Formats { get; set; }
        public virtual DbSet<SeatEntity> Seats { get; set; }
        public virtual DbSet<SessionEntity> Sessions { get; set; }
        public virtual DbSet<SessionHourEntity> SessionHours { get; set; }
        public virtual DbSet<TheaterEntity> Theaters { get; set; }
        public virtual DbSet<TicketEntity> Tickets { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<UserRoleEntity> UsersRoles { get; set; }
        public virtual DbSet<UserTheaterEntity> UsersTheaters { get; set; }
        private string ConnectionString { get; }

        public ReserveTaPlaceContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=ReserveTaPlace;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenreEntity>(entity =>
            {
                entity.HasKey("MovieId", "GenreId");
            });

            modelBuilder.Entity<UserRoleEntity>(entity =>
            {
                entity.HasKey("UserId", "RoleId");
            });

            modelBuilder.Entity<UserTheaterEntity>(entity =>
            {
                entity.HasKey("UserId", "TheaterId");
            });

            modelBuilder.Entity<MovieOriginEntity>(entity =>
            {
                entity.HasKey("MovieId", "OriginId");
            });


        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return base.Set<TEntity>();
        }
    }
}
