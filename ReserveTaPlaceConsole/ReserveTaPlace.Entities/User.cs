using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Discounts = new HashSet<Discount>();
            Theaters = new HashSet<Theater>();
            Tickets = new HashSet<Ticket>();
            Roles = new HashSet<Role>();
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
        public Address? Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Theater> Theaters { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Role> Roles { get; set; }



    }
}
