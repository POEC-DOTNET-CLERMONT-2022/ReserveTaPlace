using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    public class TheaterEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
