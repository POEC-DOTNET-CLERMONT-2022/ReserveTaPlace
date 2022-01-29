using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("DiscountType")]
    public class DiscountType
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }

    }
}
