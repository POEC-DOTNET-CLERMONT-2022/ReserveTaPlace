using ReserveTaPlace.Models;
using ReserveTaPlace.MovieDataBaseService;

namespace ReserveTaPlace.Logic
{

    public class MovieProviderLogic
    {
        private readonly IMovieProvider _movieProvider;
        public MovieProviderLogic()
        {
            _movieProvider = new MovieProvider();
        }
        public async Task<List<Movie>> GetMovie(string title, string year)
        {
            return await _movieProvider.GetMovie(title, year);
        }
    }
}
