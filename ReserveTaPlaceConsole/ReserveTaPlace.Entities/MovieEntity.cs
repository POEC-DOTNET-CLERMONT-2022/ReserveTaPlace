using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Movie")]
    public class MovieEntity
    {
        public MovieEntity()
        {
            Genres = new HashSet<GenreEntity>();
            Medias = new HashSet<MediaEntity>();
            Rooms = new HashSet<RoomEntity>();
            Origins = new HashSet<OriginEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual ICollection<GenreEntity> Genres { get; set; }
        public virtual ICollection<MediaEntity> Medias { get; set; }
        public virtual ICollection<RoomEntity> Rooms { get; set; }
        public virtual ICollection<OriginEntity> Origins { get; set; }


    }
}
