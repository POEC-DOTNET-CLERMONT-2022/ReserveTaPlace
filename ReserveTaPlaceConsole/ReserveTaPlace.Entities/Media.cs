using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Media")]
    public class Media
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
