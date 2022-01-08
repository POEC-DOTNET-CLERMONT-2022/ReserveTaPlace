using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole.RTPManager
{
    internal class Writer : IWriter
    {
        public void DisplayMovie(Movie movie)
        {
            Console.WriteLine($"ID : {movie.Id} Titre : {movie.Title}");
        }

        public void DisplayMovies(IEnumerable<Movie> movies)
        {
            foreach (Movie movie in movies) { DisplayMovie(movie); }
        }

        public void DisplayOnDisplayMovies(IEnumerable<Movie> movies)
        {
            foreach(Movie movie in movies.Where(m => m.IsMovieOnDisplay == true)) { DisplayMovie(movie); };
        }
    }
}
