using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Seat")]
    public class SeatEntity
    {
        public SeatEntity()
        {
            Rooms = new HashSet<RoomEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        [Column("Row", TypeName = "nvarchar(5)")]
        public string Row { get; set; }
        [Column("Number", TypeName = "nvarchar(5)")]
        public string Number { get; set; }
        public virtual ICollection<RoomEntity>? Rooms { get; set; }
    }
}
