using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Address")]
    public class AddressEntity
    {
        public AddressEntity()
        {
            Users = new HashSet<UserEntity>();
        }

        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }

        [Column("Address1", TypeName = "nvarchar(100)", Order = 2)]
        public string? Address1 { get; set; }

        [Column("Address2", TypeName = "nvarchar(100)", Order = 3)]
        public string? Address2 { get; set; }

        [Column("Street", TypeName = "nvarchar(255)", Order = 4)]
        public string? Street { get; set; }

        [Column("City", TypeName = "nvarchar(255)", Order = 5)]
        public string City { get; set; }

        [Column("PostalCode", TypeName = "nvarchar(5)", Order = 6)]
        public string PostalCode { get; set; }

        [Column("Number", TypeName = "nvarchar(5)", Order = 7)]
        public string? Number { get; set; }

        [Column("County", TypeName = "nvarchar(255)", Order = 8)]
        public string County { get; set; }

        [InverseProperty(nameof(UserEntity.Address))]
        public virtual ICollection<UserEntity> Users { get; set; }

    }
}
