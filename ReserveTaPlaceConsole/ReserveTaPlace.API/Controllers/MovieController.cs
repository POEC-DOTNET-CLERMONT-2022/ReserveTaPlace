using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieLogic _movieLogic;
        private IMapper _mapper;
        public MovieController(IMapper mapper)
        {
            _movieLogic = new MovieLogic();
            _mapper = mapper;
        }
        // GET: MovieController/GetAll
        [HttpGet("All")]
        public async Task<List<MovieDto>> All()
        {
            var movies = await _movieLogic.GetAll();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            return moviesDto;
        }
        // GET: api/<MovieController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<MovieController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
