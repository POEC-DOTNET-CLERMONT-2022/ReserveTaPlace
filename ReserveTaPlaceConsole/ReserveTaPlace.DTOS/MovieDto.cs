using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
