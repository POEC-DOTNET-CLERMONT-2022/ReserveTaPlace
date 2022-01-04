using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ReserveTaPlace.wcf.Models
{
    [DataContract]
    public class Movie
    {

            private Guid _id;
            private string _title;
            private string _description;
            private DateTime _castStartDate;
            private DateTime _castEndDate;
            private DateTime _releaseDate;
            private DateTime _duration;
            private bool _isMovieOnDisplay;

            public Movie(string title)
            {
                _id = Guid.NewGuid();
                _title = title;
                //_description = description;
                //_castStartDate = castStartDate;
                //_castEndDate = castEndDate;
                //_releaseDate = releaseDate;
                //_duration = duration;
                _isMovieOnDisplay = false;
            }
        [DataMember]
        public Guid Id { get { return _id; } }
        [DataMember]
        public string Title { get { return _title; } set { _title = value; } }
        [DataMember]
        public string Description { get { return _description; } set { _description = value; } }
        [DataMember]
        public DateTime CastStartDate { get { return _castStartDate; } set { _castStartDate = value; } }
        [DataMember]
        public DateTime CastEndDate { get { return _castEndDate; } set { _castEndDate = value; } }
        [DataMember]
        public DateTime ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
        [DataMember]
        public DateTime Duration { get { return _duration; } set { _duration = value; } }
        [DataMember]
        public bool IsMovieOnDisplay
            {
                get { return _isMovieOnDisplay; }
                set { _isMovieOnDisplay = value; }
            }
    }
}