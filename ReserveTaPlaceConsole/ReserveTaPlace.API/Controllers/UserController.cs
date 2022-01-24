using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
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

        private IMapper _mapper;

        public UserController(IMapper mapper, IGenericRepo<UserEntity> user, ILogger<UserController> logger)
        {
            _logger = logger;
            _users = user;
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
                _logger.LogError(e,"une erreur et survenue",e.StackTrace);
                return StatusCode(500);
            }

        }
       
    }
}
