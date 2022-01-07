using ReserveTaPlace.Models;
using ReserveTaPlace.MovieDataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public class MovieProviderLogic
    {
        private readonly IMovieProvider _movieProvider;
        public MovieProviderLogic()
        {
            _movieProvider=new MovieProvider();
        }
        public async Task<Movie> GetMovie(string title,string year)
        {
            return await _movieProvider.GetMovie(title,year);
        }
    }
}
