﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Column(Order = 2)]
        public int AddressId { get; set; }

        [Column("FirstName", TypeName = "nvarchar(70)", Order = 3)]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "nvarchar(70)", Order = 4)]
        public string LastName { get; set; }

        [Column("Email", TypeName = "nvarchar(255)", Order = 5)]
        public string Email { get; set; }

        [Column("Password", TypeName = "nvarchar(50)", Order = 6)]
        public string Password { get; set; }


        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Users")]
        public virtual AddressEntity Address { get; set; }

        [InverseProperty(nameof(OrderEntity.User))]
        public virtual ICollection<OrderEntity> Orders { get; set; }
        
        [InverseProperty(nameof(DiscountEntity.User))]
        public virtual ICollection<DiscountEntity> Discounts { get; set; }
        
        [InverseProperty(nameof(UserTheaterEntity.User))]
        public virtual ICollection<TheaterEntity> Theaters { get; set; }
        
        [InverseProperty(nameof(TicketEntity.User))]
        public virtual ICollection<TicketEntity> Tickets { get; set; }

        [InverseProperty(nameof(UserRoleEntity.User))]
        public virtual ICollection<RoleEntity> Roles { get; set; }



    }
}
