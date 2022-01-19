using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("DiscountType")]
    public class DiscountType
    {
        public DiscountType()
        {
            Discounts = new HashSet<DiscountEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short Rate { get; set; }
        public float Amount { get; set; }
        public virtual ICollection<DiscountEntity> Discounts { get; set; }
    }
}
