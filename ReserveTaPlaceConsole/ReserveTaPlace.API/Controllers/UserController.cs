using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGenericRepo<UserEntity> _users;

        private IMapper _mapper;

        public UserController(IMapper mapper, IGenericRepo<UserEntity> user)
        {
            _users = user;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _users.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserEntity>>(users);
            return Ok(usersDto);
        }
       
    }
}
