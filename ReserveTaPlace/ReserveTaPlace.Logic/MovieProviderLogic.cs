using ReserveTaPlace.DTOS;
using ReserveTaPlace.MovieDataBaseService;

namespace ReserveTaPlace.Logic
{

    public class MovieProviderLogic : IMovieProviderLogic
    {
        private readonly IMovieProvider _movieProvider;
        public MovieProviderLogic()
        {
            _movieProvider = new MovieProvider();
        }
        public async Task<List<MovieDto>> GetMovie(string title, string year)
        {
            return await _movieProvider.GetMovie(title, year);
        }
    }
}
