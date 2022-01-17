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
        public UserController(IMapper mapper)
        {
            _users = new GenericFunctions<UserEntity>();
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet("All")]
        public async Task<ActionResult> All()
        {
            var users = await _users.GetAll();
            var usersDto = _mapper.Map<List<UserEntity>>(users);
            return Ok(usersDto);
        }
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
