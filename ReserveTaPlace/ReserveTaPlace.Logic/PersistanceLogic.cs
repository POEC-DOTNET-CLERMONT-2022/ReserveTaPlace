using ReserveTaPlace.Models.CModels;
using ReserveTaPlace.Persistance;
using ReserveTaPlace.Persistance.Functions;

namespace ReserveTaPlace.Logic
{
    public class PersistanceLogic
    {
        private readonly IPersistance _persistance;

        public PersistanceLogic()
        {
            _persistance = new MovieFunctions();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _persistance.GetAllMovies();
        }


        public async Task SaveMovies(IEnumerable<Movie> movieList)
        {
            await _persistance.SaveMovies(movieList);
        }

    }
}
