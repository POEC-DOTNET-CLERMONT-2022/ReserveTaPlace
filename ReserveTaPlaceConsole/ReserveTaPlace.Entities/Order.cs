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
    public class Order
    {
        public Order()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual User User { get; set; }

    }
}
