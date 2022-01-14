using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Guid Id { get; set; }
        public Guid TheatreId { get; set; }
        public Guid FormatId { get; set; }
        public Guid? MovieId { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }

        [ForeignKey(nameof(TheatreId))]
        [InverseProperty("Rooms")]
        public virtual TheaterEntity Theater { get; set; }

        [InverseProperty(nameof(SeatEntity.Room))]
        public virtual ICollection<SeatEntity> Seats { get; set; }

        [ForeignKey(nameof(FormatId))]
        [InverseProperty("Rooms")]
        public virtual FormatEntity Format { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Rooms")]
        public virtual MovieEntity Movie { get; set; }
        [InverseProperty(nameof(SessionEntity.Room))]
        public virtual ICollection<SessionEntity> Sessions { get; set;}
    }
}
