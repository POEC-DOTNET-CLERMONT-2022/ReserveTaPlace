using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Origin")]
    public class OriginEntity : GenericEntity
    {
        public OriginEntity()
        {
            Movies = new HashSet<MovieEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Country { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
