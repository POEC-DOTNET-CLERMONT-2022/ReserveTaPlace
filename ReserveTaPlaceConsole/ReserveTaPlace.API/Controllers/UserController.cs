using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Data.Utils;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private IGenericRepo<UserEntity> _users;
        private IUser _user;
        private IMapper _mapper;

        public UserController(IMapper mapper, IGenericRepo<UserEntity> user, ILogger<UserController> logger, DbContext db)
        {
            _logger = logger;
            _users = user;
            _user = new UserFunctions(db);
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var users = await _users.GetAll();
                var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(usersDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"une erreur et survenue",e.StackTrace);//TODO : juste 2 param
                return StatusCode(500);
            }

        }
        [HttpGet("AllPaginated")]
        public async Task<ActionResult> GetAllPaginated([FromQuery] int pageIndex, int pageSize)
        {
            var users = await _user.GetAllPaginated(pageIndex, pageSize);
            var usersDto = _mapper.Map<PaginatedList<UserDto>>(users);
            return Ok(usersDto);
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserDto userDto)
        {
            var userEntity = _mapper.Map<UserEntity>(userDto);
            var result = await _user.Add(userEntity);
            return Ok(result);
        }
        [HttpGet("UserHash")]
        public async Task<ActionResult> UserHash([FromQuery] string email)
        {
            var result = await _user.GetUserHash(email);
            return Ok(result);
        }

    }
}
