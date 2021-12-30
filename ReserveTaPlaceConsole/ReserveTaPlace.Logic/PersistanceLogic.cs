using ReserveTaPlace.Models;
using ReserveTaPlace.Persistance;
using ReserveTaPlace.Persistance.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public class PersistanceLogic
    {
        private readonly IPersistance _persistance;

        public PersistanceLogic()
        {
            _persistance = new MovieFunctions();
        }

        public List<Movie> LoadMovies()
        {
            return _persistance.LoadMovies();
        }

        public void SaveMovies(List<Movie> movieList)
        {
            _persistance.SaveMovies(movieList);
        }
    }
}
