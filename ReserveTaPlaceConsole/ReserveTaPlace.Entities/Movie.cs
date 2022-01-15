using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Movie")]
    public class Movie
    {
        public Movie()
        {
            Genres = new HashSet<Genre>();
            Medias = new HashSet<Media>();
            Rooms = new HashSet<Room>();
            Origins = new HashSet<Origin>();
        }

        [Key]
        public Guid Id { get; set; }
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Plot { get; set; }
        public string CastStartDate { get; set; }
        public string CastEndDate { get; set; }
        public string ReleaseDate { get; set; }
        public string Runtime { get; set; }

        [Column(TypeName = "bit")]
        public bool IsMovieOnDisplay { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Origin> Origins { get; set; }


    }
}
