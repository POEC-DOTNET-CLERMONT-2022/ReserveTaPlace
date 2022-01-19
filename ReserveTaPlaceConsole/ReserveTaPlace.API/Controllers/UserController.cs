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
        private IUser _users;

        private IMapper _mapper;
        private AppConfig _appConfig;

        public UserController(IMapper mapper, IConfiguration config)
        {
            _appConfig = new AppConfig(config);
            _users = new UserFunctions(_appConfig.ConnectionString);
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _users.GetAll();
            var usersDto = _mapper.Map<List<UserEntity>>(users);
            return Ok(usersDto);
        }
       
    }
}
