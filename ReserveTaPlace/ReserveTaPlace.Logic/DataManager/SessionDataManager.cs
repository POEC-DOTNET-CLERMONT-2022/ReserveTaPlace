using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic.DataManager
{
    public class SessionDataManager : ApiDataManager<SessionModel, SessionDto>
    {
        public SessionDataManager(HttpClient client, IMapper mapper, string serverUrl)
            : base(client, mapper, serverUrl, "/api/session")
        {
        }
    }
}
