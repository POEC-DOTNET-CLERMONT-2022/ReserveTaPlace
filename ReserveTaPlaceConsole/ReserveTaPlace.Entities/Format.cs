using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Format")]
    public class Format
    {
        public Format()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
