using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.Logic
{

    public class MovieLogic
    {
        private IMovie _movie;
        public MovieLogic()
        {
            _movie = new MovieFunction();
        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movie.GetAllMovies();
        }
    }
}
