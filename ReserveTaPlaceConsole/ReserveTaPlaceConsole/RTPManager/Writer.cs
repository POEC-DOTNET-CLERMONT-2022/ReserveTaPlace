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
        public void DisplayMovie(Movie movie,int id)
        {
            Console.WriteLine($"ID : {id} Titre : {movie.Title}");
        }

        public void DisplayMovies(IEnumerable<Movie> movies)
        {
            int id = 0;
            foreach (Movie movie in movies) { id++; DisplayMovie(movie,id); }
        }
    }
}
