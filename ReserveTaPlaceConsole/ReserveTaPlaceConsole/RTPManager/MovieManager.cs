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
using ConsoleManager.Data.Models;
using ConsoleManage.Manager;

namespace ReserveTaPlace.RTPManager
{
    public class MovieManager
    {
        private PersistanceLogic _persistanceLogic;
        private MovieProviderLogic _movieProviderLogic;
        private Manager _manager;
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
            _movieProviderLogic = new MovieProviderLogic();
            _manager = new Manager();
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

        internal void Delete(string movieTitle)
        {
            var moviesListResult = Movies.Where(e => e.Title.ToLower().Contains(movieTitle.ToLower())).ToList();
            if(moviesListResult.Count == 0)
            {
                Console.WriteLine($"Le film {movieTitle} n'existe pas !!");
            }
            if(moviesListResult.Count == 1)
            {
                var moviesModifyed = Movies.Where(e => e.Title.ToLower() != movieTitle.ToLower());
                Movies = moviesModifyed;
            }
            if(moviesListResult.Count > 1)
            {
                Console.WriteLine($"Votre recherche comporte plusieurs résultats :");
                _writer.DisplayMovies(moviesListResult);
                var question = new Question("Entrer l'id du film à ajouter :", (uint)moviesListResult.Count, QuestionType.ChoixMultiple);
                _manager.WriteQuestion(question);
                var answer = _manager.ReadUserEntry(question);
                var movieToDelete = Movies.FirstOrDefault(m => m.Id == int.Parse(answer.Text));
                var modifyedList = Movies as List<Movie>;
                modifyedList.Remove(movieToDelete);
                Movies = modifyedList;
                _persistanceLogic.SaveMovies(Movies);
            }
        }

        internal int CalculateId()
        {
            int id = 0;
            if(Movies.ToList().Count == 0)
            {
                return id = 1;
            }
            var lastMovie = Movies.Last();
            id = lastMovie.Id + 1;
            return id;
        }
    }
}
