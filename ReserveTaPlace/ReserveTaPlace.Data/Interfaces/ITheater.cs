using ReserveTaPlace.Data.Utils;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Interfaces
{
    public interface ITheater
    {
        Task<PaginatedList<TheaterEntity>> GetAllPaginated(int pageIndex, int pageSize);
        Task<IEnumerable<TheaterEntity>> GetAll();
        Task<TheaterEntity> GetById(Guid id);
        Task<TheaterEntity> GetByName(string name);
        Task<bool> DeleteById(Guid id);
        Task<bool> Add(TheaterEntity theater);
        Task<TheaterEntity> Update(TheaterEntity theater);
    }
}
