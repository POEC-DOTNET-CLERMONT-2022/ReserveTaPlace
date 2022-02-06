using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("MovieGenre")]
    public class MovieGenreEntity
    {
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }
        public virtual MovieEntity Movie { get; set; }
        public virtual GenreEntity Genre { get; set; }
    }
}
