using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.RTPManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole.RTPManager
{
    public class Reader : IReader
    {
        private MovieProviderLogic _movieProvider = new MovieProviderLogic();
        public Movie ReadMovie()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> SearchMovie(string movieName)
        {
   
            return await _movieProvider.GetMovie(movieName);
        }
    }
}
