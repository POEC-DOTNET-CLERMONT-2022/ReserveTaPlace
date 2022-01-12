using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    public class MovieEntity
    {

        public virtual ICollection<GenreEntity> Genres { get; set; }
    }
}
