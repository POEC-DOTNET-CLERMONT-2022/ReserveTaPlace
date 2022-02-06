using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Genre")]
    public class GenreEntity
    {
        public GenreEntity()
        {
            GenreMovies = new HashSet<MovieGenreEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public virtual ICollection<MovieGenreEntity> GenreMovies { get; set; }
    }
}
