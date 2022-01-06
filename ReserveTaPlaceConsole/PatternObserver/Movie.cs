using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    public class Movie
    {
        public string Title { get; set; }

        public Movie(string title)
        {
            Title = title;
        }
    }
}
