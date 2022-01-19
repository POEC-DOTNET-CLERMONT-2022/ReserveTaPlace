using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Role")]
    public class RoleEntity : GenericEntity
    {
        public RoleEntity()
        {
            Users = new HashSet<UserEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
