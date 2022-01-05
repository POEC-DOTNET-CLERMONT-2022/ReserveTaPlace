using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.RTPManager.Interfaces
{
    public interface IReader
    {
        public Movie ReadMovie();
        public Task<Movie> GetMovie(string title, string year);
    }

}
