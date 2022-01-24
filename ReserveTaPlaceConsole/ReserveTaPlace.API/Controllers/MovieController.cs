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
        public async Task<ActionResult> Add([FromBody] MovieDto movieDto)
        {
            var movieEntity = _mapper.Map<MovieEntity>(movieDto);
            var movieDtoResult = await _movie.Add(movieEntity);
            return Ok(movieDtoResult);
        }
        //[Route("ImdbMovie/{ressource}")]
        [HttpPost("{ressource}")]
        public async Task<ActionResult> ImdbMovie(string ressource)
        {
            //TODO refactor
            var httpClient = _httpClientFactory.CreateClient("Imdb");
            var moviesDto = new List<MovieDto>();
            var movieDto = new MovieDto();
            //var imdbSearch = await httpClient.GetFromJsonAsync<ImdbSearch>(ressource);
            
            using (var imdbSearchStrg = httpClient.GetStringAsync(ressource))
            {
                ImdbSearch result = JsonConvert.DeserializeObject<ImdbSearch>(imdbSearchStrg.Result);
                moviesDto = result.ImdbMovies;
            }
            if (moviesDto.Count > 0)
            {
                //var imdbSearch = await httpClient.GetFromJsonAsync<ImdbSearch>($"?&r=json&i={moviesDto[0].ImdbId}");
                using (var imdbSearchStrg = httpClient.GetStringAsync($"?&r=json&i={moviesDto[0].ImdbId}"))
                {
                    movieDto = System.Text.Json.JsonSerializer.Deserialize<MovieDto>(imdbSearchStrg.Result);
                }
                return Ok(movieDto);
            }
            return Ok(movieDto);
        }
    }
}
