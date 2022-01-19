﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Ticket")]
    public class TicketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual SeatEntity Seat { get; set; }
        public virtual OrderEntity Order { get; set; }
        public virtual SessionEntity Session { get; set; }

    }
}
