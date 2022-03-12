using ReserveTaPlace.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public interface IMovieProviderLogic
    {
        Task<List<MovieDto>> GetMovie(string title, string year);
    }
}
