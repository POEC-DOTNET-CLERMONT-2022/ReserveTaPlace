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
    public class MovieController : ControllerBase
    {
        //private IGenericRepo<MovieEntity> _movie;
        private IMovie _movie;
        private IMapper _mapper;
        private AppConfig _appConfig;
        public MovieController(IMapper mapper, IConfiguration config)
        {
            _appConfig = new AppConfig(config);
            _movie = new MovieFunctions(_appConfig.ConnectionString);
            _mapper = mapper;
        }
        // GET: MovieController/GetAll
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var movies = await _movie.GetAll();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            return Ok(moviesDto);
        }

        // GET: MovieController/GetById
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var movie = await _movie.GetById(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movie);
        }

        // POST MovieController/Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {

        }
    }
}
