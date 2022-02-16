using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("Search")]
    public class ImdbSearch
    {
        [JsonProperty(PropertyName = "Search")]
        public List<MovieDto> ImdbMovies { get; set; } = new List<MovieDto>();
        [JsonProperty(PropertyName = "totalResults")]
        public int TotalResult { get; set; }    
    }
}
