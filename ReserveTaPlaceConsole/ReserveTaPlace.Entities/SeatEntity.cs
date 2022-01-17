using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Seat")]
    public class SeatEntity
    {
        [Key]
        public int Id { get; set; }
        public int MovieRoomId { get; set; }
        public string Row { get; set; }
        public string Number { get; set; }

        [ForeignKey(nameof(MovieRoomId))]
        [InverseProperty("Seats")]
        public virtual MovieRoomEntity MovieRoom { get; set; }
    }
}
