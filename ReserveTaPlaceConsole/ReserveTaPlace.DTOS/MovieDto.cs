using Newtonsoft.Json;

namespace ReserveTaPlace.DTOS
{
    public class MovieDto
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Year")]
        public string Year { get; set; }
        [JsonProperty(PropertyName = "ImdbId")]
        public string ImdbId { get; set; }
        [JsonProperty(PropertyName = "Poster")]
        public string Poster { get; set; }
        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "Plot")]
        public string Plot { get; set; }
        [JsonProperty(PropertyName = "Runtime")]
        public string RunTime { get; set; }
        [JsonProperty(PropertyName = "ReleaseDate")]
        public string ReleaseDate { get; set; }
    }
}
