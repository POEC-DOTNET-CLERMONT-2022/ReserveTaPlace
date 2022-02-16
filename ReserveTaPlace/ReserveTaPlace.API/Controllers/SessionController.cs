using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private IMapper _mapper;
        private ISessions _session;
        private IRoom _room;

        public SessionController(IMapper mapper, DbContext context)
        {
            _room = new RoomFunctions(context);
            _session = new SessionFunctions(context);
            _mapper = mapper;

        }
        [HttpPost("AddSessions")]
        public async Task<ActionResult> AddSessions([FromBody] List<SessionDto> sessions)
        {
            //TODO :Gestion des exception
            //TODO : ajouter des logs 
            var test = sessions;
            var sessionsEntities = _mapper.Map<List<SessionEntity>>(sessions);
            var result = await _session.AddSessions(sessionsEntities);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _session.GetSessions();
            return Ok(result);
        }
        [HttpPost("AddRoomSession")]
        public async Task<ActionResult> AddRoomSession([FromBody] SessionDto session)
        {
            var sessionEntity = _mapper.Map<SessionEntity>(session);
            var result = _room.AddRoomSession(session.RoomId, sessionEntity);
            return Ok(result);
        }
    }
}
