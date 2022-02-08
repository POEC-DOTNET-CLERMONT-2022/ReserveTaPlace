using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("movie")]
    public class MovieDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "released")]
        public string Released { get; set; }
        [JsonProperty(PropertyName = "runtime")]
        public string Runtime { get; set; }
        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "director")]
        public string Director { get; set; }
        [JsonProperty(PropertyName = "actors")]
        public string Actors { get; set; }
        [JsonProperty(PropertyName = "plot")]
        public string Plot { get; set; }
        [JsonProperty(PropertyName = "imdbId")]
        public string ImdbId { get; set; }
        [JsonProperty(PropertyName = "poster")]
        public string Poster { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }


    }
}
