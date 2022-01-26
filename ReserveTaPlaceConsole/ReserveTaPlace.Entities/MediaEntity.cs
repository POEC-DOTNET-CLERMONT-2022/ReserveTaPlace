﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Media")]
    public class MediaEntity
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Medias")]
        public virtual MovieEntity Movie { get; set; }
    }
}