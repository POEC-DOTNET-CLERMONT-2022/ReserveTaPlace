using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Interfaces
{
    public interface IMovie
    {
        IEnumerable<Movie> GetAllMovies();
    }
}
