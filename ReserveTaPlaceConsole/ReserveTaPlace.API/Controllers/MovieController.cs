using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        private readonly IHttpClientFactory _httpClientFactory;
        private IGenericRepo<MovieEntity> _movie;
        private IMapper _mapper;
        public MovieController(IMapper mapper, IGenericRepo<MovieEntity> movie)
        {
            _movie = movie;
            _mapper = mapper;
        }
        // GET: MovieController/GetAll
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var movies = await _movie.GetAll();
            var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
            return Ok(moviesDto);
        }

        // GET: MovieController/GetById
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var movie = await _movie.GetById(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        // POST MovieController/Post
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MovieDto movieDto)
        {
            var movieEntity = _mapper.Map<MovieEntity>(movieDto);
            var movieDtoResult = await _movie.Add(movieEntity);
            return Ok(movieDtoResult);
        }
        //POST MovieController/Get
       [HttpGet("GetMovie")]
        public async Task<ActionResult> GetMovie([FromQuery] string requestParams)
        {
            var httpClient = _httpClientFactory.CreateClient("Imdb");
            var moviesDto = new List<MovieDto>();
            var moviesDtoResult = await httpClient.GetFromJsonAsync<List<MovieDto>>(requestParams);
            if (moviesDtoResult.Count > 0)
            {
                moviesDto = await httpClient.GetFromJsonAsync<List<MovieDto>>($"?&r=json&i={moviesDtoResult[0].ImdbId}");
                return Ok(moviesDto);
            }
            return Ok(moviesDto);
        }
    }
}
