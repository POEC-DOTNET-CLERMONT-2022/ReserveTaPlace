using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Room")]
    public class Room
    {
        public Room()
        {
            Seats = new HashSet<Seat>();
            Sessions = new HashSet<Session>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? MovieId { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public virtual Theater Theater { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Rooms")]
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<Session> Sessions { get; set;}
    }
}
