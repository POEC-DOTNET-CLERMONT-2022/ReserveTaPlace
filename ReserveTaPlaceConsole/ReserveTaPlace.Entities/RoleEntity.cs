using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Role")]
    public class RoleEntity
    {
        public RoleEntity()
        {
            Users = new HashSet<UserEntity>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("Name", TypeName = "nvarchar(70)")]
        public string Name { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
