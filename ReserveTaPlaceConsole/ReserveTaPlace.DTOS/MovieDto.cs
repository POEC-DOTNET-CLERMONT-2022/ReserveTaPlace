using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("Movie")]
    public class MovieDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Released")]
        public string Released { get; set; }
        [JsonProperty(PropertyName = "Runtime")]
        public string Runtime { get; set; }
        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "Director")]
        public string Director { get; set; }
        [JsonProperty(PropertyName = "Actors")]
        public string Actors { get; set; }
        [JsonProperty(PropertyName = "Plot")]
        public string Plot { get; set; }
        [JsonProperty(PropertyName = "ImdbId")]
        public string ImdbId { get; set; }
        [JsonProperty(PropertyName = "Poster")]
        public string Poster { get; set; }
        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "Medias")]
        public List<MediaDto> Medias { get; set; }
    }
}
