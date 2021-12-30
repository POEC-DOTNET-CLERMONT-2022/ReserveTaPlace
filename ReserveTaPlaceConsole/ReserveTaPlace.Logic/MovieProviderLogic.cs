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
        private readonly IMovieProvider MovieProvider;
        public async Task<Movie> GetMovie(string movie)
        {
            return await MovieProvider.GetMovie(movie);
        }
    }
}
