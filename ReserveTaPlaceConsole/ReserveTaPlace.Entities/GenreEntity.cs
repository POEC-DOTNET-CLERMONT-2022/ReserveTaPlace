using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Genre")]
    public class GenreEntity
    {
        public GenreEntity()
        {
            Movies = new HashSet<MovieGenreEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(MovieGenreEntity.Genre))]
        public virtual ICollection<MovieGenreEntity> Movies { get; set; }

    }
}
