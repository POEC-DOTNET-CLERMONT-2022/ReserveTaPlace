using ReserveTaPlace.DTOS;

namespace ReserveTaPlace.Logic
{
    public interface IMovieLogic
    {
        Task<IEnumerable<MovieDto>> GetAll();

        Task<MovieDto> Add(MovieDto movieDto);
    }
}
