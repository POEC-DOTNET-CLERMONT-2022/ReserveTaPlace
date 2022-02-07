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
        public virtual DbSet<ScheduleSeatEntity> SchedulenSeats { get; set; }
        public virtual DbSet<MovieGenreEntity> MovieGenres { get; set; }
        public virtual DbSet<MovieOriginEntity> MovieOrigins { get; set; }
        public virtual DbSet<UserRoleEntity> UserRoles { get; set; }
        public virtual DbSet<UserTheaterEntity> UserTheaters { get; set; }
        public virtual DbSet<RoomSeatEntity> RoomSeats { get; set; }
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
            modelBuilder.Entity<ScheduleSeatEntity>().HasKey(ss => new { ss.ScheduleId, ss.SeatId });
            modelBuilder.Entity<ScheduleSeatEntity>()
            .HasOne<ScheduleEntity>(ss => ss.Schedule)
            .WithMany(ss => ss.ScheduleSeats)
            .HasForeignKey(s => s.ScheduleId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ScheduleSeatEntity>()
            .HasOne<SeatEntity>(ss => ss.Seat)
            .WithMany(ss => ss.SeatSchedules)
            .HasForeignKey(s => s.SeatId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovieGenreEntity>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieGenreEntity>()
            .HasOne<MovieEntity>(mg => mg.Movie)
            .WithMany(mg => mg.MovieGenres)
            .HasForeignKey(m => m.MovieId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MovieGenreEntity>()
            .HasOne<GenreEntity>(mg => mg.Genre)
            .WithMany(mg => mg.GenreMovies)
            .HasForeignKey(g => g.GenreId)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<MovieOriginEntity>().HasKey(mo => new { mo.MovieId, mo.OriginId });
            modelBuilder.Entity<MovieOriginEntity>()
            .HasOne<MovieEntity>(mo => mo.Movie)
            .WithMany(mo => mo.MovieOrigins)
            .HasForeignKey(m => m.MovieId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MovieOriginEntity>()
            .HasOne<OriginEntity>(mo => mo.Origin)
            .WithMany(o => o.OriginMovies)
            .HasForeignKey(o => o.OriginId)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<RoomSeatEntity>().HasKey(rm => new { rm.RoomId, rm.SeatId });
            modelBuilder.Entity<RoomSeatEntity>()
            .HasOne<RoomEntity>(rs => rs.Room)
            .WithMany(rs => rs.RoomSeats)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RoomSeatEntity>()
            .HasOne<SeatEntity>(rs => rs.Seat)
            .WithMany(rs => rs.SeatRooms)
            .HasForeignKey(s => s.SeatId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRoleEntity>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRoleEntity>()
            .HasOne<UserEntity>(ur => ur.User)
            .WithMany(ur => ur.UserRoles)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRoleEntity>()
            .HasOne<RoleEntity>(ur => ur.Role)
            .WithMany(ur => ur.RoleUsers)
            .HasForeignKey(r => r.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTheaterEntity>().HasKey(ut => new { ut.UserId, ut.TheaterId});
            modelBuilder.Entity<UserTheaterEntity>()
            .HasOne<UserEntity>(ut => ut.User)
            .WithMany(ut => ut.UserTheaters)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserTheaterEntity>()
            .HasOne<TheaterEntity>(ut => ut.Theater)
            .WithMany(ut => ut.TheaterUsers)
            .HasForeignKey(t => t.TheaterId)
            .OnDelete(DeleteBehavior.NoAction);


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
