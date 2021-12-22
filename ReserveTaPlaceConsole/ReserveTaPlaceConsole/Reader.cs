using ReserveTaPlace.Models;
using ReserveTaPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole
{
    internal class Reader : IReader
    {
        public IWriter Writer { get; set; }

        public Movie ReadMovie()
        {
            Writer.Display("Indiquer le film à ajouter :");
            var movieName = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(movieName))
            {
                Writer.Display($"Le nom de film : {movieName} indiqué est incorrect");
                return ReadMovie();
            }
            return GetMovie();
        }
    }
}
