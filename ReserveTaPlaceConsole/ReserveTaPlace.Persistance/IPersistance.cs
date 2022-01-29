using ReserveTaPlace.Models.CModels;

namespace ReserveTaPlace.Persistance
{
    public interface IPersistance
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task SaveMovies(IEnumerable<Movie> movies);
    }
}
