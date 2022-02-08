using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("imdbSearch")]
    public class ImdbSearch
    {
        [JsonProperty(PropertyName = "imdbMovies")]
        public List<MovieDto> ImdbMovies { get; set; } = new List<MovieDto>();
    }
}
