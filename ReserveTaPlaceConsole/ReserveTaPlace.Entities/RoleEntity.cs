using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Role")]
    public class RoleEntity
    {
        public RoleEntity()
        {
            Users = new HashSet<UserRoleEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Role { get; set; }

        [InverseProperty(nameof(UserRoleEntity.Role))]
        public virtual ICollection<UserRoleEntity> Users { get; set; }


    }
}
