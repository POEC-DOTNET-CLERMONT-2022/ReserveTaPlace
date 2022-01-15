using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Theater")]
    public class Theater
    {
        public Theater()
        {
            Rooms = new HashSet<Room>();
            Users = new HashSet<User>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
