using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Origin")]
    public class OriginEntity
    {
        public OriginEntity()
        {
            OriginMovies = new HashSet<MovieOriginEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        [Column("Country", TypeName = "nvarchar(255)")]
        public string Country { get; set; }
        public virtual ICollection<MovieOriginEntity> OriginMovies { get; set; }
    }
}
