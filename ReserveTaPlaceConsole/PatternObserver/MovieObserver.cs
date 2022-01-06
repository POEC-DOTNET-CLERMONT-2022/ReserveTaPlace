using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    public class MovieObserver : IObserver
    {
        public void Update(Movie movie)
        {
            Console.WriteLine($"le film {movie.Title}");
        }
    }
}
