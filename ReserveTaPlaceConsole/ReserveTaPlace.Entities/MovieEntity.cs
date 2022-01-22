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
            Origins = new HashSet<OriginEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string ImdbId { get; set; }
        public string Poster { get; set; }
        public string Country { get; set; }
        public string? CastStartDate { get; set; }
        public string? CastEndDate { get; set; }
        [Column(TypeName = "bit")]
        public bool IsMovieOnDisplay { get; set; }

        public virtual ICollection<GenreEntity>? Genres { get; set; }
        public virtual ICollection<MediaEntity>? Medias { get; set; }
        public virtual ICollection<OriginEntity>? Origins { get; set; }
    }
}
