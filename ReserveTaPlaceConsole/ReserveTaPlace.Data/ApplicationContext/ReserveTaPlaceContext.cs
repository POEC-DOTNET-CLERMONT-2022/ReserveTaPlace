using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveTaPlace.Entities;

namespace ReserveTaPlace.Data.ApplicationContext
{
    public class ReserveTaPlaceContext : DbContext
    {
        public ReserveTaPlaceContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<CalendarEntity> Calendars { get; set; }
        public virtual DbSet<AddressEntity> Address { get; set; }
        public virtual DbSet<DiscountEntity> Discounts { get; set; }
        public virtual DbSet<DiscountType> DiscountTypes { get; set; }
        public virtual DbSet<GenreEntity> Genres { get; set; }
        public virtual DbSet<MediaEntity> Medias { get; set; }
        public virtual DbSet<MovieEntity> Movies { get; set; }
        public virtual DbSet<RoomEntity> Rooms { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OriginEntity> Origins { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<FormatEntity> Formats { get; set; }
        public virtual DbSet<SeatEntity> Seats { get; set; }
        public virtual DbSet<SessionEntity> Sessions { get; set; }
        public virtual DbSet<ScheduleEntity> SessionHours { get; set; }
        public virtual DbSet<TheaterEntity> Theaters { get; set; }
        public virtual DbSet<TicketEntity> Tickets { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table ScheduleSeats
            modelBuilder
                .Entity<ScheduleEntity>()
                .HasMany(s => s.Seats)
                .WithMany(s => s.Schedules)
                .UsingEntity(j => j.ToTable("ScheduleSeats"));
            modelBuilder
                .Entity<SeatEntity>()
                .HasMany(s => s.Schedules)
                .WithMany(s => s.Seats)
                .UsingEntity(j => j.ToTable("ScheduleSeats"));

            // Table MovieGenres
            modelBuilder
                .Entity<MovieEntity>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenres"));
            modelBuilder
                .Entity<GenreEntity>()
                .HasMany(g => g.Movies)
                .WithMany(m => m.Genres)
                .UsingEntity(j => j.ToTable("MovieGenres"));

            // Table MovieOrigins
            modelBuilder
                .Entity<MovieEntity>()
                .HasMany(m => m.Origins)
                .WithMany(o => o.Movies)
                .UsingEntity(j => j.ToTable("MovieOrigins"));
            modelBuilder
                .Entity<OriginEntity>()
                .HasMany(o => o.Movies)
                .WithMany(m => m.Origins)
                .UsingEntity(j => j.ToTable("MovieOrigins"));

            // Table RoomSeats
            modelBuilder
                .Entity<RoomEntity>()
                .HasMany(r => r.Seats)
                .WithMany(s => s.Rooms)
                .UsingEntity(j => j.ToTable("RoomSeats"));
            modelBuilder
                .Entity<SeatEntity>()
                .HasMany(s => s.Rooms)
                .WithMany(r => r.Seats)
                .UsingEntity(j => j.ToTable("RoomSeats"));

            // Table UserRoles
            modelBuilder
                .Entity<UserEntity>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));
            modelBuilder
                .Entity<RoleEntity>()
                .HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .UsingEntity(j => j.ToTable("UserRoles"));

            // Table UserTheaters
            modelBuilder
                .Entity<UserEntity>()
                .HasMany(u => u.Theaters)
                .WithMany(t => t.Users)
                .UsingEntity(j => j.ToTable("UserTheaters"));
            modelBuilder
                .Entity<TheaterEntity>()
                .HasMany(t => t.Users)
                .WithMany(u => u.Theaters)
                .UsingEntity(j => j.ToTable("UserTheaters"));


            base.OnModelCreating(modelBuilder);
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
