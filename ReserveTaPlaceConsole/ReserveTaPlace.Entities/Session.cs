using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Session")]
    public class Session
    {
        public Session()
        {
            SessionHours = new HashSet<SessionHour>();
        }

        [Key]
        public Guid Id { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<SessionHour> SessionHours { get; set; }

    }
}
