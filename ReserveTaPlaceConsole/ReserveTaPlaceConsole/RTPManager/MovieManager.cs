using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager.Interfaces;
using ReserveTaPlaceConsole.RTPManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.RTPManager
{
    public class MovieManager
    {
        private PersistanceLogic _persistanceLogic = new PersistanceLogic();
        private MovieLogic _movieLogic = new MovieLogic();
        private IReader _reader { get; }
        private IWriter _writer { get; }

        private List<Movie> _movies;
        public List<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }

        public MovieManager()
        {
            _reader = new Reader();
            _writer = new Writer();
            _movies = new List<Movie>();
        }

        public void Add()
        {
            Movies.Add(_reader.ReadMovie());
        }
        public void DisplayMovies()
        {
            _writer.DisplayMovies(Movies);
        }
        public void SaveMovies(List<Movie> movies)
        {
            _persistanceLogic.SaveMovies(movies);
        }
        public void GetAllMovies()
        {
            Movies = _movieLogic.GetAllMovies();
        }
        public async Task<List<Movie>> SearchMovie(string movieName)
        {
            return await _reader.SearchMovie(movieName); 
        }

    }
}
