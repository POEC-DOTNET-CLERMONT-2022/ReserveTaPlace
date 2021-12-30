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
        public Movie ReadMovie()
        {
            throw new NotImplementedException();
        }

        public Movie SearchMovie()
        {
            //Writer.Display("Indiquer le film à ajouter :");
            //var movieName = Console.ReadLine().Trim();
            //if (String.IsNullOrEmpty(movieName))
            //{
            //    Writer.Display($"Le nom de film : {movieName} indiqué est incorrect");
            //    return SearchMovie();
            //}
            var movie = new Movie("Alien");
            return movie ;
        }
    }
}
