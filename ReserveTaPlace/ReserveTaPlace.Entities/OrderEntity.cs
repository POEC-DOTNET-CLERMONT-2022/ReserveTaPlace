using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<TicketEntity> Tickets { get; set; }
        public virtual UserEntity? User { get; set; }
    }
}
