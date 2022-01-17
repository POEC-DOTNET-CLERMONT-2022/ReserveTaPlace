using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Order")]
    public class OrderEntity
    {
        public OrderEntity()
        {
            Tickets = new HashSet<TicketEntity>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        [InverseProperty(nameof(TicketEntity.Order))]
        public virtual ICollection<TicketEntity> Tickets { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Orders")]
        public virtual UserEntity User { get; set; }

    }
}
