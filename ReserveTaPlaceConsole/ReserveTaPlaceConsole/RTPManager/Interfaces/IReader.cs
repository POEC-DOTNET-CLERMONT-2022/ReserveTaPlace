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
        public IWriter Writer { get; set; }
        public Movie ReadMovie();
    }

}
