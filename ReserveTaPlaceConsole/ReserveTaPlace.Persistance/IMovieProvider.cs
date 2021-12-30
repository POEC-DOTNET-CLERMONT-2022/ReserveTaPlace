using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Persistance
{
    public interface IMovieProvider
    {
        Task<Movie> GetMovie(string movie);
    }
}
