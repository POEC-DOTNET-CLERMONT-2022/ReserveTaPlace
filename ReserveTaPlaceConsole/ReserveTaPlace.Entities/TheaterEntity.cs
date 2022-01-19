﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Theater")]
    public class TheaterEntity
    {
        public TheaterEntity()
        {
            Rooms = new HashSet<RoomEntity>();
            Users = new HashSet<UserEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressEntity Address { get; set; }
        public virtual ICollection<RoomEntity> Rooms { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }


    }
}
