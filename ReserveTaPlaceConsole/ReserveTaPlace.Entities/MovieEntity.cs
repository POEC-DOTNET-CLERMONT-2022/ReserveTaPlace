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
    public class MovieEntity
    {
        public MovieEntity()
        {
            Genres = new HashSet<MovieGenreEntity>();
            Medias = new HashSet<MediaEntity>();
            Rooms = new HashSet<RoomEntity>();
            Origins = new HashSet<MovieOriginEntity>();
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

        [InverseProperty(nameof(MovieGenreEntity.Movie))]
        public virtual ICollection<MovieGenreEntity> Genres { get; set; }

        [InverseProperty(nameof(MediaEntity.Movie))]
        public virtual ICollection<MediaEntity> Medias { get; set; }

        [InverseProperty(nameof(RoomEntity.Movie))]
        public virtual ICollection<RoomEntity> Rooms { get; set; }

        [InverseProperty(nameof(MovieOriginEntity.Movie))]
        public virtual ICollection<MovieOriginEntity> Origins { get; set; }


    }
}
