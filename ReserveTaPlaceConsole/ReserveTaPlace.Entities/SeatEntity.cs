﻿using System.ComponentModel.DataAnnotations;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Row { get; set; }
        public string Number { get; set; }
        public virtual ICollection<RoomEntity> Rooms { get; set; }
    }
}
