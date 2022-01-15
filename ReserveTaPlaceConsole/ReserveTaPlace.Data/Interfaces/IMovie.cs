using ReserveTaPlace.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReserveTaPlace.Entities;


namespace ReserveTaPlace.Data.Interfaces
{
    public interface IMovie
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetById(Guid id);
        Task<Movie> GetByName(string title);
        Task<Movie> Add(Movie movie);
        Task<Movie> Update(Movie movie);
        Task<Movie> Delete(Movie movie);


    }
}
