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
        public Guid? FormatId { get; set; }
        public Guid? TheaterId { get; set; }

        public string? Name { get; set; }
        public string? Number { get; set; }

        [ForeignKey(nameof(TheaterId))]
        [InverseProperty("Rooms")]
        public virtual TheaterEntity? Theater { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual MovieEntity? Movie { get; set; }

        [ForeignKey(nameof(FormatId))]
        public virtual FormatEntity? Format { get; set; }
        public virtual ICollection<SeatEntity>? Seats { get; set; }
        public virtual ICollection<SessionEntity>? Sessions { get; set; }
    }
}
