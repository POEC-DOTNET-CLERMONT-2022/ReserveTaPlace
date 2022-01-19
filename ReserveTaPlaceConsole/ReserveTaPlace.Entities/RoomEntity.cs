using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Room")]
    public class RoomEntity
    {
        public RoomEntity()
        {
            Seats = new HashSet<SeatEntity>();
            Sessions = new HashSet<SessionEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? MovieId { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public virtual TheaterEntity Theater { get; set; }
        public virtual ICollection<SeatEntity> Seats { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Rooms")]
        public virtual MovieEntity? Movie { get; set; }
        public virtual ICollection<SessionEntity> Sessions { get; set; }
    }
}
