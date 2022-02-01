using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ReserveTaPlace.Data.Interfaces
{
    public interface IMovie
    {
        Task<IEnumerable<MovieEntity>> GetAllPaginated(int pageIndex, int pageSize);
        Task<IEnumerable<MovieEntity>> GetAll();
        Task<MovieEntity> GetById(Guid id);
        Task<bool> DeleteById(Guid id);
        Task<bool> Add(MovieEntity entity);
        Task<MovieEntity> GetMovieByNameAndYear(string title,string year);

    }
}
