using MovieServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{

    public class MovieLogic
    {
        private MovieServiceClient _movieServiceClient = new MovieServiceClient();
        public ICollection<MovieDto> GetAllMovies()
        {
            ICollection<MovieDto> listMovies = _movieServiceClient.GetAllMovies();
            return listMovies;
        }
    }
}
