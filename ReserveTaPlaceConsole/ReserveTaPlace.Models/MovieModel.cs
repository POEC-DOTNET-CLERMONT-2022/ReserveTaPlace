using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class MovieModel
    {

        private Guid _id;
        private string _imdbId;
        private string _title;
        private string _plot;
        private string _poster;
        private string _genre;
        private string _director;
        private string _actors;
        private string _country;
        private string _castStartDate;
        private string _castEndDate;
        private string _released;
        private string _runtime;
        private bool _isMovieOnDisplay;

        public MovieModel()
        {
            _id = Guid.NewGuid();
        }
        public MovieModel(int idc, string title)
        {
            _title = title;
        }
        [JsonConstructor]
        public MovieModel(string title, string plot, string genre, string director, string poster, string imdbId, string released, string runtime)
        {
            _id = Guid.NewGuid();
            _title = title;
            _plot = plot;
            _poster = poster;
            _imdbId = imdbId;
            _released = released;
            _runtime = runtime;
            _isMovieOnDisplay = false;
            _genre = genre;
            _director = director;
        }

        public Guid Id { get => _id; set => _id = value; }
        public string ImdbId { get { return _imdbId; } set { _imdbId = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Poster { get { return _poster; } set { _poster = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public string Director { get { return _director; } set { _director = value; } }
        public string Actors { get { return _actors; } set { _actors = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string Plot { get { return _plot; } set { _plot = value; } }
        public string CastStartDate { get { return _castStartDate; } set { _castStartDate = value; } }
        public string CastEndDate { get { return _castEndDate; } set { _castEndDate = value; } }
        public string Released { get { return _released; } set { _released = value; } }
        public string Runtime { get { return _runtime; } set { _runtime = value; } }
        public bool IsMovieOnDisplay
        {
            get { return _isMovieOnDisplay; }
            set { _isMovieOnDisplay = value; }
        }
    }
}
