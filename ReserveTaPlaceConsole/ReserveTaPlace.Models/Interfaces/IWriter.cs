using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.Interfaces
{
    public interface IWriter
    {
        public void Display(string message);
        public void DisplayMovie(Movie movie);
        public void DisplayMovies(IEnumerable<Movie> movies);
    }
}
