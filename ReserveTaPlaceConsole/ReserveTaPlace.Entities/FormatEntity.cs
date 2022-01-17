using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Format")]
    public class FormatEntity
    {
        public FormatEntity()
        {
            Rooms = new HashSet<RoomEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RoomEntity> Rooms { get; set; }
    }
}
