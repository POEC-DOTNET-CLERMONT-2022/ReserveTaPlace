using ReserveTaPlace.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.MovieDataBaseService
{
    public interface IMovieProvider
    {
        Task<List<MovieDto>> GetMovie(string movie, string year);
    }
}
