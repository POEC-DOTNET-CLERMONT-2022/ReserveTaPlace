using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.Interfaces
{
    public interface IReader
    {
        public IWriter Writer { get; set; }
        public Movie ReadMovie();
    }

}
