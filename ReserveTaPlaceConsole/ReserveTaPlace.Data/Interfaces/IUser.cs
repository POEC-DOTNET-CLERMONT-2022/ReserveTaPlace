using ReserveTaPlace.Data.Utils;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Interfaces
{
    public interface IUser
    {
        Task<bool> Add(UserEntity user);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<PaginatedList<UserEntity>> GetAllPaginated(int pageIndex, int pageSize);
    }
}
