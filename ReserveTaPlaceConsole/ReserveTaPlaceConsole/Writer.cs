using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole
{
    internal class Writer
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayMovie(Movie movie)
        {
            Console.WriteLine(movie.Title);
        }

        public void DisplayMovies(IEnumerable<Movie> movies)
        {
            foreach (Movie movie in movies) { DisplayMovie(movie); }
        }
    }
}
