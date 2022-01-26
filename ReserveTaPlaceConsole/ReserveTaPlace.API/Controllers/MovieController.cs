using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using ReserveTaPlace.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private IHttpClientFactory _httpClientFactory;
        private IGenericRepo<MovieEntity> _movie;
        private IMapper _mapper;
        public MovieController(IMapper mapper, IGenericRepo<MovieEntity> movie, IHttpClientFactory HttpClientFactory)
        {
            _movie = movie;
            _mapper = mapper;
            _httpClientFactory = HttpClientFactory;
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
        public async Task<ActionResult> Add([FromBody] Movie movie)
        {
            var movieEntity = _mapper.Map<MovieEntity>(movie);
            var movieDtoResult = await _movie.Add(movieEntity);
            return Ok(movieDtoResult);
        }
        [HttpPost("ImdbMovie")]
        public async Task<ActionResult> ImdbMovie([FromBody]string ressource)
        {
            var httpClient = _httpClientFactory.CreateClient("Imdb");
            var moviesDto = new List<MovieDto>();
            var movieDto = new MovieDto();
           
            using (var imdbSearchStrg = httpClient.GetStringAsync(ressource))
            {
                ImdbSearch result = JsonConvert.DeserializeObject<ImdbSearch>(imdbSearchStrg.Result);
                moviesDto = result.ImdbMovies;
            }
            if (moviesDto.Count > 0)
            {
                using (var imdbSearchStrg = httpClient.GetStringAsync($"?&r=json&i={moviesDto[0].ImdbId}"))
                {
                    movieDto = JsonConvert.DeserializeObject<MovieDto>(imdbSearchStrg.Result);
                }
                return Ok(movieDto);
            }
            return Ok(movieDto);
        }
    }
}
