using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.DTOS
{
    [DataContract]
    public class MovieDto
    {
        public MovieDto(string title)
        {
            Title = title;
        }
        [DataMember]
        public string Title { get; set; }
    }
}
