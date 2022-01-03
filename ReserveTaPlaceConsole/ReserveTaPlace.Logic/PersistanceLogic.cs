using ReserveTaPlace.Models;
using ReserveTaPlace.Persistance;
using ReserveTaPlace.Persistance.Functions;
using ReserveTaPlace.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public class PersistanceLogic
    {
        private readonly IPersistance _persistance;
        private readonly IUser _user;


        public PersistanceLogic()
        {
            _persistance = new MovieFunctions();
        }

        public List<Movie> LoadMovies()
        {
            return _persistance.LoadMovies();
        }

        public void SaveMovies(List<Movie> movieList)
        {
            _persistance.SaveMovies(movieList);
        }
        /// USER
        public void GetUser(string login, string password)
        {
            _user.GetUser(login, password);
        }
    }
}
