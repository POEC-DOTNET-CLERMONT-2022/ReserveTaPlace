using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Order Order { get; set; }
        public virtual Session Session { get; set; }

    }
}
