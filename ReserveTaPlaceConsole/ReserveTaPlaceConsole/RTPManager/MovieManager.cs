using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager.Interfaces;
using ReserveTaPlaceConsole.RTPManager;
using ReserveTaPlace.Extensions.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveTaPlace.DTOS;

namespace ReserveTaPlace.RTPManager
{
    public class MovieManager
    {
        private PersistanceLogic _persistanceLogic = new PersistanceLogic();
        private MovieLogic _movieLogic = new MovieLogic();
        private IReader _reader { get; }
        private IWriter _writer { get; }

        private IEnumerable<Movie> _movies;
        public IEnumerable<Movie> Movies
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
            Movies.ToList().Add(_reader.ReadMovie());
        }
        public void DisplayMovies()
        {
            _writer.DisplayMovies(Movies);
        }
        public async Task SaveMovies(IEnumerable<Movie> movies)
        {
            await _persistanceLogic.SaveMovies(movies);
        }
        public async Task GetAllMovies()
        {
            Movies = await _persistanceLogic.GetAllMovies();
            //var  movies = (IEnumerable<MovieDto>)_movieLogic.GetAllMovies();
            //Movies = movies.ToModel();
        }
        public async Task<Movie> GetMovie(string title,string year)
        {
            return await _reader.GetMovie(title,year); 
        }

    }
}
