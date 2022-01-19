using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Address")]
    public class AddressEntity : GenericEntity
    {
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }
        public Guid? TheaterId { get; set; }
        public Guid? UserId { get; set; }

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

        [ForeignKey(nameof(TheaterId))]
        [InverseProperty("Address")]
        public virtual TheaterEntity Theater { set; get; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Address")]
        public virtual UserEntity? User { set; get; }

    }
}
