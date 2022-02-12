using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("imdbSearch")]
    public class ImdbSearch
    {
        [JsonProperty(PropertyName = "ImdbMovies")]
        public List<MovieDto> ImdbMovies { get; set; } = new List<MovieDto>();
    }
}
