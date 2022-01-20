using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.Models
{
    public class Movie
    {
        private Guid _id;
        private string _imdbId;
        private string _title;
        private string _plot;
        private string _poster;
        private string _country;
        private string _castStartDate;
        private string _castEndDate;
        private string _releaseDate;
        private string _runtime;
        private bool _isMovieOnDisplay;
        private int _idC;

        public int IdC
        {
            get { return _idC; }
            set { _idC = value; }
        }
        public Movie()
        {
            _id= Guid.NewGuid();
        }
        public Movie(int idc,string title)
        {
            _idC = idc;
            _title = title;
        }
        [JsonConstructor]
        public Movie(string title,string plot,string poster,string imdbId,string releaseDate,string runtime)
        {
            _id = Guid.NewGuid();
            _title = title;
            _plot = plot;
            _poster = poster;
            _imdbId = imdbId;
            _releaseDate = releaseDate;
            _runtime = runtime;
            _isMovieOnDisplay = false;
        }
        //public Movie(string title, string imdbId)
        //{
        //    _title = title;
        //    _imdbId = imdbId;
        //    //_castStartDate = castStartDate;
        //    //_castEndDate = castEndDate;
        //    //_releaseDate = releaseDate;
        //    //_duration = duration;
        //    _isMovieOnDisplay = false;
        //}

        public Guid Id { get => _id; set => _id = value; }
        public string ImdbId { get { return _imdbId; } set { _imdbId = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Poster { get { return _poster; } set { _poster = value; } }

        public string Country { get { return _country; } set { _country = value; } }
        public string Plot { get { return _plot; } set { _plot = value; } }
        public string CastStartDate { get { return _castStartDate; } set { _castStartDate = value; } }
        public string CastEndDate { get { return _castEndDate; } set { _castEndDate = value; } }
        public string ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
        public string Runtime { get { return _runtime; } set { _runtime = value; } }
        public bool IsMovieOnDisplay
        {
            get { return _isMovieOnDisplay; }
            set { _isMovieOnDisplay = value; }
        }


    }
}
