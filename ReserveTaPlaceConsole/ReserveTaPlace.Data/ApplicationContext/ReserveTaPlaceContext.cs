using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveTaPlace.Entities;

namespace ReserveTaPlace.Data.ApplicationContext
{
    public class ReserveTaPlaceContext : DbContext
    {
        private string ConnectionString { get; }
        public ReserveTaPlaceContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public ReserveTaPlaceContext()
        {

        }

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
        public virtual DbSet<SessionHourEntity> SessionHours { get; set; }
        public virtual DbSet<TheaterEntity> Theaters { get; set; }
        public virtual DbSet<TicketEntity> Tickets { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //(LocalDb)\MSSQLLocalDB
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EntityTypeBuilder<UserEntity> entityTypeBuilder = modelBuilder.Entity<UserEntity>();

            //[Column("Pseudo")] //Si nom de colonne différent
            //entityTypeBuilder.Property(u => u.Login).HasColumnName("Pseudo");

            //si pas de clé
            //entityTypeBuilder.HasNoKey();

            //équivalent à [Table("User")] dans le SqlDto
            //entityTypeBuilder.ToTable("User");
            //équivalent à [Key] dans le SqlDto
            //userCatalog.HasKey(u => u.UserId);
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
