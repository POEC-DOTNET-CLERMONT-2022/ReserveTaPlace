using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Theater")]
    public class TheaterEntity
    {
        public TheaterEntity()
        {
            Rooms = new HashSet<RoomEntity>();
            Users = new HashSet<UserEntity>();
            Medias = new HashSet<MediaEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("Name", TypeName = "nvarchar(70)")]
        public string Name { get; set; }
        public virtual AddressEntity Address { get; set; }
        public virtual ICollection<RoomEntity> Rooms { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<MediaEntity> Medias { get; set; }

    }
}
