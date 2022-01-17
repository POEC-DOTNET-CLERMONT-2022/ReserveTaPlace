using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ReserveTaPlace.Data.Interfaces
{
    public interface IMovie
    {
        Task<IEnumerable<MovieEntity>> GetAll();

    }
}
