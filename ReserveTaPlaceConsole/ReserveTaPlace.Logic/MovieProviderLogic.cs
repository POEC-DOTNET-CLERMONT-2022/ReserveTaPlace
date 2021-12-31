using ReserveTaPlace.Models;
using ReserveTaPlace.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public class MovieProviderLogic
    {
        private readonly IMovieProvider _movieProvider = new MovieProvider();
        public async Task<List<Movie>> GetMovie(string movie)
        {
            return await _movieProvider.GetMovie(movie);
        }
    }
}
