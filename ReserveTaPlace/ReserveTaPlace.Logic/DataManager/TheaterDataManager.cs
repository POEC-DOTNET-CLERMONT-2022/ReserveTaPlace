using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.Logic.DataManager
{
    public class TheaterDataManager : ApiDataManager<TheaterModel, TheaterDto>
    {
    public TheaterDataManager(HttpClient client, IMapper mapper, string serverUrl)
        : base(client, mapper, serverUrl, "/api/theater")
        {
        }
    }
}
