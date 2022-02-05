using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Data.Utils;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private ITheater _theater;
        private IMapper _mapper;

        public TheaterController(IMapper mapper, DbContext context)
        {
            _theater = new TheaterFunctions(context);
            _mapper = mapper;
        }

        // GET: api/<TheaterController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var theaters = await _theater.GetAll();
            var theaterDto = _mapper.Map<IEnumerable<TheaterDto>>(theaters);
            return Ok(theaterDto);
        }

        // GET api/<TheaterController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var theaterEntity = await _theater.GetById(id);
            var theaterDto = _mapper.Map<TheaterDto>(theaterEntity);
            return Ok(theaterDto);
        }

        // POST api/<TheaterController>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TheaterDto theaterDto)
        {
            var theaterEntity = _mapper.Map<TheaterEntity>(theaterDto);
            var theaterEntityResult = await _theater.Add(theaterEntity);
            return Ok(theaterEntityResult);
        }


        //[HttpPost("GetAllPaginated")]
        //public async Task<ActionResult> GetAllPaginated([FromBody] List<int> ressourceList)
        //{
        //    var theaters = await _theaterSpec.GetAllPaginated(ressourceList[0], ressourceList[1]);
        //    var theatersDto = _mapper.Map<PaginatedList<TheaterDto>>(theaters);

        //    return Ok(theatersDto);
        //}

        //PUT api/<TheaterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] TheaterDto theaterDto)
        {
            var theaterEntity = _mapper.Map<TheaterEntity>(theaterDto);
            var theaterUpdate = await _theater.Update(theaterEntity);
            return Ok(theaterUpdate);
        }

        //DELETE api/<TheaterController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _theater.DeleteById(id);
            return Ok(result);
        }
    }
}
