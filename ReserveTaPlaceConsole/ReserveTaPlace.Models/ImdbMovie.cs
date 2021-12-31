using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class ImdbMovie
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title;
        [JsonProperty(PropertyName = "Year")]
        public string Year;
        [JsonProperty(PropertyName = "imdbID")]
        public string imdbID;
        [JsonProperty(PropertyName = "Type")]
        public string Type;
        [JsonProperty(PropertyName = "Poster")]
        public string Poster;
    }
}
