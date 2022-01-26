using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public interface IGenericLogic<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
