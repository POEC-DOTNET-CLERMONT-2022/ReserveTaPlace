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
        public SessionController(IMapper mapper, DbContext context)
        {
            _session = new SessionFunctions(context);
            _mapper = mapper;

        }
        [HttpPost("AddSessions")]
        public async Task<ActionResult> AddSessions([FromBody] List<SessionDto> sessions)
        {
            var test = sessions;
            var sessionsEntities = _mapper.Map<List<SessionEntity>>(sessions);
            var result = await _session.AddSessions(sessionsEntities);
            return Ok(result);
        }
    }
}
