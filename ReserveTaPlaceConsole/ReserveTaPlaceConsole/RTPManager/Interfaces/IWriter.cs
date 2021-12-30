using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.RTPManager.Interfaces
{
    public interface IWriter
    {
        public void Display(string message);
        public void DisplayMovie(Movie movie,int id);
        public void DisplayMovies(IEnumerable<Movie> movies);
    }
}
