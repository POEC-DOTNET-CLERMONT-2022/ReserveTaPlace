using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReserveTaPlace.DTOS
{
    public class ImdbSearch
    {
        [JsonProperty(PropertyName = "Search")]
        public List<MovieDto> ImdbMovies { get; set; } = new List<MovieDto>();
    }
}
