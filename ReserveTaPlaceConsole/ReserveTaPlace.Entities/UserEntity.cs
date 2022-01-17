﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("User")]
    public class UserEntity
    {
        public UserEntity()
        {
            Orders = new HashSet<OrderEntity>();
            Discounts = new HashSet<DiscountEntity>();
            Theaters = new HashSet<TheaterEntity>();
            Tickets = new HashSet<TicketEntity>();
            Roles = new HashSet<RoleEntity>();
        }

        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }
        public Guid? AddressId { get; set; }

        [Column("FirstName", TypeName = "nvarchar(70)", Order = 2)]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "nvarchar(70)", Order = 3)]
        public string LastName { get; set; }

        [Column("Email", TypeName = "nvarchar(255)", Order = 4)]
        public string Email { get; set; }

        [Column("Password", TypeName = "nvarchar(50)", Order = 5)]
        public string Password { get; set; }
        public AddressEntity? Address { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
        public virtual ICollection<DiscountEntity> Discounts { get; set; }
        public virtual ICollection<TheaterEntity> Theaters { get; set; }
        public virtual ICollection<TicketEntity> Tickets { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; }



    }
}
