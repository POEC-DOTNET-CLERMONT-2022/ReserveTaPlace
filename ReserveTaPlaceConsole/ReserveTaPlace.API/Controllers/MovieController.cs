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
            //var movieDto= JsonConvert.DeserializeObject(jsonMovieDto);
            var movieEntity = _mapper.Map<MovieEntity>(movieDto);
            //var movieEntity = new MovieEntity()
            //{
            //    Actors = movieDto.Actors,
            //    Country = movieDto.Country,
            //    Director=movieDto.Director,
            //    Id=Guid.NewGuid(),
            //    IsMovieOnDisplay=false,
            //    Plot=movieDto.Plot,
            //    Poster = movieDto.Poster,
            //    Released=movieDto.Released,
            //    Title=movieDto.Title,
            //    Runtime=movieDto.Runtime,
            //    Genre=movieDto.Genre,
            //    ImdbId=movieDto.ImdbId
            //};
            var movieDtoResult = await _movie.Add(movieEntity);
            return Ok(movieDtoResult);
        }
    }
}
