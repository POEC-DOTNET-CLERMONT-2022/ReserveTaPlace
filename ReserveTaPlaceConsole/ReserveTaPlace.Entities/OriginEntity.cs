using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Origin")]
    public class OriginEntity
    {
        public OriginEntity()
        {
            Movies = new HashSet<MovieEntity>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Country { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
