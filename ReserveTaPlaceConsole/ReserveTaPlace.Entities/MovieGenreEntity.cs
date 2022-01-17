using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("MovieGenre")]
    public class MovieGenreEntity
    {
        [Key]
        public int MovieId { get; set; }

        [Key]
        public int GenreId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Movies")]
        public virtual GenreEntity Genre { get; set; }

        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Genres")]
        public virtual MovieEntity Movie { get; set; }

    }
}
