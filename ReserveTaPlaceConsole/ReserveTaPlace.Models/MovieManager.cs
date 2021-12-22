using ReserveTaPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class MovieManager
    {
        private IReader _reader { get; }
        private IWriter _writer { get; }

        private IList<Movie> Movies { get; set; } = new List<Movie>();

        public MovieManager(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Add()
        {
            Movies.Add(new Movie());
        }
        public void Read()
        {
            foreach (var movie in Movies)
            {
                Console.WriteLine($"");
            }
        }
    }
}
