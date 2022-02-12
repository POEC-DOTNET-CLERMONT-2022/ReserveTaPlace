using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Interfaces
{
    public interface IRoom
    {
        Task<bool> AddRoomSession(Guid roomId, SessionEntity session);
    }
}
