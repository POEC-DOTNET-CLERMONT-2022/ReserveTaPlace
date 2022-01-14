using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("MovieRoom")]
    public class MovieRoomEntity
    {
        public MovieRoomEntity()
        {
            Seats = new HashSet<SeatEntity>();
        }

        [Key]
        public int Id { get; set; }
        public int TheatreId { get; set; }
        public int RoomFormatId { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string Format { get; set; }

        [ForeignKey(nameof(TheatreId))]
        [InverseProperty("MovieRooms")]
        public virtual TheaterEntity Theater { get; set; }

        [InverseProperty(nameof(SeatEntity.MovieRoomId))]
        public virtual ICollection<SeatEntity> Seats { get; set; }

        [ForeignKey(nameof(RoomFormatId))]
        [InverseProperty("MovieRooms")]
        public virtual RoomFormatEntity RoomFormat { get; set; }
    }
}
