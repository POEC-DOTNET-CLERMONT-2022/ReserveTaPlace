using ReserveTaPlace.Entities;

namespace ReserveTaPlace.Logic
{
    public interface IMovieLogic
    {
        Task<IEnumerable<Movie>> GetAll();
    }
}
