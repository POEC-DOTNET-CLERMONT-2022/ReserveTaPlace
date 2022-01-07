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
        private PersistanceLogic _persistanceLogic;
        private MovieLogic _movieLogic;
        private MovieProviderLogic _movieProviderLogic;
        private IWriter _writer { get; }
        private IEnumerable<Movie> _movies;
        public IEnumerable<Movie> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }

        public MovieManager()
        {
            _writer = new Writer();
            _movies = new List<Movie>();
            _persistanceLogic = new PersistanceLogic();
            _movieLogic = new MovieLogic();
            _movieProviderLogic = new MovieProviderLogic();
        }
        public void DisplayMovies()
        {
            _writer.DisplayMovies(Movies);
        }
        public async Task SaveMovies()
        {
            await _persistanceLogic.SaveMovies(Movies);
        }
        public async Task GetAllMovies()
        {
            Movies = await _persistanceLogic.GetAllMovies();
        }
        public async Task<Movie> GetMovie(string title,string year)
        {
            return await _movieProviderLogic.GetMovie(title, year);  
        }

        public void Add(Movie movie)
        {
            var moviesModifyed = Movies as List<Movie>;
            moviesModifyed.Add(movie);
            Movies = moviesModifyed;
            _persistanceLogic.SaveMovies(Movies);
        }
    }
}
