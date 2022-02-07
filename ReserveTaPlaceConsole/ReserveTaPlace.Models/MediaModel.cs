using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class MediaModel
    {
        private Guid _id;
        private string _link;
        private MovieModel _movie;
        private TheaterModel _theater;

        public MediaModel(string link, MovieModel movie, TheaterModel theater)
        {
            _link = link;
            _movie = movie;
            _theater = theater;
        }

        public Guid Id { get => _id; }
        public string Link { get { return _link; } set { _link = value; } }
        public MovieModel Movie { get { return _movie; } set { _movie = value; } }
        public TheaterModel Theater { get { return _theater; } set { _theater = value; } }
    }
}
