using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Role")]
    public class RoleEntity
    {
        public RoleEntity()
        {
            RoleUsers = new HashSet<UserRoleEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        [Column("Name", TypeName = "nvarchar(70)")]
        public string Name { get; set; }
        public virtual ICollection<UserRoleEntity> RoleUsers { get; set; }
    }
}
