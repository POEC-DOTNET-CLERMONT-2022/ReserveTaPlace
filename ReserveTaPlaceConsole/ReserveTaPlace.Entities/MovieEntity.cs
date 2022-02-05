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
        [Column("Released", TypeName = "nvarchar(12)")]
        public string Released { get; set; }
        [Column("Runtime", TypeName = "nvarchar(8)")]
        public string Runtime { get; set; }
        [Column("Genre", TypeName = "nvarchar(250)")]
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        [Column("ImdbId", TypeName = "nvarchar(20)")]
        public string ImdbId { get; set; }
        public string Poster { get; set; }
        public string Country { get; set; }
        public DateTime? CastStartDate { get; set; }
        public DateTime? CastEndDate { get; set; }
        [Column(TypeName = "bit")]
        public bool IsMovieOnDisplay { get; set; }

        public virtual ICollection<GenreEntity> Genres { get; set; }
        public virtual ICollection<MediaEntity> Medias { get; set; }
        public virtual ICollection<OriginEntity> Origins { get; set; }
    }
}
