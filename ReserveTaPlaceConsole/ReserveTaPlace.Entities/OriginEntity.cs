﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Origin")]
    public class OriginEntity
    {
        public OriginEntity()
        {
            Movies = new HashSet<MovieOriginEntity>();
        }

        [Key]
        public Guid Id { get; set;}
        public string Country { get; set; }
        [InverseProperty(nameof(MovieOriginEntity.Origin))]
        public virtual ICollection<MovieOriginEntity> Movies { get; set; }
    }
}
