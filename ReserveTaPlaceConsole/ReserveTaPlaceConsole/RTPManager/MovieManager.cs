using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager.Interfaces;
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
        private IReader _reader { get; }
        private IWriter _writer { get; }

        private IList<Movie> Movies { get; set; } = new List<Movie>();

        public MovieManager(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Add()
        {
            Movies.Add(_reader.ReadMovie());
        }
        public void Read()
        {

            _writer.DisplayMovies(Movies);

        }
        public void SaveMovies(List<Movie> movies)
        {
            _persistanceLogic.SaveMovies(movies);
        }
        public void LoadMovies()
        {
            Movies = _persistanceLogic.LoadMovies();
        }

    }
}
