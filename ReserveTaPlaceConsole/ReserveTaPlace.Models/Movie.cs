using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class Movie
    {
        private Guid _id;
        private string _title;
        private string _description;
        private DateTime _castStartDate;
        private DateTime _castEndDate;
        private DateTime _releaseDate;
        private DateTime _duration;

        public Movie(string title, DateTime releaseDate)
        {
            _id = Guid.NewGuid();
            _title = title;
            //_description = description;
            //_castStartDate = castStartDate;
            //_castEndDate = castEndDate;
            _releaseDate = releaseDate;
            //_duration = duration;
        }
        public Guid Id { get { return _id; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public DateTime CastStartDate { get { return _castStartDate; } set { _castStartDate = value; } }
        public DateTime CastEndDate { get { return _castEndDate; } set { _castEndDate = value; } }
        public DateTime ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
        public DateTime Duration { get { return _duration; } set { _duration = value; } }


    }
}
