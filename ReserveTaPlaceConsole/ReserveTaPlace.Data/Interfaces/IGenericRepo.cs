using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<bool> DeleteById(Guid id);

    }
}
