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
    public class RoleDataManager : ApiDataManager<RoleModel, RoleDto>
    {
        public RoleDataManager(HttpClient client, IMapper mapper, string serverUrl)
            : base(client, mapper, serverUrl, "/api/role")
        {
        }
    }
}
