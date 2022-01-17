using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("RoomFormat")]
    public class RoomFormatEntity
    {
        public RoomFormatEntity()
        {
            MovieRooms = new HashSet<MovieRoomEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(MovieRoomEntity.RoomFormat))]
        public virtual ICollection<MovieRoomEntity> MovieRooms { get; set; }
    }
}
